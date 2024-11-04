using Microsoft.EntityFrameworkCore;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Inventory;
using Shop.Domain.Entities.Inventory;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IInventoryService 
    {
        public Task<OperationResult<PaginationResponsDto<InventoryDto>>> GetAllInventoryAsync(GetInventoryRequestDto getInventory, CancellationToken cancellationToken);
        public Task<OperationResult<InventoryDto>> GetInventoryAsync(long inventoryId, CancellationToken cancellationToken);
        public OperationResult CreateInventory(CreateInventoryRequestDto createInventory);
        public OperationResult UpdateInventory(UpdateInventoryRequestDto updateInventory);
        public OperationResult DeleteInventory(DeleteInventoryRequestDto deleteInventory);
    }

    public class InventoryService : IInventoryService
    {
        private readonly IGenericRepository<InventoryModel> _inventoryRepository;

        public InventoryService(IGenericRepository<InventoryModel> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<OperationResult<PaginationResponsDto<InventoryDto>>> GetAllInventoryAsync(GetInventoryRequestDto getInventory, CancellationToken cancellationToken)
        {
            try
            {
                var inventories = await _inventoryRepository.GetAllAsync(cancellationToken);

                if (!string.IsNullOrEmpty(getInventory.Name))
                    inventories = inventories.Where(x => x.Name.Contains(getInventory.Name));
              
                if (getInventory.CityId > 0)
                    inventories = inventories.Where(x => x.CityId == getInventory.CityId);

                long count = await inventories.CountAsync();

                inventories = inventories.Skip(getInventory.Page*getInventory.PageSize).Take(getInventory.PageSize);


                var inventoryResult = new List<InventoryDto>();

                foreach (var inventory in inventories)
                    inventoryResult.Add(GeneralMapper.Map<InventoryModel, InventoryDto>(inventory));


                return new OperationResult<PaginationResponsDto<InventoryDto>>(new PaginationResponsDto<InventoryDto>
                {
                    List = inventoryResult,
                    TotalCount = count
                },true,InventoryMessageResult.OperationSuccess);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<OperationResult<InventoryDto>> GetInventoryAsync(long inventoryId, CancellationToken cancellationToken)
        {
            try
            {
                var inventory = await _inventoryRepository.GetAsync(x => x.Id == inventoryId, cancellationToken, true);

                return new OperationResult<InventoryDto>(GeneralMapper.Map<InventoryModel, InventoryDto>(inventory), true, InventoryMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult CreateInventory(CreateInventoryRequestDto createInventory)
        {
            try
            {
                var inventoryModel = new InventoryModel(createInventory.Name, createInventory.CityId, createInventory.Address, createInventory.PostCode);

                _inventoryRepository.Add(inventoryModel);

                _inventoryRepository.Save();

                return new OperationResult(true, InventoryMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult UpdateInventory(UpdateInventoryRequestDto updateInventory)
        {
            var checkInventory = _inventoryRepository.Get(x => x.Id == updateInventory.Id);
            if (checkInventory is null) return new OperationResult(false, InventoryMessageResult.InventoryNotFound);

            try
            {
                checkInventory.Edit(updateInventory.Name, updateInventory.CityId, updateInventory.Address, updateInventory.PostCode);

                _inventoryRepository.Update(checkInventory);

                _inventoryRepository.Save();
                return new OperationResult(true, InventoryMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult DeleteInventory(DeleteInventoryRequestDto deleteInventory)
        {
            try
            {
                _inventoryRepository.Remove(deleteInventory.InventoryId);

                return new OperationResult(true, InventoryMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
