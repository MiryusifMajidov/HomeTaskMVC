namespace FinalApojectTest4.Model.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }

}
