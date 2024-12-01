namespace AspFirstTemplate.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public ICollection<Work> Works { get; set; }
    }
}
