[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AspImpactaBiblioteca.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AspImpactaBiblioteca.App_Start.NinjectWebCommon), "Stop")]

namespace AspImpactaBiblioteca.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Context;
    using Models.Interfaces;
    using Models.Implementation;
    using Helpers.Interfaces;
    using Helpers;
    using Generics;

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
            // Configura��o do contexto. A Inje��o de Dependencia � configurada para ser utilizada apenas o mesmo contexto para todas.
            kernel.Bind<BibliotecaContext>().ToSelf().InRequestScope();

            // Mostrando para o Ninject quais s�o as classes respectivas para cada Interface, para que o mesmo crie uma instancia da classe concreta
            kernel.Bind<IAutorRepository>().To<AutorRepository>();
            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IEmprestimoRepository>().To<EmprestimoRepository>();
            kernel.Bind<IFormaPagamentoRepository>().To<FormaPagamentoRepository>();
            kernel.Bind<ILivroRepository>().To<LivroRepository>();
            kernel.Bind<IPagamentoRepository>().To<PagamentoRepository>();           

            // Classe SEPARADA das respons�veis pelo CRUD e Controllers(Autor, Categoria e etc).
            kernel.Bind<IRetornaSelectListItemRepository>().To<RetornaSelectListItemRepository>();
        }        
    }
}
