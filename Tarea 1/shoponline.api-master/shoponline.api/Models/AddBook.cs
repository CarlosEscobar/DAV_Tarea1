using System;

namespace shoponline.api.Models
{
    public class AddBook
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int AvailableCopies { get; set; }
    }
}
