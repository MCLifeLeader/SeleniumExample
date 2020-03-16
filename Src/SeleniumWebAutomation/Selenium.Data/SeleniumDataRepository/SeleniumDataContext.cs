using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using log4net;
using Selenium.Data.Repository.Interfaces;

namespace Selenium.Data.SeleniumDataRepository
{
   public class SeleniumDataContext : SeleniumDataContainer, IUnitOfWork
   {
      private static readonly ILog _logger = LogManager.GetLogger(typeof(SeleniumDataContainer));

      public SeleniumDataContext()
      {
#if DEBUG
         this.Database.Log = DebugOutput;
#endif
      }

#if DEBUG
      public static void DebugOutput(string value)
      {
         Debug.WriteLine(value);
      }
#endif

      /// <summary>
      /// Saves this instance.
      /// </summary>
      public void Save()
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            SaveChanges();
         }
         catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
         {
            _logger.Fatal(dbEx.Message, dbEx);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} : \r\n", dbEx.Message);

            foreach (var errors in dbEx.EntityValidationErrors)
            {
               sb.AppendFormat("\r\nValidation Errors for - {0} : [\r\n", errors.Entry.Entity);
               foreach (var error in errors.ValidationErrors)
               {
                  sb.AppendFormat("Message : {0} - Propterty : {1}\r\n", error.ErrorMessage, error.PropertyName);
               }
               sb.Append("]\r\n");
            }

            _logger.Fatal(sb.ToString());

            throw;
         }
         catch (Exception ex)
         {
            _logger.Fatal(ex.Message, ex);

            throw;
         }
      }

      /// <summary>
      /// Reloads the specified entity.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <param name="entity">The entity.</param>
      public void Reload<TEntity>(TEntity entity) where TEntity : class
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            Entry(entity).Reload();
         }
         catch (Exception ex)
         {
            _logger.Debug(ex);
         }
      }

      /// <summary>
      /// Clears the state.
      /// </summary>
      /// <typeparam name="TEntity">The type of the entity.</typeparam>
      /// <param name="entity">The entity.</param>
      public void ClearState<TEntity>(TEntity entity) where TEntity : class
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         try
         {
            Entry(entity).CurrentValues.SetValues(Entry(entity).OriginalValues);
         }
         catch (Exception ex)
         {
            _logger.Debug(ex);
         }

         try
         {
            Entry(entity).Reload();
         }
         catch (Exception ex)
         {
            _logger.Debug(ex);
         }

         try
         {
            Entry(entity).State = EntityState.Unchanged;
         }
         catch (Exception ex)
         {
            _logger.Debug(ex);
         }
      }

      /// <summary>
      /// Sets the database context configuration automatic detect changes.
      /// </summary>
      /// <param name="setAutoDetect">if set to <c>true</c> [set automatic detect].</param>
      public void SetDbContextConfigurationAutoDetectChanges(bool setAutoDetect)
      {
         _logger.DebugFormat("Method {0} called", MethodBase.GetCurrentMethod().Name);

         Configuration.AutoDetectChangesEnabled = setAutoDetect;
      }
   }
}
