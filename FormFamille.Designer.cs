﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFamille));
            this.DescriptionTextFamille = new System.Windows.Forms.TextBox();
            this.DescriptionLabelFamille = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DescriptionTextFamille
            // 
            this.DescriptionTextFamille.ForeColor = System.Drawing.Color.LightCoral;
            this.DescriptionTextFamille.Location = new System.Drawing.Point(114, 89);
            this.DescriptionTextFamille.Multiline = true;
            this.DescriptionTextFamille.Name = "DescriptionTextFamille";
            this.DescriptionTextFamille.Size = new System.Drawing.Size(452, 137);
            this.DescriptionTextFamille.TabIndex = 0;
            // 
            // DescriptionLabelFamille
            // 
            this.DescriptionLabelFamille.AutoSize = true;
            this.DescriptionLabelFamille.Location = new System.Drawing.Point(27, 89);
            this.DescriptionLabelFamille.Name = "DescriptionLabelFamille";
            this.DescriptionLabelFamille.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabelFamille.TabIndex = 1;
            this.DescriptionLabelFamille.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumPurple;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(178, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "AJOUTER/MODIFIER UNE FAMILLE";
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ConfirmerButton.Location = new System.Drawing.Point(260, 260);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(117, 46);
            this.ConfirmerButton.TabIndex = 3;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = false;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click);
            // 
            // FormFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(651, 342);
            this.Controls.Add(this.ConfirmerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionLabelFamille);
            this.Controls.Add(this.DescriptionTextFamille);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFamille";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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