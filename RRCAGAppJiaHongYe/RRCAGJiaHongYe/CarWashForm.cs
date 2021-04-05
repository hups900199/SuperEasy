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
using Ye.JiaHong.Business;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for making car wash invoice.
    /// </summary>
    public partial class CarWashForm : Form
    {
        private CarWashInvoice carWashInvoice;
        private BindingSource CarWashSource,
                              PackageItems,
                              FragranceItems;

        /// <summary>
        /// Initializes an instance of the car wash form class with design and event subscriptions.
        /// </summary>
        public CarWashForm(List<string> packages, List<string> fragrances)
        {
            InitializeComponent();

            LoadPackages(packages);
            LoadFragrances(fragrances);

            this.carWashInvoice = null;

            this.CarWashSource = new BindingSource();
            this.CarWashSource.DataSource = typeof(CarWashInvoice);

            BindControls();

            this.cboPackage.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            this.cboFragrance.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            this.mnuFileGenerateInvoice.Click += MnuFileGenerateInvoice_Click;
            this.mnuFileExit.Click += MnuFileExit_Click;
        }

        /// <summary>
        /// Stores list details for package.
        /// </summary>
        public class PackageDetails
        {
            public string packageName { get; set; }
            public decimal packagePrice { get; set; }
        }

        /// <summary>
        /// Stores list details for fragrance.
        /// </summary>
        public class FragranceDetails
        {
            public string fragranceName { get; set; }
            public decimal fragrancePrice { get; set; }
        }

        /// <summary>
        /// Loads the package values into the ComboBox.
        /// </summary>
        private void LoadPackages(List<string> packages)
        {
            List<PackageDetails> packageList = new List<PackageDetails>();

            for (int i = 0; i < packages.Count; i++)
            {
                int startIndex = packages[i].IndexOf("$");
                int endIndex = packages[i].Length - startIndex;

                packageList.Add(new PackageDetails()
                {
                    packageName = packages[i].Substring(0, (startIndex - 1)),
                    packagePrice = Convert.ToDecimal(packages[i].Substring((startIndex + 1), (endIndex - 1)))
                });

            }

            packageList.Sort(delegate (PackageDetails x, PackageDetails y)
            {
                if (x.packageName == null && y.packageName == null)
                    return 0;
                else if (x.packageName == null)
                    return -1;
                else if (y.packageName == null)
                    return 1;
                else
                    return x.packageName.CompareTo(y.packageName);
            });

            this.PackageItems = new BindingSource();

            this.PackageItems.DataSource = packageList;

            for (int i = 0; i < this.cboPackage.Items.Count; i++)
            {
                if (this.cboPackage.GetItemText(this.cboPackage.Items[i]).Equals("Standard"))
                {
                    this.cboPackage.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Loads the fragrance values into the ComboBox.
        /// </summary>
        private void LoadFragrances(List<string> fragrances)
        {
            List<FragranceDetails> fragranceList = new List<FragranceDetails>();

            for (int i = 0; i < fragrances.Count; i++)
            {
                int startIndex = fragrances[i].IndexOf("$");
                int endIndex = fragrances[i].Length - startIndex;

                fragranceList.Add(new FragranceDetails()
                {
                    fragranceName = fragrances[i].Substring(0, (startIndex - 1)),
                    fragrancePrice = Convert.ToDecimal(fragrances[i].Substring((startIndex + 1), (endIndex - 1)))
                });

            }

            fragranceList.Sort(delegate (FragranceDetails x, FragranceDetails y)
            {
                if (x.fragranceName == null && y.fragranceName == null)
                    return 0;
                else if (x.fragranceName == null)
                    return -1;
                else if (y.fragranceName == null)
                    return 1;
                else
                    return x.fragranceName.CompareTo(y.fragranceName);
            });

            this.FragranceItems = new BindingSource();

            this.FragranceItems.DataSource = fragranceList;

            for (int i = 0; i < this.cboFragrance.Items.Count; i++)
            {
                if (this.cboFragrance.GetItemText(this.cboFragrance.Items[i]).Equals("Pine"))
                {
                    this.cboFragrance.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Sets the data binding for the form.
        /// </summary>
        private void BindControls()
        {
            this.cboPackage.DataSource = this.PackageItems;
            this.cboPackage.DisplayMember = "packageName";
            this.cboPackage.ValueMember = "packagePrice";

            this.cboFragrance.DataSource = this.FragranceItems;
            this.cboFragrance.DisplayMember = "fragranceName";
            this.cboFragrance.ValueMember = "fragrancePrice";

            Binding subtotalBind = new Binding("Text", this.CarWashSource, "SubTotal");
            this.lblSubtotal.DataBindings.Add(subtotalBind);

            Binding PSTBind = new Binding("Text", this.CarWashSource, "ProvincialSalesTaxCharged");
            this.lblPST.DataBindings.Add(PSTBind);

            Binding GSTBind = new Binding("Text", this.CarWashSource, "GoodsAndServicesTaxCharged");
            this.lblGST.DataBindings.Add(GSTBind);

            Binding totalBind = new Binding("Text", this.CarWashSource, "Total");
            this.lblTotal.DataBindings.Add(totalBind);

            subtotalBind.FormattingEnabled =
                PSTBind.FormattingEnabled =
                GSTBind.FormattingEnabled =
                totalBind.FormattingEnabled = true;

            subtotalBind.FormatString = "C";
            PSTBind.FormatString = "N2";
            GSTBind.FormatString = "C";
            totalBind.FormatString = "C";
        }

        /// <summary>
        /// Clears all data from ListBox.
        /// </summary>
        private void ListBoxClear()
        {
            lstExterior.Items.Clear();
            lstInterior.Items.Clear();
        }

        /// <summary>
        /// Loads the interior and exterior values into the ListBox.
        /// </summary>
        private void ListBoxLoad()
        {
            string selectedPackage = this.cboPackage.GetItemText(this.cboPackage.SelectedItem);

            if (selectedPackage == "Standard")
            {
                this.lstInterior.Items.Add($"Fragrance - {this.cboFragrance.Text}");

                this.lstExterior.Items.Add("Hand Wash");
            }
            else if (selectedPackage == "Deluxe")
            {
                this.lstInterior.Items.Add($"Fragrance - {this.cboFragrance.Text}");
                this.lstInterior.Items.Add("Shampoo Carpets");

                this.lstExterior.Items.Add("Hand Wash");
                this.lstExterior.Items.Add("Hand Wax");
            }
            else if (selectedPackage == "Executive")
            {
                this.lstInterior.Items.Add($"Fragrance - {this.cboFragrance.Text}");
                this.lstInterior.Items.Add("Shampoo Carpets");
                this.lstInterior.Items.Add("Shampoo Upholstery");

                this.lstExterior.Items.Add("Hand Wash");
                this.lstExterior.Items.Add("Hand Wax");
                this.lstExterior.Items.Add("Wheel Polish");
            }
            else if (selectedPackage == "Luxury")
            {
                this.lstInterior.Items.Add($"Fragrance - {this.cboFragrance.Text}");
                this.lstInterior.Items.Add("Shampoo Carpets");
                this.lstInterior.Items.Add("Shampoo Upholstery");
                this.lstInterior.Items.Add("Interior Protection Coat");

                this.lstExterior.Items.Add("Hand Wash");
                this.lstExterior.Items.Add("Hand Wax");
                this.lstExterior.Items.Add("Wheel Polish");
                this.lstExterior.Items.Add("Detail Engine Compartment");
            }
        }

        /// <summary>
        /// Creates a car wash invoice.
        /// </summary>
        private void CreateCarWashInvoice()
        {
            decimal packageCost = (decimal)this.cboPackage.SelectedValue;
            decimal fragranceCost = (decimal)this.cboFragrance.SelectedValue;

            this.carWashInvoice = new CarWashInvoice(0, 0.08M, packageCost, fragranceCost);

            this.CarWashSource.DataSource = this.carWashInvoice;
        }

        /// <summary>
        /// Displays ListBox data based on ComboBox selection.
        /// </summary>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxClear();

            ListBoxLoad();

            CreateCarWashInvoice();
        }

        /// <summary>
        /// Handles the Click event of the generate invoice menu item.
        /// </summary>
        private void MnuFileGenerateInvoice_Click(object sender, EventArgs e)
        {
            Form form = new CarWashInvoiceForm(this.CarWashSource);

            // Makes the form appear
            form.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the exit menu item.
        /// </summary>
        private void MnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}