using Common.Converter;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Cache;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.BaseData;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Entities.BaseData;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface ILookupService
    {
        public Task<OperationResult<List<LookupResponseDto>>> GetCityListAsync(long provinceId, CancellationToken cancellationToken = default(CancellationToken));
        public Task<OperationResult<List<LookupResponseDto>>> GetProvinceListAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
    public class LookupService : ILookupService
    {
        private readonly ICityBaseDataRepository _cityBaseDataRepository;
        private readonly IProvinceBaseDataRepository _provinceBaseDataRepository;
        private readonly IDistributedCacheService _distributedCacheService;

        public LookupService(ICityBaseDataRepository cityBaseDataRepository, IProvinceBaseDataRepository provinceBaseDataRepository, IDistributedCacheService distributedCacheService)
        {
            _cityBaseDataRepository = cityBaseDataRepository;
            _provinceBaseDataRepository = provinceBaseDataRepository;
            _distributedCacheService = distributedCacheService;
        }

        public async Task<OperationResult<List<LookupResponseDto>>> GetCityListAsync(long provinceId, CancellationToken cancellationToken = default)
        {
            try
            {

                var cityList = await _cityBaseDataRepository.SelectAsync(x => x.ProvinceId == provinceId, cancellationToken);

                var cityListDto = new List<LookupResponseDto>();

                foreach (var city in await cityList.ToListAsync())
                {
                    cityListDto.Add(GeneralMapper.Map<CityModel, LookupResponseDto>(city));
                }



                return new OperationResult<List<LookupResponseDto>>(cityListDto, true, OperationMessageResult.OperationSuccess);



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<OperationResult<List<LookupResponseDto>>> GetProvinceListAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var cityLookupCache = await _distributedCacheService.GetAsync(Cache.ProvinceLookup.ToString());
                if (cityLookupCache == null)
                {
                    var provinceList = await _provinceBaseDataRepository.GetAllAsync(cancellationToken);

                    var provinceListDto = new List<LookupResponseDto>();

                    foreach (var province in provinceList)
                    {
                        provinceListDto.Add(GeneralMapper.Map<ProvinceModel, LookupResponseDto>(province));
                    }

                   await _distributedCacheService.SetAsync(Cache.ProvinceLookup.ToString(), BinarySerializer.SerializeToBinary<List<LookupResponseDto>>(provinceListDto));

                    return new OperationResult<List<LookupResponseDto>>(provinceListDto, true, OperationMessageResult.OperationSuccess);
                }
                else
                {
                    var provinceListDto = BinarySerializer.DeserializeFromBinary<List<LookupResponseDto>>(cityLookupCache);
                    return new OperationResult<List<LookupResponseDto>>(provinceListDto, true, OperationMessageResult.OperationSuccess);

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
