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
using System.Text;
using System.Windows.Forms;
using Ye.JiaHong.Business;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for generating car wash invoice.
    /// </summary>
    public partial class CarWashInvoiceForm : RRCAGJiaHongYe.InvoiceForm
    {
        private BindingSource CarWashSource;

        /// <summary>
        /// Initializes an instance of the car wash invoice form class with design and event subscriptions.
        /// </summary>
        public CarWashInvoiceForm(BindingSource source)
        {
            InitializeComponent();

            this.CarWashSource = new BindingSource();
            this.CarWashSource.DataSource = typeof(CarWashInvoice);
            this.CarWashSource.DataSource = source;

            this.lblInvoiceTitle.Text = "Car Wash Invoice";

            BindControls();
        }

        /// <summary>
        /// Sets the data binding for the form.
        /// </summary>
        private void BindControls()
        {
            Binding packageCostBind = new Binding("Text", this.CarWashSource, "PackageCost");
            this.lblPackagePrice.DataBindings.Add(packageCostBind);

            Binding fragranceCostBind = new Binding("Text", this.CarWashSource, "FragranceCost");
            this.lblFragrancePrice.DataBindings.Add(fragranceCostBind);

            Binding subtotalBind = new Binding("Text", this.CarWashSource, "SubTotal");
            this.lblSubtotal.DataBindings.Add(subtotalBind);

            Binding taxesBind = new Binding("Text", this.CarWashSource, "GoodsAndServicesTaxCharged");
            this.lblTaxes.DataBindings.Add(taxesBind);

            Binding totalBind = new Binding("Text", this.CarWashSource, "Total");
            this.lblTotal.DataBindings.Add(totalBind);

            packageCostBind.FormattingEnabled =
                fragranceCostBind.FormattingEnabled =
                subtotalBind.FormattingEnabled =
                taxesBind.FormattingEnabled =
                totalBind.FormattingEnabled = true;

            packageCostBind.FormatString = "C";
            fragranceCostBind.FormatString = "N2";
            subtotalBind.FormatString = "C";
            taxesBind.FormatString = "N2";
            totalBind.FormatString = "C";
        }
    }
}