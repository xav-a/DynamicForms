using DynForms.Server.Dto;
using DynForms.Server.Interfaces;
using DynForms.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Net;

namespace DynFields.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldController : ControllerBase
    {

        private readonly ILogger<FieldController> _logger;
        private readonly IRepository<Field> _fieldRepository;

        public FieldController(ILogger<FieldController> logger, IRepository<Field> fieldRepository)
        {
            _logger = logger;
            _fieldRepository = fieldRepository;
        }

        [HttpGet("{id}")]
        public async Task<Field> Get(int id)
        {
            return await _fieldRepository.Get(id);
        }

        [HttpPost]
        public async Task<bool> Create([FromBody] FieldDto body)
        {
            var entity = FieldDto.MapFrom(body);
            return await _fieldRepository.Add(entity) > 0;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, [FromBody] UpdateFieldDto body)
        {
            var entity = await _fieldRepository.Get(id);
            if (entity == null)
            {
                HttpContext.Response.StatusCode = 404;
                return false;
            }

            entity.Enabled = body.Enabled;
            entity.FormId = body.FormId;
            entity.Label = body.Label;
            entity.Type = body.Type;
            entity.Width = body.Width;

            return await _fieldRepository.Update(entity) > 0;
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var entity = await _fieldRepository.Get(id);
            return await _fieldRepository.Delete(entity) > 0;
        }
    }
}
