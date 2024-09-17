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
            var fields = entity.Fields.Select(FieldDto.MapFrom).ToList();
            fields.ForEach(field =>
            {
                field.FormId = null;
            });
            return new Form()
            {
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Enabled = entity.Enabled,
                Fields = fields
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
