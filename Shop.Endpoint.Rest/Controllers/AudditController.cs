using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Mapper;
using Shop.Application.Services;
using Shop.Domain.Dtos.Category;
using Shop.Domain.Entities.General;
using Shop.Domain.Repositories;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    public class AuditController : ControllerBase
    {
        private readonly IGenericRepository<AuditLogModel> _repository;

        public AuditController(IGenericRepository<AuditLogModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAllAsync(cancellationToken));
        }

    }
}