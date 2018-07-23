namespace Accounting.DesktopClient.Navigation
{
    using Accounting.DesktopClient.UI.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Navigation : INavigation
    {
        private readonly MasterWindow masterWindow;
        private readonly Lazy<ApplicantsControl> applicantsPage;

        public Navigation(MasterWindow masterWindow, Lazy<ApplicantsControl> applicantsPage)
        {
            this.masterWindow = masterWindow;
            this.applicantsPage = applicantsPage;
        }

        public void GoToApplicants()
        {
            this.masterWindow.Content.Children.Clear();
            this.masterWindow.Content.Children.Add(this.applicantsPage.Value);
        }
    }
}
