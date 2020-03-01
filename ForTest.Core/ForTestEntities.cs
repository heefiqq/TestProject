using ForTest.Core.Models;
using System.Data.Entity;

namespace ForTest.Core
{
    public class forTestEntities : DbContext
    {
        public forTestEntities() : base("name=forTestEntities")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
    }
}
