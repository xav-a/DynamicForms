using DynForms.Server.Models;

namespace DynForms.Server.Dto
{
    public class FieldDto
    {
        public string? Label { get; set; }

        public short? Width { get; set; }

        public string? Type { get; set; }

        public bool Enabled { get; set; }

        public int? FormId { get; set; }

        public static Field MapFrom(FieldDto entity)
        {
            return new Field()
            {
                Enabled = entity.Enabled,
                Label = entity.Label,
                Type = entity.Type,
                Width = entity.Width,
                FormId = entity.FormId,
            };
        }
    }
}
