
namespace Bacchus
{
    partial class FormArticle
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.ReferenceLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SousFamilleLabel = new System.Windows.Forms.Label();
            this.MarqueLabel = new System.Windows.Forms.Label();
            this.PrixLabel = new System.Windows.Forms.Label();
            this.QuantiteLabel = new System.Windows.Forms.Label();
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(234, 31);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(210, 20);
            this.TextBox1.TabIndex = 0;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(234, 87);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(347, 44);
            this.TextBox2.TabIndex = 1;
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(234, 237);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(64, 20);
            this.TextBox3.TabIndex = 4;
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(234, 283);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(64, 20);
            this.TextBox4.TabIndex = 5;
            // 
            // ReferenceLabel
            // 
            this.ReferenceLabel.AutoSize = true;
            this.ReferenceLabel.Location = new System.Drawing.Point(157, 31);
            this.ReferenceLabel.Name = "ReferenceLabel";
            this.ReferenceLabel.Size = new System.Drawing.Size(63, 13);
            this.ReferenceLabel.TabIndex = 6;
            this.ReferenceLabel.Text = "Référence :";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(160, 87);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Description :";
            // 
            // SousFamilleLabel
            // 
            this.SousFamilleLabel.AutoSize = true;
            this.SousFamilleLabel.Location = new System.Drawing.Point(157, 158);
            this.SousFamilleLabel.Name = "SousFamilleLabel";
            this.SousFamilleLabel.Size = new System.Drawing.Size(69, 13);
            this.SousFamilleLabel.TabIndex = 8;
            this.SousFamilleLabel.Text = "SousFamille :";
            // 
            // MarqueLabel
            // 
            this.MarqueLabel.AutoSize = true;
            this.MarqueLabel.Location = new System.Drawing.Point(160, 195);
            this.MarqueLabel.Name = "MarqueLabel";
            this.MarqueLabel.Size = new System.Drawing.Size(49, 13);
            this.MarqueLabel.TabIndex = 9;
            this.MarqueLabel.Text = "Marque :";
            // 
            // PrixLabel
            // 
            this.PrixLabel.AutoSize = true;
            this.PrixLabel.Location = new System.Drawing.Point(160, 237);
            this.PrixLabel.Name = "PrixLabel";
            this.PrixLabel.Size = new System.Drawing.Size(54, 13);
            this.PrixLabel.TabIndex = 10;
            this.PrixLabel.Text = "Prix H.T. :";
            // 
            // QuantiteLabel
            // 
            this.QuantiteLabel.AutoSize = true;
            this.QuantiteLabel.Location = new System.Drawing.Point(160, 286);
            this.QuantiteLabel.Name = "QuantiteLabel";
            this.QuantiteLabel.Size = new System.Drawing.Size(53, 13);
            this.QuantiteLabel.TabIndex = 11;
            this.QuantiteLabel.Text = "Quantité :";
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.Location = new System.Drawing.Point(310, 356);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmerButton.TabIndex = 12;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = true;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click);
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(234, 158);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(232, 21);
            this.ComboBox1.TabIndex = 13;
            // 
            // ComboBox2
            // 
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(234, 195);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(210, 21);
            this.ComboBox2.TabIndex = 14;
            // 
            // FormArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.ConfirmerButton);
            this.Controls.Add(this.QuantiteLabel);
            this.Controls.Add(this.PrixLabel);
            this.Controls.Add(this.MarqueLabel);
            this.Controls.Add(this.SousFamilleLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.ReferenceLabel);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Name = "FormArticle";
            this.Text = "FormArticle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.TextBox TextBox4;
        private System.Windows.Forms.Label ReferenceLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label SousFamilleLabel;
        private System.Windows.Forms.Label MarqueLabel;
        private System.Windows.Forms.Label PrixLabel;
        private System.Windows.Forms.Label QuantiteLabel;
        private System.Windows.Forms.Button ConfirmerButton;
        private System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.ComboBox ComboBox2;
    }
}