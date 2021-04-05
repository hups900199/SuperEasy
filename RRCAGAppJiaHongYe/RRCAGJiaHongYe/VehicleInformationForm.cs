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
using RRCAG.Data;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for showing vehicle information.
    /// </summary>
    public partial class VehicleInformationForm : Form
    {
        private BindingSource vehicleSource;

        /// <summary>
        /// Initializes an instance of the vehicle information form class with design and event subscriptions.
        /// </summary>
        public VehicleInformationForm(Vehicle soucre)
        {
            InitializeComponent();

            this.vehicleSource = new BindingSource();
            this.vehicleSource.DataSource = typeof(Vehicle);
            this.vehicleSource.DataSource = soucre;

            BindControls();

            formatText();

            this.btnClose.Click += CloseButton_Click;
        }

        /// <summary>
        /// Sets the data binding for the form.
        /// </summary>
        private void BindControls()
        {
            Binding stockIDBind = new Binding("Text", this.vehicleSource, "StockID");
            this.lblStockID.DataBindings.Add(stockIDBind);

            Binding yearBind = new Binding("Text", this.vehicleSource, "ManufacturedYear");
            this.lblYear.DataBindings.Add(yearBind);

            Binding manufacturerBind = new Binding("Text", this.vehicleSource, "Manufacturer");
            this.lblManufacturer.DataBindings.Add(manufacturerBind);

            Binding modelBind = new Binding("Text", this.vehicleSource, "Model");
            this.lblModel.DataBindings.Add(modelBind);

            Binding mileageBind = new Binding("Text", this.vehicleSource, "Mileage");
            this.lblMileage.DataBindings.Add(mileageBind);

            Binding colourBind = new Binding("Text", this.vehicleSource, "Colour");
            this.lblColour.DataBindings.Add(colourBind);

            Binding basePriceBind = new Binding("Text", this.vehicleSource, "BasePrice");
            this.lblBasePrice.DataBindings.Add(basePriceBind);

            mileageBind.FormattingEnabled =
                basePriceBind.FormattingEnabled = true;

            mileageBind.FormatString = "N0";
            basePriceBind.FormatString = "C";
        }

        /// <summary>
        /// Formats text into the form.
        /// </summary>
        private void formatText()
        {
            Vehicle vehicle = (Vehicle)this.vehicleSource.DataSource;

            string result = vehicle.IsAutomatic ? "Automatic" : "Manual";

            this.lblTransmission.Text = result;

            this.Text = string.Format(" {0} - {1} {2} {3}",
                                      vehicle.StockID,
                                      vehicle.ManufacturedYear,
                                      vehicle.Manufacturer,
                                      vehicle.Model);
        }

        /// <summary>
        /// Handles the Click event of the close button.
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}