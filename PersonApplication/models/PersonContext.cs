using Microsoft.EntityFrameworkCore;
using testCRM.models;

namespace testCRM.models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
        }
        public DbSet<Person> People { get; set; }
    }
}