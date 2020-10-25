using System.Collections.Generic;

namespace shoponline.Core.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}