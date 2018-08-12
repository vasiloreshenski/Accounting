namespace Accounting.DesktopClient.IoC
{
    using Accounting.DesktopClient.Navigation;
    using Accounting.DesktopClient.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;
    using Accounting.Core.External_Services;
    using Accounting.Data;

    internal static class IoC
    {
        public static IUnityContainer CreateContainer(MasterWindow masterWindow)
        {
            var container = new UnityContainer();
            container.RegisterInstance(masterWindow);
            container.RegisterSingleton<INavigation, Navigation>();
            container.RegisterSingleton<IDatabase, Database>();
            container.RegisterSingleton<ITextPicker, UserInputTextPicker>();
            container.RegisterSingleton<ApplicantsControl>();
            
            return container;
        }
    }
}
