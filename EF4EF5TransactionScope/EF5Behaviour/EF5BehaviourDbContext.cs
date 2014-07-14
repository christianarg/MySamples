using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.EF5Behaviour
{
    public class EF5BehaviourDbContext : DbContext
    {
        public DbSet<Master> MasterModel { get; set; }
    }

    public class Master
    {
        public int Id { get; set; }
        public virtual List<Detail> Details { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
    }
}
