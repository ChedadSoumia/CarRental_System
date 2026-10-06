namespace CarRental.Vehicle
{
    partial class ctrlVehicleInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlVehicleInfo1 = new CarRental.Vehicle.ctrlVehicleInfo();
            this.gbFilters = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlVehicleInfo1
            // 
            this.ctrlVehicleInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlVehicleInfo1.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.ctrlVehicleInfo1.Location = new System.Drawing.Point(4, 96);
            this.ctrlVehicleInfo1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ctrlVehicleInfo1.Name = "ctrlVehicleInfo1";
            this.ctrlVehicleInfo1.Size = new System.Drawing.Size(739, 508);
            this.ctrlVehicleInfo1.TabIndex = 0;
            // 
            // gbFilters
            // 
            this.gbFilters.ColumnCount = 3;
            this.gbFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.gbFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.14754F));
            this.gbFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.29508F));
            this.gbFilters.Controls.Add(this.label2, 0, 0);
            this.gbFilters.Controls.Add(this.txtFilter, 1, 0);
            this.gbFilters.Controls.Add(this.btnFilter, 2, 0);
            this.gbFilters.Font = new System.Drawing.Font("Cairo", 10F);
            this.gbFilters.Location = new System.Drawing.Point(4, 9);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.RowCount = 1;
            this.gbFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gbFilters.Size = new System.Drawing.Size(642, 78);
            this.gbFilters.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By Vehicle ID: ";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFilter.Location = new System.Drawing.Point(174, 19);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(249, 39);
            this.txtFilter.TabIndex = 13;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddNewPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnAddNewPerson.FlatAppearance.BorderSize = 0;
            this.btnAddNewPerson.Image = global::CarRental.Properties.Resources.plus1;
            this.btnAddNewPerson.Location = new System.Drawing.Point(665, 28);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(55, 45);
            this.btnAddNewPerson.TabIndex = 18;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnFilter.Enabled = false;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Image = global::CarRental.Properties.Resources.carSearch;
            this.btnFilter.Location = new System.Drawing.Point(502, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(55, 45);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // ctrlVehicleInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ctrlVehicleInfo1);
            this.Font = new System.Drawing.Font("Cairo", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "ctrlVehicleInfoWithFilter";
            this.Size = new System.Drawing.Size(761, 625);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlVehicleInfo ctrlVehicleInfo1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TableLayoutPanel gbFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilter;
    }
}
