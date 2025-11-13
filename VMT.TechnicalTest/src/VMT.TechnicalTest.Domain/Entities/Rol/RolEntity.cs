using VMT.TechnicalTest.Domain.Base;

namespace VMT.TechnicalTest.Domain.Entities.Rol
{
    public class RolEntity : BaseEntity
    {
        public string Username { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}