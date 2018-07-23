using Accounting.DesktopClient.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace Accounting.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        private readonly IUnityContainer container;
        private readonly INavigation navigation;

        public MasterWindow()
        {
            InitializeComponent();

            this.container = IoC.IoC.CreateContainer(this);
            this.navigation = this.container.Resolve<INavigation>();

            this.Closed += MasterWindow_Closed;
        }

        private void MasterWindow_Closed(object sender, EventArgs e)
        {
            this.container.Dispose();
        }

        private void NavigateToApplicantsButton_Click(object sender, RoutedEventArgs e)
        {
            this.navigation.GoToApplicants();
        }

        private void NavigateToProvidersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToApplicationsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToRequestsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToCheckListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToContractsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
