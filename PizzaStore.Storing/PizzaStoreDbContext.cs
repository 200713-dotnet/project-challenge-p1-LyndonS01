using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;

namespace PizzaStore.Storing
{
  public class PizzaStoreDbContext : DbContext
  {
    public DbSet<PizzaModel> Pizzas { get; set; } //create table
    public DbSet<CrustModel> Crusts { get; set; } //create table
    public DbSet<SizeModel> Sizes { get; set; } //create table
    public DbSet<ToppingModel> Toppings { get; set; } //create table

    public PizzaStoreDbContext(DbContextOptions options) : base(options){} //dependency injection

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PizzaModel>().HasKey(e => e.Id); //primary constraint
      builder.Entity<CrustModel>().HasKey(e => e.Id);
      builder.Entity<SizeModel>().HasKey(e => e.Id);
      builder.Entity<ToppingModel>().HasKey(e => e.Id);
    }
  }
}