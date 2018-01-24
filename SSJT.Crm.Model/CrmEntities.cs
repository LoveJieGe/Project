using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SSJT.Crm.Model
{
    public class CrmEntities:DbContext
    {
        public CrmEntities() : base("name=CrmEntity")
        {
            //Database.SetInitializer<CrmEntities>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<HrEmploy> HrEmployee { get; set; }
    }
}
