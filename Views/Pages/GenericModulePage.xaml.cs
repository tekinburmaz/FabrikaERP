using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class GenericModulePage : UserControl
    {
        public GenericModulePage()
        {
            InitializeComponent();
        }

        public GenericModulePage(string title, string icon, string description) : this()
        {
            TxtTitle.Text = title;
            TxtIcon.Text = icon;
            TxtDescription.Text = description;
        }
    }
}
