
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
            this.ConfirmerButton.Location = new System.Drawing.Point(315, 332);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(168, 60);
            this.ConfirmerButton.TabIndex = 0;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(265, 72);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(407, 102);
            this.TextBox1.TabIndex = 1;
            // 
            // DescriptionLabelSousFamille
            // 
            this.DescriptionLabelSousFamille.AutoSize = true;
            this.DescriptionLabelSousFamille.Location = new System.Drawing.Point(153, 72);
            this.DescriptionLabelSousFamille.Name = "DescriptionLabelSousFamille";
            this.DescriptionLabelSousFamille.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabelSousFamille.TabIndex = 3;
            this.DescriptionLabelSousFamille.Text = "Description :";
            // 
            // FamilleLabelSousFamille
            // 
            this.FamilleLabelSousFamille.AutoSize = true;
            this.FamilleLabelSousFamille.Location = new System.Drawing.Point(156, 204);
            this.FamilleLabelSousFamille.Name = "FamilleLabelSousFamille";
            this.FamilleLabelSousFamille.Size = new System.Drawing.Size(45, 13);
            this.FamilleLabelSousFamille.TabIndex = 4;
            this.FamilleLabelSousFamille.Text = "Famille :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MODIFIER UNE SOUS-FAMILLE";
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(265, 204);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(218, 21);
            this.ComboBox1.TabIndex = 6;
            // 
            // FormSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FamilleLabelSousFamille);
            this.Controls.Add(this.DescriptionLabelSousFamille);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ConfirmerButton);
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