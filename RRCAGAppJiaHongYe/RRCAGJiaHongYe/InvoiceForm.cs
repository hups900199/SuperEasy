/*
 * Name: Jia Hong Ye
 * Program: Business Information Technology
 * Course: ADEV-2008 (202306) Programming 2
 * Created: 2021-04-01
 * Updated: 2021-04-04
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for generating invoice.
    /// </summary>
    public partial class InvoiceForm : Form
    {
        /// <summary>
        /// Initializes an instance of the invoice form class with design and event subscriptions.
        /// </summary>
        public InvoiceForm()
        {
            InitializeComponent();

            LabelInitialize();
        }

        /// <summary>
        /// Initializes the label setting.
        /// </summary>
        private void LabelInitialize()
        {
            this.lblCompanyName.Text = "RRC Automotive Group";
            this.lblAddress.Text = "777 Inheritance Drive";
            this.lblLocation.Text = "Winnipeg, Manitoba, I0I 0I0";
            this.lblPhone.Text = "204-867-5309";
            this.lblInvoiceTitle.Text = "[Invoice title]";
            this.lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}