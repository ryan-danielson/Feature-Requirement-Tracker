
namespace Builder
{
    partial class FormSelectFeature
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
            this.dataGridViewSelectFeature = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSelectFeature = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectFeature)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSelectFeature
            // 
            this.dataGridViewSelectFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelectFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnFeature});
            this.dataGridViewSelectFeature.Location = new System.Drawing.Point(38, 35);
            this.dataGridViewSelectFeature.Name = "dataGridViewSelectFeature";
            this.dataGridViewSelectFeature.RowHeadersWidth = 51;
            this.dataGridViewSelectFeature.RowTemplate.Height = 24;
            this.dataGridViewSelectFeature.Size = new System.Drawing.Size(726, 339);
            this.dataGridViewSelectFeature.TabIndex = 0;
            this.dataGridViewSelectFeature.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnId
            // 
            this.ColumnId.FillWeight = 21.39038F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 6;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnFeature
            // 
            this.ColumnFeature.FillWeight = 178.6096F;
            this.ColumnFeature.HeaderText = "Feature";
            this.ColumnFeature.MinimumWidth = 6;
            this.ColumnFeature.Name = "ColumnFeature";
            this.ColumnFeature.ReadOnly = true;
            // 
            // buttonSelectFeature
            // 
            this.buttonSelectFeature.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelectFeature.Location = new System.Drawing.Point(617, 400);
            this.buttonSelectFeature.Name = "buttonSelectFeature";
            this.buttonSelectFeature.Size = new System.Drawing.Size(146, 23);
            this.buttonSelectFeature.TabIndex = 1;
            this.buttonSelectFeature.Text = "Select Feature";
            this.buttonSelectFeature.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(435, 400);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(146, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSelectFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelectFeature);
            this.Controls.Add(this.dataGridViewSelectFeature);
            this.Name = "FormSelectFeature";
            this.Text = "Select Feature";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectFeature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelectFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFeature;
        private System.Windows.Forms.Button buttonSelectFeature;
        private System.Windows.Forms.Button buttonCancel;
    }
}