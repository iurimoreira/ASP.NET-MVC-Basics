using Livraria.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;

namespace Livraria
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<ILivroRepository, LivroRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}