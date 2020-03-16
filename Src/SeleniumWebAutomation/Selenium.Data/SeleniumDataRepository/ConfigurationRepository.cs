using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Selenium.Data.Repository.Interfaces;
using Selenium.Data.SeleniumDataRepository.Interfaces;
using Selenium.Data.SeleniumDataRepository.Models;

namespace Selenium.Data.SeleniumDataRepository
{
   public class ConfigurationRepository : SeleniumDataBaseRepository, IConfigurationRepository
   {
      private static readonly ILog _logger = LogManager.GetLogger(typeof(ConfigurationRepository));

      public ConfigurationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      public Configuration GetEntityById(Guid key)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         return _context.Configurations.FirstOrDefault(e => e.Id == key);
      }

      public IList<Configuration> GetAll()
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         return _context.Configurations.ToList();
      }

      public async Task<IList<Configuration>> GetAllAsync()
      {
         return await _context.Configurations.ToListAsync();
      }

      public IQueryable<Configuration> Query(Expression<Func<Configuration, bool>> filter)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         return _context.Configurations.Where(filter);
      }

      IQueryable<Configuration> IConfigurationRepository.GetAsQueryable()
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         return _context.Configurations.AsQueryable();
      }

      public Configuration GetEntityByKey(string key)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         return _context.Configurations.FirstOrDefault(m => string.Compare(m.Key, key, StringComparison.CurrentCultureIgnoreCase) == 0);
      }

      public async Task<Configuration> GetEntityByKeyAsync(string key)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);
         
         return await _context.Configurations.FirstOrDefaultAsync(m => string.Compare(m.Key, key, StringComparison.CurrentCultureIgnoreCase) == 0);
      }

      IQueryable<Configuration> ILookupRepository<Configuration, Guid>.GetAsQueryable()
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         throw new NotImplementedException();
      }

      public void Add(Configuration entity)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         _context.Configurations.Add(entity);
      }

      public void Delete(Configuration entity)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         _context.Configurations.Remove(entity);
      }

      public void AddOrUpdate(Configuration entity)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         _context.Configurations.AddOrUpdate(e => e.Id, entity);
      }
   }
}
