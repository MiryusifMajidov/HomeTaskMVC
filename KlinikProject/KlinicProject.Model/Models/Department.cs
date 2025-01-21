namespace KlinicProject.Model.Models
{
    public class Department:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
