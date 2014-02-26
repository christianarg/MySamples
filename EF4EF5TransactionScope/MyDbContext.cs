using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class MyDbEntity
    {
        [Key]
        public string Id { get; set; }
        public string TheProperty { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbConnection connection)
            :base(connection,false)
        {
             
        }
        public MyDbContext() :base(){ }
        //public MyDbContext(ObjectContext context)
        //    : base(context,false)
        //{
        //}
        public DbSet<MyDbEntity> MyDbEntities { get; set; }
    }
}
