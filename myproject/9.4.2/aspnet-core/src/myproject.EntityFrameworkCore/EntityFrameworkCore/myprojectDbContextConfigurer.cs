using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace myproject.EntityFrameworkCore
{
    public static class myprojectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<myprojectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<myprojectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
