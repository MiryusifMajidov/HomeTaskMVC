namespace MVCTask1._1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; } 

        public Group Group { get; set; }
    }
}
