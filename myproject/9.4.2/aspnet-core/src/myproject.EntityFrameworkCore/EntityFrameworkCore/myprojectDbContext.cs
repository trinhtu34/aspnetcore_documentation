using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using myproject.Authorization.Roles;
using myproject.Authorization.Users;
using myproject.MultiTenancy;
using myproject.Products;

namespace myproject.EntityFrameworkCore
{
    public class myprojectDbContext : AbpZeroDbContext<Tenant, Role, User, myprojectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Product> Products { get; set; }
        
        public myprojectDbContext(DbContextOptions<myprojectDbContext> options)
            : base(options)
        {
        }
    }
}
