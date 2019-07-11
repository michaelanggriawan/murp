using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MURP
{
    public abstract partial class TemplateWindow : Window
    {
        private Button ButtonOpenMenu;
        private Button ButtonCloseMenu;
        private Button ButtonPopUpLogout;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            #region UI Core
            ButtonOpenMenu = GetTemplateChild("ButtonOpenMenu") as Button;
            ButtonCloseMenu = GetTemplateChild("ButtonCloseMenu") as Button;
            ButtonPopUpLogout = GetTemplateChild("ButtonPopUpLogout") as Button;

            ButtonOpenMenu.Click += ButtonOpenMenu_Click;
            ButtonCloseMenu.Click += ButtonCloseMenu_Click;
            ButtonPopUpLogout.Click += ButtonPopUpLogout_Click;
            #endregion

            #region Menu
            ListViewItem HomeItem = GetTemplateChild("Home_Select") as ListViewItem;
            ListViewItem DosenItem = GetTemplateChild("Dosen_Select") as ListViewItem;
            ListViewItem KelasItem = GetTemplateChild("Kelas_Select") as ListViewItem;

            HomeItem.Selected += Home_Selected;
            KelasItem.Selected += Kelas_Selected;
            #endregion
        }

        private void ButtonPopUpLogout_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, EventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, EventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void Home_Selected(object sender, EventArgs e)
        {
            //IZIN.Core.Helpers.WindowHelper.SwitchWindow(new MainWindow());
        }

        private void Kelas_Selected(object sender, EventArgs e)
        {
            //IZIN.Core.Helpers.WindowHelper.SwitchWindow(new Views.Kelas.KelasWindow());
        }
    }
}
