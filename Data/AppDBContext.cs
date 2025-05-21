using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataApp.Data;

public class AppDbContext : DbContext 
{
    public DbSet<Employee> Employees { get; set; }

    ProtectedBrowserStorage override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Insert DB Connection String");
    }
}