using Microsoft.EntityFrameworkCore;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.BaseData;
using Shop.Domain.Entities.BaseData;
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
        public Task<OperationResult<List<LookupResponseDto>>> GetCityListAsync(long provinceId,CancellationToken cancellationToken = default(CancellationToken));
        public Task<OperationResult<List<LookupResponseDto>>> GetProvinceListAsync(CancellationToken cancellationToken = default(CancellationToken)); 
    }
    public class LookupService : ILookupService
    {
        private readonly ICityBaseDataRepository _cityBaseDataRepository;
        private readonly IProvinceBaseDataRepository _provinceBaseDataRepository;

        public LookupService(ICityBaseDataRepository cityBaseDataRepository, IProvinceBaseDataRepository provinceBaseDataRepository)
        {
            _cityBaseDataRepository = cityBaseDataRepository;
            _provinceBaseDataRepository = provinceBaseDataRepository;
        }

        public async Task<OperationResult<List<LookupResponseDto>>> GetCityListAsync(long provinceId, CancellationToken cancellationToken = default)
        {
            try
            {
                var cityList = await _cityBaseDataRepository.SelectAsync(x=>x.ProvinceId ==  provinceId, cancellationToken);

                var cityListDto = new List<LookupResponseDto>();

                foreach (var city in await cityList.ToListAsync())
                {
                    cityListDto.Add(GeneralMapper.Map<CityModel,LookupResponseDto>(city));
                }
                return new OperationResult<List<LookupResponseDto>>(cityListDto,true, LookupMessageResult.OperationSuccess);
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
                var provinceList = await _provinceBaseDataRepository.GetAllAsync(cancellationToken);

                var provinceListDto = new List<LookupResponseDto>();

                foreach (var province in provinceList)
                {
                    provinceListDto.Add(GeneralMapper.Map<ProvinceModel, LookupResponseDto>(province));
                }
                return new OperationResult<List<LookupResponseDto>>(provinceListDto, true, LookupMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
