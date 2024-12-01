namespace MVCTask1._1.Models
{
    public class Teacher
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
