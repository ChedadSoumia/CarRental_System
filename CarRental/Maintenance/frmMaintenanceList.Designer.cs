namespace CarRental.Maintenance
{
    partial class frmMaintenanceList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNormaltxt = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnAddNewMaintenance = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountRecord = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvAllMaintenance = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPeopleInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlNormaltxt.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMaintenance)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.27718F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.72282F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 662F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddNewMaintenance, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbFilter, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(40, 107);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1224, 54);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlNormaltxt);
            this.panel1.Location = new System.Drawing.Point(457, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 48);
            this.panel1.TabIndex = 19;
            // 
            // pnlNormaltxt
            // 
            this.pnlNormaltxt.Controls.Add(this.txtFilter);
            this.pnlNormaltxt.Location = new System.Drawing.Point(3, 0);
            this.pnlNormaltxt.Name = "pnlNormaltxt";
            this.pnlNormaltxt.Size = new System.Drawing.Size(490, 48);
            this.pnlNormaltxt.TabIndex = 10;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilter.Location = new System.Drawing.Point(3, 1);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(299, 39);
            this.txtFilter.TabIndex = 13;
            // 
            // btnAddNewMaintenance
            // 
            this.btnAddNewMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnAddNewMaintenance.FlatAppearance.BorderSize = 0;
            this.btnAddNewMaintenance.Image = global::CarRental.Properties.Resources.construction_white;
            this.btnAddNewMaintenance.Location = new System.Drawing.Point(1119, 3);
            this.btnAddNewMaintenance.Name = "btnAddNewMaintenance";
            this.btnAddNewMaintenance.Size = new System.Drawing.Size(55, 45);
            this.btnAddNewMaintenance.TabIndex = 10;
            this.btnAddNewMaintenance.UseVisualStyleBackColor = false;
            this.btnAddNewMaintenance.Click += new System.EventHandler(this.btnAddNewMaintenance_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By : ";
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Vehicle id"});
            this.cbFilter.Location = new System.Drawing.Point(108, 14);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(288, 40);
            this.cbFilter.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.Controls.Add(this.btnFirstPage);
            this.flowLayoutPanel1.Controls.Add(this.btnPrevious);
            this.flowLayoutPanel1.Controls.Add(this.lblPageNumber);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnLastPage);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(877, 740);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(387, 54);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.Image = global::CarRental.Properties.Resources.fast_rewind;
            this.btnFirstPage.Location = new System.Drawing.Point(3, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(55, 45);
            this.btnFirstPage.TabIndex = 4;
            this.btnFirstPage.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.Image = global::CarRental.Properties.Resources.arrow_back;
            this.btnPrevious.Location = new System.Drawing.Point(64, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrevious.Size = new System.Drawing.Size(55, 45);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(125, 9);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPageNumber.Size = new System.Drawing.Size(128, 32);
            this.lblPageNumber.TabIndex = 5;
            this.lblPageNumber.Text = "Page 1 of 100";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Image = global::CarRental.Properties.Resources.arrow_forward;
            this.btnNext.Location = new System.Drawing.Point(259, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNext.Size = new System.Drawing.Size(55, 45);
            this.btnNext.TabIndex = 5;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnLastPage
            // 
            this.btnLastPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnLastPage.FlatAppearance.BorderSize = 0;
            this.btnLastPage.Image = global::CarRental.Properties.Resources.fast_next_page;
            this.btnLastPage.Location = new System.Drawing.Point(320, 3);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(55, 45);
            this.btnLastPage.TabIndex = 6;
            this.btnLastPage.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.lblCountRecord);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(40, 740);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(318, 54);
            this.flowLayoutPanel2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Size = new System.Drawing.Size(96, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "#Record : ";
            // 
            // lblCountRecord
            // 
            this.lblCountRecord.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCountRecord.AutoSize = true;
            this.lblCountRecord.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecord.Location = new System.Drawing.Point(105, 0);
            this.lblCountRecord.Name = "lblCountRecord";
            this.lblCountRecord.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCountRecord.Size = new System.Drawing.Size(10, 32);
            this.lblCountRecord.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.46342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.53658F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 64);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 20.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maintenance List";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::CarRental.Properties.Resources.cars_black;
            this.pictureBox1.Location = new System.Drawing.Point(4, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgvAllMaintenance
            // 
            this.dgvAllMaintenance.AllowUserToAddRows = false;
            this.dgvAllMaintenance.AllowUserToDeleteRows = false;
            this.dgvAllMaintenance.AllowUserToOrderColumns = true;
            this.dgvAllMaintenance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllMaintenance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllMaintenance.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllMaintenance.EnableHeadersVisualStyles = false;
            this.dgvAllMaintenance.GridColor = System.Drawing.Color.White;
            this.dgvAllMaintenance.Location = new System.Drawing.Point(40, 171);
            this.dgvAllMaintenance.Name = "dgvAllMaintenance";
            this.dgvAllMaintenance.ReadOnly = true;
            this.dgvAllMaintenance.RowHeadersWidth = 51;
            this.dgvAllMaintenance.RowTemplate.Height = 26;
            this.dgvAllMaintenance.Size = new System.Drawing.Size(1224, 542);
            this.dgvAllMaintenance.TabIndex = 20;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPeopleInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewPersonToolStripMenuItem,
            this.editPersonToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(263, 118);
            // 
            // showPeopleInfoToolStripMenuItem
            // 
            this.showPeopleInfoToolStripMenuItem.Image = global::CarRental.Properties.Resources.settings_screen;
            this.showPeopleInfoToolStripMenuItem.Name = "showPeopleInfoToolStripMenuItem";
            this.showPeopleInfoToolStripMenuItem.Size = new System.Drawing.Size(262, 36);
            this.showPeopleInfoToolStripMenuItem.Text = "Show Maintenance Info";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::CarRental.Properties.Resources.car_gear_black;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(262, 36);
            this.addNewPersonToolStripMenuItem.Text = "Add new Maintenance";
            // 
            // editPersonToolStripMenuItem
            // 
            this.editPersonToolStripMenuItem.Image = global::CarRental.Properties.Resources.edit_black;
            this.editPersonToolStripMenuItem.Name = "editPersonToolStripMenuItem";
            this.editPersonToolStripMenuItem.Size = new System.Drawing.Size(262, 36);
            this.editPersonToolStripMenuItem.Text = "Edit Customer";
            // 
            // frmMaintenanceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 820);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvAllMaintenance);
            this.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmMaintenanceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMaintenanceList";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlNormaltxt.ResumeLayout(false);
            this.pnlNormaltxt.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMaintenance)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNormaltxt;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnAddNewMaintenance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountRecord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAllMaintenance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPeopleInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPersonToolStripMenuItem;
    }
}