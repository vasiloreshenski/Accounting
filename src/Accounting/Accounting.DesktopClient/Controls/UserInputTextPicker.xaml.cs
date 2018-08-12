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
using System.Windows.Shapes;

namespace Accounting.DesktopClient.Controls
{
    /// <summary>
    /// Interaction logic for UserInputTextPicker.xaml
    /// </summary>
    public partial class UserInputTextPicker : Window, ITextPicker
    {
        private bool? picked;

        public UserInputTextPicker()
        {
            InitializeComponent();
        }

        public string PickText()
        {
            return this.PickText(null);
        }

        public string PickText(string origin)
        {
            this.TextBoxUserInput.Focus();
            
            this.TextBoxUserInput.SelectedText = origin ?? String.Empty;

            this.ShowDialog();

            if (this.picked == true)
            {
                return this.TextBoxUserInput.Text ?? String.Empty;
            }

            return null;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            this.picked = true;

            this.Hide();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.picked = false;

            this.Hide();
        }
    }
}
