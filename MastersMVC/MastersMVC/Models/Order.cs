namespace MastersMVC.Models
{
    public class Order:BaseEntity
    {
        // Id, ClientName, ClientSurname, ClientPhoneNumber, ClientEmail, ServiceId, MasterId, Problem, IsActive, CreatedAt, UpdatedAt
        
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
        public string Problem { get; set; }
        public bool IsActive { get; set; }
        public int ServiceId { get; set; }
        public int MasterId { get; set; }
        public Service Service { get; set; }
        public Master Master { get; set; }

    }
}
