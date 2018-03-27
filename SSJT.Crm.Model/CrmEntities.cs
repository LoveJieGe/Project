using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SSJT.Crm.Model
{
    public class CrmEntities:DbContext
    {
        public CrmEntities() : base("name=CrmEntity")
        {
            //Database.SetInitializer(new Initializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<HrEmploy> HrEmploy { get; set; }
        public DbSet<PersonalNote> PersonalNote { get; set; }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<CrmEntities>
    {
        protected override void Seed(CrmEntities context)
        {
            context.HrEmploy.Add(new HrEmploy
            {
                UserID="Admin",
                UserName="管理员",
                PassWord= "WW+KDTUrwwA=",
                IsRoot="Y",
                CanLogin="Y",
                AvatarName= "Admin_screen.png"
            });
        }
    }
}
