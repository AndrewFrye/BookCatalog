using BookCatalog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data.Contexts;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public DbSet<BookModel> Books { get; set; }

    public string DbPath { get; }
}