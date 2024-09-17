using DynForms.Server.Models;

namespace DynForms.Server.Dto
{
    public class FormDto
    {
        public string? Name { get; set; }

        public string DisplayName { get; set; }

        public bool Enabled { get; set; }

        public virtual IEnumerable<FieldDto> Fields { get; set; } = new List<FieldDto>();

        public static Form MapFrom(FormDto entity)
        {
            return new Form()
            {
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Enabled = entity.Enabled,
                Fields = entity.Fields.Select(FieldDto.MapFrom).ToList()
            };
        }
    }


    public class UpdateFormDto
    {
        public string? Name { get; set; }

        public string DisplayName { get; set; }

        public bool Enabled { get; set; }

    }
}
