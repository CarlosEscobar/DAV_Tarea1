using System;

namespace shoponline.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int AvailableCopies { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}