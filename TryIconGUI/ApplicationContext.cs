﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using MyForm.View;
using TryIconGUI.Properties;

namespace TryIconGUI
{
    public class CustomApplicationContext : ApplicationContext
    {
        public CustomApplicationContext()
        {
            InitializeContext();
            _trayIcon.Icon = Properties.Resources.Icon1;
            _trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _trayIcon.ContextMenuStrip.Items.Add("Show &Details", null, click);
            _trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

#if DEBUG
            OpenForm(); 
#endif
        }

        private void InitializeContext()
        {
            var components = new System.ComponentModel.Container();

            _trayIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Resources.Icon1,
                Text = Resources.IconToolTip,
                Visible = true
            };
        }

        private void click(object sender, EventArgs e)
        {
            OpenForm();
        }

        private static void OpenForm()
        {
            var form = new MainWindow();

            ElementHost.EnableModelessKeyboardInterop(form);
            form.Show();
        }


        #region Implementation
        NotifyIcon _trayIcon;
        #endregion
    }
}
