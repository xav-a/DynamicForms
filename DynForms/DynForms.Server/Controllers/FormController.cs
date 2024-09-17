using DynForms.Server.Dto;
using DynForms.Server.Interfaces;
using DynForms.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynForms.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {

        private readonly ILogger<FormController> _logger;
        private readonly IRepository<Form> _formRepository;
        private readonly IRepository<Field> _fieldRepository;

        public FormController(
            ILogger<FormController> logger,
            IRepository<Form> formRepository,
            IRepository<Field> fieldRepository)
        {
            _logger = logger;
            _formRepository = formRepository;
            _fieldRepository = fieldRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Form>> Get()
        {
            var forms = await _formRepository.GetAll();
            // TODO: Fix as lazy loading
            var fields = await _fieldRepository.GetAll();
            foreach (var form in forms.Where(f => !f.Fields.Any()))
            {
                
                form.Fields = fields.Where(f => f.FormId == form.Id).ToList();
            }

            return forms;
        }

        [HttpGet("{id}")]
        public async Task<Form> Get(int id)
        {
            return await _formRepository.Get(id);
        }

        [HttpPost]
        public async Task<bool> Create([FromBody] FormDto body)
        {
            var entity = FormDto.MapFrom(body);
            return await _formRepository.Add(entity) > 0;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, [FromBody] UpdateFormDto body)
        {
            var entity = await _formRepository.Get(id);
            if (entity == null)
            {
                HttpContext.Response.StatusCode = 404;
                return false;
            }

            entity.Name = body.Name;
            entity.DisplayName = body.DisplayName;
            entity.Enabled = body.Enabled;

            return await _formRepository.Update(entity) > 0;
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var entity = await _formRepository.Get(id);
            return await _formRepository.Delete(entity) > 0;
        }

    }
}
