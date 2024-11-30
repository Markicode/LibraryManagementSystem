﻿using LibraryEmployeeApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalApplicationVariables;
using Controllers;

namespace EmployeeApplication
{
    public partial class EmployeeManageEmployeesForm : Form
    {
        private EmployeeMainForm parentForm;
        public EmployeeController employeeController;
        private int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        public EmployeeManageEmployeesForm(EmployeeMainForm parentForm, AuthController authController)
        {
            InitializeComponent();
            GoFullscreen(true);
            this.parentForm = parentForm;
            HomeLabel.Font = Style.menuFont;
            HomeLabel.ForeColor = Style.purpleColor;
            this.employeeController = new EmployeeController(parentForm.user);
            EmployeesGridView.Location = new System.Drawing.Point(12, HomeLabel.Height + 18);
            EmployeesGridView.Size = new System.Drawing.Size(screenWidth - 20, screenHeight - HomeLabel.Height - InspectEmployeeButton.Height - 40);
            InspectEmployeeButton.Location = new System.Drawing.Point(12, screenHeight - InspectEmployeeButton.Height - 10);
            AddEmployeeButton.Location = new System.Drawing.Point(12 + InspectEmployeeButton.Width + 12, screenHeight - AddEmployeeButton.Height - 10);
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void OpenEmployeeForm(string mode)
        {
            EmployeeSingleEmployeeForm employeeSingleEmployeeForm = new(mode, parentForm.authController, this.employeeController);
            employeeSingleEmployeeForm.ShowDialog();
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void HomeLabel_MouseEnter(object sender, EventArgs e)
        {
            HomeLabel.Font = Style.hoverMenuFont;
        }

        private void HomeLabel_MouseLeave(object sender, EventArgs e)
        {
            HomeLabel.Font = Style.menuFont;
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            this.OpenEmployeeForm("add");
        }

        private void InspectEmployeeButton_Click(object sender, EventArgs e)
        {
            this.OpenEmployeeForm("inspect");
        }
    }
}
