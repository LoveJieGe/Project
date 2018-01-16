using System.Data.Entity;

namespace SSJT.Crm.Model
{
    public partial class CrmEntities:DbContext
    {
        public CrmEntities() : base("name=CrmEntity")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        DbSet<HrEmployee> HrEmployee { get; set; }
    }
}
