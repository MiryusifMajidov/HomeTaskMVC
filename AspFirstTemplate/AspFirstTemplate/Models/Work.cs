namespace AspFirstTemplate.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BigDescription { get; set; }
        public string Image { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
