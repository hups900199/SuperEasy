
namespace RRCAGJiaHongYe
{
    partial class CarWashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileGenerateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblFragrance = new System.Windows.Forms.Label();
            this.cboPackage = new System.Windows.Forms.ComboBox();
            this.cboFragrance = new System.Windows.Forms.ComboBox();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lstInterior = new System.Windows.Forms.ListBox();
            this.lstExterior = new System.Windows.Forms.ListBox();
            this.lblExterior = new System.Windows.Forms.Label();
            this.lblInterior = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPST = new System.Windows.Forms.Label();
            this.lblGST = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.msMainMenu.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(561, 30);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileGenerateInvoice,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(46, 26);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileGenerateInvoice
            // 
            this.mnuFileGenerateInvoice.Name = "mnuFileGenerateInvoice";
            this.mnuFileGenerateInvoice.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.mnuFileGenerateInvoice.Size = new System.Drawing.Size(289, 26);
            this.mnuFileGenerateInvoice.Text = "Generate &Invoice";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(286, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuFileExit.Size = new System.Drawing.Size(289, 26);
            this.mnuFileExit.Text = "E&xit";
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackage.Location = new System.Drawing.Point(44, 49);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(62, 18);
            this.lblPackage.TabIndex = 1;
            this.lblPackage.Text = "Package:";
            // 
            // lblFragrance
            // 
            this.lblFragrance.AutoSize = true;
            this.lblFragrance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFragrance.Location = new System.Drawing.Point(286, 49);
            this.lblFragrance.Name = "lblFragrance";
            this.lblFragrance.Size = new System.Drawing.Size(72, 18);
            this.lblFragrance.TabIndex = 2;
            this.lblFragrance.Text = "Fragrance:";
            // 
            // cboPackage
            // 
            this.cboPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPackage.FormattingEnabled = true;
            this.cboPackage.Location = new System.Drawing.Point(47, 80);
            this.cboPackage.Name = "cboPackage";
            this.cboPackage.Size = new System.Drawing.Size(210, 26);
            this.cboPackage.Sorted = true;
            this.cboPackage.TabIndex = 3;
            // 
            // cboFragrance
            // 
            this.cboFragrance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFragrance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFragrance.FormattingEnabled = true;
            this.cboFragrance.Location = new System.Drawing.Point(289, 80);
            this.cboFragrance.Name = "cboFragrance";
            this.cboFragrance.Size = new System.Drawing.Size(210, 26);
            this.cboFragrance.Sorted = true;
            this.cboFragrance.TabIndex = 4;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lstInterior);
            this.grpSummary.Controls.Add(this.lstExterior);
            this.grpSummary.Controls.Add(this.lblExterior);
            this.grpSummary.Controls.Add(this.lblInterior);
            this.grpSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSummary.Location = new System.Drawing.Point(28, 131);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(499, 179);
            this.grpSummary.TabIndex = 5;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // lstInterior
            // 
            this.lstInterior.FormattingEnabled = true;
            this.lstInterior.ItemHeight = 18;
            this.lstInterior.Location = new System.Drawing.Point(19, 57);
            this.lstInterior.Name = "lstInterior";
            this.lstInterior.Size = new System.Drawing.Size(210, 94);
            this.lstInterior.TabIndex = 3;
            this.lstInterior.TabStop = false;
            this.lstInterior.UseTabStops = false;
            // 
            // lstExterior
            // 
            this.lstExterior.FormattingEnabled = true;
            this.lstExterior.ItemHeight = 18;
            this.lstExterior.Location = new System.Drawing.Point(261, 57);
            this.lstExterior.Name = "lstExterior";
            this.lstExterior.Size = new System.Drawing.Size(210, 94);
            this.lstExterior.TabIndex = 2;
            this.lstExterior.TabStop = false;
            this.lstExterior.UseTabStops = false;
            // 
            // lblExterior
            // 
            this.lblExterior.AutoSize = true;
            this.lblExterior.Location = new System.Drawing.Point(258, 29);
            this.lblExterior.Name = "lblExterior";
            this.lblExterior.Size = new System.Drawing.Size(61, 18);
            this.lblExterior.TabIndex = 1;
            this.lblExterior.Text = "Exterior:";
            // 
            // lblInterior
            // 
            this.lblInterior.AutoSize = true;
            this.lblInterior.Location = new System.Drawing.Point(16, 29);
            this.lblInterior.Name = "lblInterior";
            this.lblInterior.Size = new System.Drawing.Size(59, 18);
            this.lblInterior.TabIndex = 0;
            this.lblInterior.Text = "Interior:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Subtotal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "PST:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "GST:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(368, 341);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(159, 27);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPST
            // 
            this.lblPST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPST.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPST.Location = new System.Drawing.Point(368, 383);
            this.lblPST.Name = "lblPST";
            this.lblPST.Size = new System.Drawing.Size(159, 27);
            this.lblPST.TabIndex = 11;
            this.lblPST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGST
            // 
            this.lblGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGST.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGST.Location = new System.Drawing.Point(368, 425);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(159, 27);
            this.lblGST.TabIndex = 12;
            this.lblGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(368, 467);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(159, 27);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CarWashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 529);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblGST);
            this.Controls.Add(this.lblPST);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.cboFragrance);
            this.Controls.Add(this.cboPackage);
            this.Controls.Add(this.lblFragrance);
            this.Controls.Add(this.lblPackage);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CarWashForm";
            this.ShowIcon = false;
            this.Text = "Car Wash";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGenerateInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label lblFragrance;
        private System.Windows.Forms.ComboBox cboPackage;
        private System.Windows.Forms.ComboBox cboFragrance;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblExterior;
        private System.Windows.Forms.Label lblInterior;
        private System.Windows.Forms.ListBox lstInterior;
        private System.Windows.Forms.ListBox lstExterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblPST;
        private System.Windows.Forms.Label lblGST;
        private System.Windows.Forms.Label lblTotal;
    }
}