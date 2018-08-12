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
        private readonly AccountingApi api;
        private readonly ITextPicker textPicker;

        public ApplicantsControl()
        {
            this.Applicants = new ObservableCollection<Applicant>();

            this.InitializeComponent();
        }

        public ApplicantsControl(AccountingApi api, ITextPicker textPicker) : this()
        {
            this.api = api;
            this.textPicker = textPicker;
        }

        public ObservableCollection<Applicant> Applicants { get; }
        public Applicant Selected { get; set; }

        public void OnNavigated()
        {
            this.RefereshApplicantsFromDatabaseAsync();
        }

        private async void MenuItemRemoveSelcted_Click(object sender, RoutedEventArgs e)
        {
            if (this.Selected != null)
            {
                await this.api.DeleteApplicantAsync(this.Selected);

                this.Applicants.Remove(this.Selected);
            }
        }

        private async void MenuItemEditSelected_Click(object sender, RoutedEventArgs e)
        {
            if (this.Selected != null && this.textPicker.PickText(this.Selected.Name) is String picked)
            {
                this.Selected.Name = picked;

                await this.api.UpdateApplicantAsync(this.Selected);

                this.RefereshApplicantsFromDatabaseAsync();
            }
        }


        private async Task RefereshApplicantsFromDatabaseAsync()
        {
            this.Applicants.Clear();

            var applicants = await this.api.GetApplicantsAsync();

            this.Applicants.AddRange(applicants);
        }

        private async void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            if (this.textPicker.PickText() is String name)
            {
                var applicant = new Applicant(0, name);

                await this.api.InsertApplicantAsync(applicant);

                this.RefereshApplicantsFromDatabaseAsync();
            }
        }
    }
}
