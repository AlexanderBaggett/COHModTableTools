namespace ModTableApp
{
    partial class ScalePartFile
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.FxScaleAmountTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ScaleFxInputButton = new System.Windows.Forms.Button();
            this.ScaleFxOutputButton = new System.Windows.Forms.Button();
            this.ScaleFxGoButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.label42);
            this.panel8.Controls.Add(this.FxScaleAmountTextBox);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.ScaleFxInputButton);
            this.panel8.Controls.Add(this.ScaleFxOutputButton);
            this.panel8.Controls.Add(this.ScaleFxGoButton);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Location = new System.Drawing.Point(12, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(314, 91);
            this.panel8.TabIndex = 88;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label42.Location = new System.Drawing.Point(171, 33);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(30, 12);
            this.label42.TabIndex = 92;
            this.label42.Text = "Scalar";
            // 
            // FxScaleAmountTextBox
            // 
            this.FxScaleAmountTextBox.Location = new System.Drawing.Point(172, 54);
            this.FxScaleAmountTextBox.Name = "FxScaleAmountTextBox";
            this.FxScaleAmountTextBox.Size = new System.Drawing.Size(29, 23);
            this.FxScaleAmountTextBox.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(91, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 12);
            this.label11.TabIndex = 90;
            this.label11.Text = "Output";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(13, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 88;
            this.label10.Text = "Input";
            // 
            // ScaleFxInputButton
            // 
            this.ScaleFxInputButton.Location = new System.Drawing.Point(10, 54);
            this.ScaleFxInputButton.Name = "ScaleFxInputButton";
            this.ScaleFxInputButton.Size = new System.Drawing.Size(75, 23);
            this.ScaleFxInputButton.TabIndex = 89;
            this.ScaleFxInputButton.Text = "Browse";
            this.ScaleFxInputButton.UseVisualStyleBackColor = true;
            // 
            // ScaleFxOutputButton
            // 
            this.ScaleFxOutputButton.Location = new System.Drawing.Point(91, 54);
            this.ScaleFxOutputButton.Name = "ScaleFxOutputButton";
            this.ScaleFxOutputButton.Size = new System.Drawing.Size(75, 23);
            this.ScaleFxOutputButton.TabIndex = 88;
            this.ScaleFxOutputButton.Text = "Browse";
            this.ScaleFxOutputButton.UseVisualStyleBackColor = true;
            // 
            // ScaleFxGoButton
            // 
            this.ScaleFxGoButton.Location = new System.Drawing.Point(236, 54);
            this.ScaleFxGoButton.Name = "ScaleFxGoButton";
            this.ScaleFxGoButton.Size = new System.Drawing.Size(75, 23);
            this.ScaleFxGoButton.TabIndex = 84;
            this.ScaleFxGoButton.Text = "Go";
            this.ScaleFxGoButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(9, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 82;
            this.label12.Text = "Scale Part file";
            // 
            // ScalePartFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 120);
            this.Controls.Add(this.panel8);
            this.Name = "ScalePartFile";
            this.Text = "ScalePartFile";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel8;
        private Label label42;
        private TextBox FxScaleAmountTextBox;
        private Label label11;
        private Label label10;
        private Button ScaleFxInputButton;
        private Button ScaleFxOutputButton;
        private Button ScaleFxGoButton;
        private Label label12;
    }
}