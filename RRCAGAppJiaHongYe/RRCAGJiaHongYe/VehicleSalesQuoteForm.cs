/*
 * Name: Jia Hong Ye
 * Program: Business Information Technology
 * Course: ADEV-2008 (202306) Programming 2
 * Created: 2021-03-23
 * Updated: 2021-04-04
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RRCAGLibrary;
using Ye.JiaHong.Business;
using RRCAG.Data;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for making vehicle sales quote.
    /// </summary>
    public partial class VehicleSalesQuoteForm : Form
    {
        private SalesQuote salesQuote;
        private BindingSource salesQuoteSource;
        private BindingSource vehiclesSource;
        private BindingList<Vehicle> vehicles;

        /// <summary>
        /// Initializes an instance of the vehicle sales quote form class with design and event subscriptions.
        /// </summary>
        public VehicleSalesQuoteForm()
        {
            InitializeComponent();

            SummaryInitialize();

            this.vehicles = new BindingList<Vehicle>(DataRetriever.GetVehicles());

            this.salesQuoteSource = new BindingSource();
            this.salesQuoteSource.DataSource = typeof(SalesQuote);

            this.vehiclesSource = new BindingSource();
            this.vehiclesSource.DataSource = this.vehicles;

            BindControls();

            // ComboBox Event
            this.cboVehicle.SelectedIndexChanged += VehicleComboBox_SelectedIndexChanged;

            // TextBox Event
            this.txtTradeInValue.TextChanged += TradeInValueTextBox_TextChanged;

            // CheckBox Events
            this.chkStereoSystem.CheckedChanged += SettingChanged;
            this.chkLeatherInterior.CheckedChanged += SettingChanged;
            this.chkComputerNavigation.CheckedChanged += SettingChanged;

            // RadioButton Events
            this.radStandard.CheckedChanged += SettingChanged;
            this.radPearlized.CheckedChanged += SettingChanged;
            this.radCustomizedDetailing.CheckedChanged += SettingChanged;

            // NumericUpDown Events
            this.nudAnnualInterestRate.ValueChanged += SettingChanged;
            this.nudNumberOfYear.ValueChanged += SettingChanged;

            // Button Events
            this.btnCalculateQuote.Click += CalculateQuoteButton_Click;
            this.btnReset.Click += ResetButton_Click;

            // Menu Event
            this.mnuViewVehicleInformation.Click += MnuViewVehicleInformation_Click;
            this.mnuFileClose.Click += MnuFileClose_Click;
        }

        /// <summary>
        /// Sets the data binding for the form.
        /// </summary>
        private void BindControls()
        {
            this.cboVehicle.DataSource = this.vehiclesSource;

            this.cboVehicle.DisplayMember = "StockID";

            this.cboVehicle.ValueMember = "BasePrice";

            this.cboVehicle.SelectedItem = null;

            Binding vehicleSalePriceBind = new Binding("Text", this.salesQuoteSource, "VehicleSalePrice");
            this.lblSummaryVehicleSalePrice.DataBindings.Add(vehicleSalePriceBind);

            Binding subtotalBind = new Binding("Text", this.salesQuoteSource, "SubTotal");
            this.lblSummarySubtotal.DataBindings.Add(subtotalBind);

            Binding salesTaxBind = new Binding("Text", this.salesQuoteSource, "SalesTax");
            this.lblSummarySaleTax.DataBindings.Add(salesTaxBind);

            Binding totalBind = new Binding("Text", this.salesQuoteSource, "Total");
            this.lblSummaryTotal.DataBindings.Add(totalBind);

            Binding tradeInAmountBind = new Binding("Text", this.salesQuoteSource, "TradeInAmount");
            this.lblSummaryTradeIn.DataBindings.Add(tradeInAmountBind);

            Binding amountDueBind = new Binding("Text", this.salesQuoteSource, "AmountDue");
            this.lblSummaryAmountDue.DataBindings.Add(amountDueBind);

            vehicleSalePriceBind.FormattingEnabled =
                subtotalBind.FormattingEnabled =
                salesTaxBind.FormattingEnabled =
                totalBind.FormattingEnabled =
                tradeInAmountBind.FormattingEnabled =
                amountDueBind.FormattingEnabled = true;

            vehicleSalePriceBind.FormatString = "C";
            subtotalBind.FormatString = "C";
            salesTaxBind.FormatString = "N";
            totalBind.FormatString = "C";
            tradeInAmountBind.FormatString = "-#";
            amountDueBind.FormatString = "C";
        }

        /// <summary>
        /// Initializes the summary setting.
        /// </summary>
        private void SummaryInitialize()
        {
            this.salesQuote = null;

            this.lblSummaryVehicleSalePrice.Text =
                this.lblSummaryOptions.Text =
                this.lblSummarySubtotal.Text = 
                this.lblSummarySaleTax.Text =
                this.lblSummaryTotal.Text =
                this.lblSummaryTradeIn.Text =
                this.lblSummaryAmountDue.Text =
                this.lblMonthlyPayment.Text = string.Empty;
        }

        /// <summary>
        /// Updates the options including accessories and exterior finish.
        /// </summary>
        private void OptionsUpdated()
        {
            CheckBox[] checkBoxes = {this.chkStereoSystem, this.chkLeatherInterior, this.chkComputerNavigation};
            RadioButton[] radioButtons = {this.radStandard, this.radPearlized, this.radCustomizedDetailing};

            // Checks accessories
            int checkNumber = 0;
            int checkID = 1;

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    checkNumber += checkID;
                }

                checkID += 2;
            }

            if (checkNumber < 2)
            {
                this.salesQuote.AccessoriesChosen = (Accessories)checkNumber;
            }
            else if (checkNumber > 2 && checkNumber < 7)
            {
                checkNumber -= 1;
                this.salesQuote.AccessoriesChosen = (Accessories)checkNumber;
            }
            else
            {
                checkNumber -= 2;
                this.salesQuote.AccessoriesChosen = (Accessories)checkNumber;
            }

            // Checks exterior finish
            checkNumber = 0;
            checkID = 1;

            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked)
                {
                    checkNumber += checkID;
                }

                checkID += 1;
            }

            this.salesQuote.ExteriorFinishChosen = (ExteriorFinish)checkNumber;

            this.lblSummaryOptions.Text = (this.salesQuote.AccessoryCost + this.salesQuote.FinishCost).ToString("N");

            this.lblMonthlyPayment.Text = (Financial.GetPayment(this.nudAnnualInterestRate.Value * 0.01M, (int)this.nudNumberOfYear.Value, salesQuote.AmountDue) / 12).ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Handles the setting changed event.
        /// </summary>
        private void SettingChanged(object sender, EventArgs e)
        {
            SummaryUpdated();
        }

        /// <summary>
        /// Updates the summary.
        /// </summary>
        private void SummaryUpdated()
        {
            if (this.salesQuote != null)
            {
                OptionsUpdated();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the vehicle ComboBox.
        /// </summary>
        private void VehicleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.salesQuote != null)
            {
                SummaryInitialize();
            }

            this.mnuViewVehicleInformation.Enabled = true;
        }

        /// <summary>
        /// Handles the TextChanged event of the trade in value TextBox.
        /// </summary>
        private void TradeInValueTextBox_TextChanged(object sender, EventArgs e)
        {
            SummaryInitialize();
        }

        /// <summary>
        /// Handles the Click event of the calculate quote Button.
        /// </summary>
        private void CalculateQuoteButton_Click(object sender, EventArgs e)
        {
            int vehicleError = 0;
            int tradeInError = 0;

            decimal vehicleSalePrice = 0;
            decimal tradeInValue = 0;
            decimal saleTaxRate = 0.13M;

            this.errorProvider.SetError(this.cboVehicle, string.Empty);
            this.errorProvider.SetError(this.txtTradeInValue, string.Empty);

            string[] vehicleErrorMessages = {"", "A vehicle must be selected."};
            string[] tradeInErrorMessages = {"",
                                             "Trade-in value is a required field.",
                                             "Trade-in value cannot contain letters or special characters.",
                                             "Trade-in value cannot be less than 0.",
                                             "Trade-in value cannot exceed the vehicle sale price." };

            if (this.cboVehicle.SelectedItem == null)
            {
                vehicleError = 1;
            }
            else
            {
                vehicleSalePrice = (decimal)this.cboVehicle.SelectedValue;
            }

            if (this.txtTradeInValue.Text.Equals(string.Empty))
            {
                tradeInError = 1;
            }
            else
            {
                try
                {
                    tradeInValue = Convert.ToDecimal(this.txtTradeInValue.Text);

                    if (tradeInValue < 0)
                    {
                        tradeInError = 3;
                    }
                    else if (errorProvider.GetError(this.cboVehicle).Equals(string.Empty))
                    {
                        if (tradeInValue > vehicleSalePrice)
                        {
                            tradeInError = 4;
                        }
                    }
                }
                catch (FormatException)
                {
                    tradeInError = 2;
                }
            }

            if (vehicleError > 0)
            {
                this.errorProvider.SetError(this.cboVehicle, vehicleErrorMessages[vehicleError]);
            }

            if (tradeInError > 0)
            {
                this.errorProvider.SetError(this.txtTradeInValue, tradeInErrorMessages[tradeInError]);
            }

            if (this.errorProvider.GetError(this.cboVehicle).Equals(string.Empty) &&
                this.errorProvider.GetError(this.txtTradeInValue).Equals(string.Empty))
            {
                this.salesQuote = new SalesQuote(vehicleSalePrice, tradeInValue, saleTaxRate);

                this.salesQuoteSource.DataSource = this.salesQuote;

                OptionsUpdated();
            }
            else
            {
                SummaryInitialize();
            }
        }

        /// <summary>
        /// Handles the Click event of the reset Button.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to reset the form?";
            string title = "Reset Form";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SummaryInitialize();

                this.cboVehicle.SelectedItem = null;

                this.errorProvider.SetError(this.cboVehicle, string.Empty);
                this.errorProvider.SetError(this.txtTradeInValue, string.Empty);

                this.txtTradeInValue.Text = "0";

                this.chkStereoSystem.Checked =
                    this.chkLeatherInterior.Checked =
                    this.chkComputerNavigation.Checked = false;

                this.radStandard.Checked = true;

                this.nudNumberOfYear.Value = 1;
                this.nudAnnualInterestRate.Value = 5;

                this.cboVehicle.Select();
            }
        }

        /// <summary>
        /// Handles the Click event of the view vehicle information menu item.
        /// </summary>
        private void MnuViewVehicleInformation_Click(object sender, EventArgs e)
        {
            Form form = new VehicleInformationForm((Vehicle)this.cboVehicle.SelectedItem);

            // Makes the form appear
            form.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the close menu item.
        /// </summary>
        private void MnuFileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}