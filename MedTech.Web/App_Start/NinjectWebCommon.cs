[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MedTech.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MedTech.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MedTech.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using MedTech.Core.Data;
    using MedTech.Infrastructure;
    using MedTech.Application.Services.Categories;
    using MedTech.Application.Services.CompanyInfo;
    using MedTech.Application.Services.Membership;
    using MedTech.Application.Services.Authentication;
    using System.Web.Http;
    

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //Suport WebAPI Injection
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //data layer 
            kernel.Bind<IDbContext>().To<MedTechObjectContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>)).InRequestScope();

            //service
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICompanyInfoService>().To<CompanyInfoService>();
            kernel.Bind<IMembershipService>().To<MembershipService>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();

        }        
    }
}
