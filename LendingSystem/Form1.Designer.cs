namespace LendingSystem
{
    partial class Form1
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnCountCustomers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(169, 135);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Not Connected";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(141, 91);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(137, 32);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnCountCustomers
            // 
            this.btnCountCustomers.Location = new System.Drawing.Point(161, 185);
            this.btnCountCustomers.Name = "btnCountCustomers";
            this.btnCountCustomers.Size = new System.Drawing.Size(117, 34);
            this.btnCountCustomers.TabIndex = 2;
            this.btnCountCustomers.Text = "Count Customers";
            this.btnCountCustomers.UseVisualStyleBackColor = true;
            this.btnCountCustomers.Click += new System.EventHandler(this.btnCountCustomers_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCountCustomers);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.lblStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnCountCustomers;
    }
}

