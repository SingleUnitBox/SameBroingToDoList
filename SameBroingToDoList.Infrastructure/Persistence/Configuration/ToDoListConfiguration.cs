using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SameBroingToDoList.Domain.Entities;
using SameBroingToDoList.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Infrastructure.Persistence.Configuration
{
    public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            
        }
        public void ConfigureToDoListTable(EntityTypeBuilder<ToDoList> builder)
        {
            builder.ToTable("ToDoLists");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => ToDoListId.Create(value));

            builder.Property(x => x.Title)
                .HasConversion(
                title => title.Value,
                value => ToDoListTitle.Create(value));

            builder.Property(x => x.AuthorId)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        }

        public void ConfigureToDoListItemsTable(EntityTypeBuilder<ToDoList> builder)
        {
            builder.OwnsMany(x => x.ToDoItems, ib =>
            {
                ib.ToTable("ToDoItems");
                ib.Property<Guid>("Id");
                ib.HasKey("Id", "ToDoListId");
                ib.WithOwner().HasForeignKey("ToDoListId");
                ib.Property(x => x.Title)
                    .HasConversion(
                    title => title.Value,
                    value => ToDoItemTitle.Create(value));

                ib.Property(x => x.Description)
                    .HasConversion(
                        description => description.Value,
                        value => ToDoItemDescription.Create(value));
            });

            builder.Metadata.FindNavigation(nameof(ToDoList.ToDoItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
