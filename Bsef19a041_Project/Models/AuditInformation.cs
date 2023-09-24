namespace Bsef19a041_Project.Models
{
    public class AuditInformation
    {
        public string? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
