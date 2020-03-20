using System;
using Ninject;
using Ninject.Modules;
using Selenium.Data.Repository.Interfaces;
using Selenium.Data.SeleniumDataRepository;
using Selenium.Data.SeleniumDataRepository.Interfaces;

namespace Selenium.Web.Tests.Services
{
   public class NinjectCommon : NinjectModule
   {
      /// <summary>
      /// Creates the kernel that will manage your application.
      /// </summary>
      /// <returns>The created kernel.</returns>
      public static IKernel CreateKernel()
      {
         StandardKernel kernel = new StandardKernel();
         try
         {
            RegisterDependencies(kernel);
            return kernel;
         }
         catch
         {
            kernel.Dispose();
            throw;
         }
      }

      public override void Load()
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Load your modules or register your dependencies here
      /// </summary>
      /// <param name="kernel">The kernel.</param>
      public static void RegisterDependencies(IKernel kernel)
      {
         kernel.Bind<IUnitOfWork>().To<SeleniumDataContext>().InTransientScope();
         kernel.Bind<IConfigurationRepository>().To<ConfigurationRepository>().InTransientScope();
      }
   }
}
