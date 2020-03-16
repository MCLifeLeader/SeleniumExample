using Selenium.Data.Repository;
using Selenium.Data.Repository.Interfaces;

namespace Selenium.Data.SeleniumDataRepository
{
   public abstract class SeleniumDataBaseRepository : RepositoryBase<SeleniumDataContext>
   {
      protected SeleniumDataBaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }
   }
}
