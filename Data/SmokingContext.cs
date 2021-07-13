using Microsoft.EntityFrameworkCore;
using smoking_meat_api.Models;

namespace smoking_meat_api.Data
{
    public class SmokingContext : DbContext
    {
        public SmokingContext(DbContextOptions<SmokingContext> opt) : base(opt)
        {

        }

        // set up the map down to the database
        public DbSet<Instruction> Instructions { get; set; }


    }
}