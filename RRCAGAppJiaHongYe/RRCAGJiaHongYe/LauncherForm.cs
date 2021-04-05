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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ye.JiaHong.Business;
using System.IO;

namespace RRCAGJiaHongYe
{
    /// <summary>
    /// Represents the form used for presenting initial interface.
    /// </summary>
    public partial class LauncherForm : Form
    {
        /// <summary>
        /// Initializes an instance of the launcher form class with design and event subscriptions.
        /// </summary>
        public LauncherForm()
        {
            InitializeComponent();

            this.mnuFileOpenSalesQuote.Click += MnuFileOpenSalesQuote_Click;
            this.mnuHelpAbout.Click += MnuHelpAbout_Click;
            this.mnuFileExit.Click += MnuFileExit_Click;
            this.mnuFileOpenCarWash.Click += MnuFileOpenCarWash_Click;
        }

        /// <summary>
        /// Loads the package values into the form.
        /// </summary>
        private void LoadPackages()
        {
            try
            {
                FileStream stream;
                stream = new FileStream("packages.txt", FileMode.Open, FileAccess.Read);
            }
            catch(FileNotFoundException)
            {
                string message = "Package data file not found.";
                string title = "Data File Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Loads the fragrance values into the form.
        /// </summary>
        private void LoadFragrances()
        {
            try
            {
                FileStream stream;
                stream = new FileStream("fragrances.txt", FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                string message = "Fragrances data file not found.";
                string title = "Data File Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the car wash menu item.
        /// </summary>
        private void MnuFileOpenCarWash_Click(object sender, EventArgs e)
        {
            LoadPackages();
            LoadFragrances();

            try
            {
                // Open package file
                FileStream packageStream;
                packageStream = new FileStream("packages.txt", FileMode.Open, FileAccess.Read);
                StreamReader packageReader = new StreamReader(packageStream);
                List<string> packageList = new List<string>();

                // Store text data from the file.
                while (packageReader.Peek() != -1)
                {
                    packageList.Add(packageReader.ReadLine());
                }

                // Close file
                packageReader.Close();
                packageStream.Dispose();

                // Open fragrance file
                FileStream fragranceStream;
                fragranceStream = new FileStream("fragrances.txt", FileMode.Open, FileAccess.Read);
                StreamReader fragranceReader = new StreamReader(fragranceStream);
                List<string> fragranceList = new List<string>();

                // Store text data from the file.
                while (fragranceReader.Peek() != -1)
                {
                    fragranceList.Add(fragranceReader.ReadLine());
                }

                // Close file
                fragranceReader.Close();
                fragranceStream.Dispose();

                Form form = new CarWashForm(packageList, fragranceList);

                // Makes the form appear
                form.ShowDialog();
            }
            catch(Exception)
            {
                string message = "An error occurred while reading the data file.";
                string title = "Data File Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles the Click event of the sales quote menu item.
        /// </summary>
        private void MnuFileOpenSalesQuote_Click(object sender, EventArgs e)
        {
            Form form = new VehicleSalesQuoteForm();

            // Makes the form appear
            form.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the about menu item.
        /// </summary>
        private void MnuHelpAbout_Click(object sender, EventArgs e)
        {
            Form form = new AboutRRCAutomotiveGroupForm();

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