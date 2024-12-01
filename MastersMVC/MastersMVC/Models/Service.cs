namespace MastersMVC.Models
{
    public class Service:BaseEntity
    {
        //Id, Title, Description,IsActive, Masters, CreatedAt, UpdatedAt
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Master> Masters { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
