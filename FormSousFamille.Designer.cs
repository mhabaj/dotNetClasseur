
namespace Bacchus
{
    partial class FormSousFamille
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSousFamille));
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.DescriptionLabelSousFamille = new System.Windows.Forms.Label();
            this.FamilleLabelSousFamille = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ConfirmerButton.Location = new System.Drawing.Point(251, 286);
            this.ConfirmerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(164, 46);
            this.ConfirmerButton.TabIndex = 0;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = false;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click_1);
            // 
            // TextBox1
            // 
            this.TextBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.TextBox1.Location = new System.Drawing.Point(145, 78);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(474, 110);
            this.TextBox1.TabIndex = 1;
            // 
            // DescriptionLabelSousFamille
            // 
            this.DescriptionLabelSousFamille.AutoSize = true;
            this.DescriptionLabelSousFamille.Location = new System.Drawing.Point(48, 78);
            this.DescriptionLabelSousFamille.Name = "DescriptionLabelSousFamille";
            this.DescriptionLabelSousFamille.Size = new System.Drawing.Size(79, 14);
            this.DescriptionLabelSousFamille.TabIndex = 3;
            this.DescriptionLabelSousFamille.Text = "Description :";
            // 
            // FamilleLabelSousFamille
            // 
            this.FamilleLabelSousFamille.AutoSize = true;
            this.FamilleLabelSousFamille.Location = new System.Drawing.Point(72, 228);
            this.FamilleLabelSousFamille.Name = "FamilleLabelSousFamille";
            this.FamilleLabelSousFamille.Size = new System.Drawing.Size(53, 14);
            this.FamilleLabelSousFamille.TabIndex = 4;
            this.FamilleLabelSousFamille.Text = "Famille :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "MODIFIER/AJOUTER UNE SOUS-FAMILLE";
            // 
            // ComboBox1
            // 
            this.ComboBox1.BackColor = System.Drawing.Color.SlateBlue;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(145, 225);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(254, 22);
            this.ComboBox1.TabIndex = 6;
            // 
            // FormSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(742, 362);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FamilleLabelSousFamille);
            this.Controls.Add(this.DescriptionLabelSousFamille);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ConfirmerButton);
            this.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSousFamille";
            this.Text = "FormSousFamille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmerButton;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label DescriptionLabelSousFamille;
        private System.Windows.Forms.Label FamilleLabelSousFamille;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBox1;
    }
}