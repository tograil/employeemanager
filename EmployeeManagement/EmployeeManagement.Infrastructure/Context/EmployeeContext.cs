using EmployeeManagement.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Context;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Employee>("Employee")
            .HasValue<Manager>("Manager")
            .HasValue<Supervisor>("Supervisor");

        modelBuilder.Entity<Person>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Person>()
            .Property(p => p.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.Address)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.PayPerHour)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        modelBuilder.Entity<Manager>()
            .Property(m => m.AnnualSalary)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        modelBuilder.Entity<Manager>()
            .Property(m => m.MaxExpenseAmount)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        modelBuilder.Entity<Supervisor>()
            .Property(s => s.AnnualSalary)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}