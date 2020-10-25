using System;

namespace shoponline.api.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public int AvailableCopies { get; set; }
    }
}
