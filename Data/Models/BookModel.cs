using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Data.Models;

[Table("Books")]
public class BookModel
{
    [Column("ISBN")] 
    public int ISBN { get; }
    [Column("Name")] 
    public string Name { get; }
    [Column("Author")] 
    public string Author { get; }
}