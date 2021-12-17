using System.Data.Entity;
using Selenium.Data.SeleniumDataRepository.Models;

namespace Selenium.Data.SeleniumDataRepository
{
   public partial class SeleniumDataContainer : DbContext
   {
      public SeleniumDataContainer()
          : base("name=SeleniumData")
      {
      }

      public virtual DbSet<Configuration> Configurations { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
      }
   }
}
