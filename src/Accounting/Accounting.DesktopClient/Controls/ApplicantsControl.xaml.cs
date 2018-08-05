namespace Accounting.DesktopClient.Controls
{
    using Accounting.Core;
    using Accounting.Core.External_Services;
    using Accounting.Core.Models;
    using Accounting.DesktopClient.Common;
    using Accounting.DesktopClient.Internal_Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

    /// <summary>
    /// Interaction logic for ApplicantsPage.xaml
    /// </summary>
    public partial class ApplicantsControl : UserControl, INavigated
    {
        public readonly AccountingApi api;

        public ApplicantsControl()
        {
            this.Applicants = new ObservableCollection<Applicant>();

            this.InitializeComponent();
        }

        public ApplicantsControl(AccountingApi api) : this()
        {
            this.api = api;
        }

        public ObservableCollection<Applicant> Applicants { get; }

        public async void OnNavigated()
        {
            this.Applicants.Clear();

            var applicants = await this.api.GetApplicantsAsync();

            this.Applicants.AddRange(applicants);
        }
    }
}
