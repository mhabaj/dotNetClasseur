
namespace Bacchus
{
    partial class FormMarque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMarque));
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.DescriptionLabelMarque = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.TextBox1.ForeColor = System.Drawing.Color.Firebrick;
            this.TextBox1.Location = new System.Drawing.Point(127, 81);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(570, 137);
            this.TextBox1.TabIndex = 0;
            // 
            // DescriptionLabelMarque
            // 
            this.DescriptionLabelMarque.AutoSize = true;
            this.DescriptionLabelMarque.Location = new System.Drawing.Point(31, 81);
            this.DescriptionLabelMarque.Name = "DescriptionLabelMarque";
            this.DescriptionLabelMarque.Size = new System.Drawing.Size(86, 13);
            this.DescriptionLabelMarque.TabIndex = 1;
            this.DescriptionLabelMarque.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(253, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "MODIFIER/AJOUTER UNE MARQUE";
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ConfirmerButton.Location = new System.Drawing.Point(299, 251);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(184, 47);
            this.ConfirmerButton.TabIndex = 3;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = false;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click_1);
            // 
            // FormMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(809, 361);
            this.Controls.Add(this.ConfirmerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionLabelMarque);
            this.Controls.Add(this.TextBox1);
            this.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMarque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMarque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label DescriptionLabelMarque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConfirmerButton;
    }
}