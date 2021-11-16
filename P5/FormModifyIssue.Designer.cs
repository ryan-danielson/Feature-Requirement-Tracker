
namespace P5
{
    partial class FormModifyIssue
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreateIssue = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.dateTimePickerDiscoveryDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxDiscoverer = new System.Windows.Forms.ComboBox();
            this.textBoxComponent = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(315, 672);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(154, 30);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonCreateIssue
            // 
            this.buttonCreateIssue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCreateIssue.Location = new System.Drawing.Point(504, 672);
            this.buttonCreateIssue.Name = "buttonCreateIssue";
            this.buttonCreateIssue.Size = new System.Drawing.Size(154, 30);
            this.buttonCreateIssue.TabIndex = 30;
            this.buttonCreateIssue.Text = "Modify Issue";
            this.buttonCreateIssue.UseVisualStyleBackColor = true;
            this.buttonCreateIssue.Click += new System.EventHandler(this.buttonCreateIssue_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(166, 376);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(492, 272);
            this.textBoxDescription.TabIndex = 29;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(166, 55);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(94, 22);
            this.textBoxId.TabIndex = 28;
            this.textBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePickerDiscoveryDate
            // 
            this.dateTimePickerDiscoveryDate.CustomFormat = "hh:mm tt dd MMMM yyyy";
            this.dateTimePickerDiscoveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDiscoveryDate.Location = new System.Drawing.Point(167, 172);
            this.dateTimePickerDiscoveryDate.MaxDate = new System.DateTime(2021, 11, 14, 15, 56, 35, 0);
            this.dateTimePickerDiscoveryDate.Name = "dateTimePickerDiscoveryDate";
            this.dateTimePickerDiscoveryDate.Size = new System.Drawing.Size(491, 22);
            this.dateTimePickerDiscoveryDate.TabIndex = 27;
            this.dateTimePickerDiscoveryDate.Value = new System.DateTime(2021, 11, 14, 0, 0, 0, 0);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(167, 328);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(491, 24);
            this.comboBoxStatus.TabIndex = 26;
            // 
            // comboBoxDiscoverer
            // 
            this.comboBoxDiscoverer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiscoverer.FormattingEnabled = true;
            this.comboBoxDiscoverer.Location = new System.Drawing.Point(167, 225);
            this.comboBoxDiscoverer.Name = "comboBoxDiscoverer";
            this.comboBoxDiscoverer.Size = new System.Drawing.Size(491, 24);
            this.comboBoxDiscoverer.TabIndex = 25;
            // 
            // textBoxComponent
            // 
            this.textBoxComponent.Location = new System.Drawing.Point(167, 276);
            this.textBoxComponent.Name = "textBoxComponent";
            this.textBoxComponent.Size = new System.Drawing.Size(491, 22);
            this.textBoxComponent.TabIndex = 24;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(167, 114);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(491, 22);
            this.textBoxTitle.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Initial Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Component:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Discoverer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Discovery Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Id:";
            // 
            // FormModifyIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 720);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateIssue);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.dateTimePickerDiscoveryDate);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxDiscoverer);
            this.Controls.Add(this.textBoxComponent);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormModifyIssue";
            this.Text = "ModifyIssue";
            this.Load += new System.EventHandler(this.FormModifyIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreateIssue;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.DateTimePicker dateTimePickerDiscoveryDate;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxDiscoverer;
        private System.Windows.Forms.TextBox textBoxComponent;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}