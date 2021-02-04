using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NET5Udemy.Model.Context
{
    public class SQLServerContext : DbContext
    {

        public SQLServerContext() { }

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
