namespace Accounting.DesktopClient.IoC
{
    using Accounting.DesktopClient.Navigation;
    using Accounting.DesktopClient.UI.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    internal static class IoC
    {
        public static IUnityContainer CreateContainer(MasterWindow masterWindow)
        {
            var container = new UnityContainer();
            container.RegisterInstance(masterWindow);
            container.RegisterSingleton<INavigation, Navigation>();
            container.RegisterSingleton<ApplicantsControl>();

            return container;
        }
    }
}
