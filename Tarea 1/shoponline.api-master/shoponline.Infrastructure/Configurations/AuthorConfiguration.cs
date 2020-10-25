using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shoponline.Core.Entities;

namespace shoponline.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);

            builder.Property(author => author.Id).ValueGeneratedOnAdd();

            builder.HasMany<Book>(author => author.Books).WithOne(book => book.Author).HasForeignKey(book => book.AuthorId);
        }
    }
}
