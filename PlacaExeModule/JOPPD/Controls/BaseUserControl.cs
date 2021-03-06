﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JOPPD.Controls
{
    public class BaseUserControl : System.Windows.Forms.UserControl
    {
        public FormUserControlContainer ContainerForm { get; set; }

        public BaseUserControl()
        {
            this.ContainerForm = new FormUserControlContainer();
            this.ContainerForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.ContainerForm.ShowInTaskbar = false;
            this.ContainerForm.MaximizeBox = false;

            this.ContainerForm.Controls.Add(this);
        }

        protected DialogResult ShowDialog(string title, BaseUserControl userControl)
        {
            if (!string.IsNullOrEmpty(title))
                this.ContainerForm.Text = title;

            this.ContainerForm.Size = this.Size;
            
            return this.ContainerForm.ShowDialog();
        }
    }
}
