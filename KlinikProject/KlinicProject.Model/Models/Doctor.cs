namespace KlinicProject.Model.Models
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
