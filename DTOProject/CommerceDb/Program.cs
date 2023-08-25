using Microsoft.EntityFrameworkCore;
using CommerceDb.Entities;
using System.Collections.Generic;



public class CommerceDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Database=CommerceDb;Integrated Security=True;;Encrypt=False;Trust Server Certificate=False;");
    }
}

class Start
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}