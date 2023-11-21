using Microsoft.EntityFrameworkCore;
using TrailNetApiChallenge.Models;

namespace TrailNetApiChallenge.Context
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}