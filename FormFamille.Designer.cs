
namespace Bacchus
{
    partial class FormFamille
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
            this.DescriptionTextFamille = new System.Windows.Forms.TextBox();
            this.DescriptionLabelFamille = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DescriptionTextFamille
            // 
            this.DescriptionTextFamille.Location = new System.Drawing.Point(208, 105);
            this.DescriptionTextFamille.Multiline = true;
            this.DescriptionTextFamille.Name = "DescriptionTextFamille";
            this.DescriptionTextFamille.Size = new System.Drawing.Size(452, 137);
            this.DescriptionTextFamille.TabIndex = 0;
            // 
            // DescriptionLabelFamille
            // 
            this.DescriptionLabelFamille.AutoSize = true;
            this.DescriptionLabelFamille.Location = new System.Drawing.Point(115, 117);
            this.DescriptionLabelFamille.Name = "DescriptionLabelFamille";
            this.DescriptionLabelFamille.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabelFamille.TabIndex = 1;
            this.DescriptionLabelFamille.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AJOUTER UNE FAMILLE";
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.Location = new System.Drawing.Point(322, 310);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(117, 46);
            this.ConfirmerButton.TabIndex = 3;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = true;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click);
            // 
            // FormFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConfirmerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionLabelFamille);
            this.Controls.Add(this.DescriptionTextFamille);
            this.Name = "FormFamille";
            this.Text = "FormFamille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescriptionTextFamille;
        private System.Windows.Forms.Label DescriptionLabelFamille;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConfirmerButton;
    }
}