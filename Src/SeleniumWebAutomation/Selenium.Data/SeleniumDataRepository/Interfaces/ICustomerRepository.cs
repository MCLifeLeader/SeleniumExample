using System;
using System.Linq;
using System.Threading.Tasks;
using Selenium.Data.Repository.Interfaces;
using Selenium.Data.SeleniumDataRepository.Models;

namespace Selenium.Data.SeleniumDataRepository.Interfaces
{
   public interface IConfigurationRepository : IRepository<Configuration, Guid>, IDisposable
   {
      new IQueryable<Configuration> GetAsQueryable();

      Configuration GetEntityByKey(string email);
      Task<Configuration> GetEntityByKeyAsync(string email);
   }
}
