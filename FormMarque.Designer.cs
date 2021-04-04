
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.DescriptionLabelMarque = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(179, 82);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(493, 138);
            this.TextBox1.TabIndex = 0;
            // 
            // DescriptionLabelMarque
            // 
            this.DescriptionLabelMarque.AutoSize = true;
            this.DescriptionLabelMarque.Location = new System.Drawing.Point(75, 82);
            this.DescriptionLabelMarque.Name = "DescriptionLabelMarque";
            this.DescriptionLabelMarque.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabelMarque.TabIndex = 1;
            this.DescriptionLabelMarque.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MODIFIER UNE MARQUE";
            // 
            // ConfirmerButton
            // 
            this.ConfirmerButton.Location = new System.Drawing.Point(311, 289);
            this.ConfirmerButton.Name = "ConfirmerButton";
            this.ConfirmerButton.Size = new System.Drawing.Size(138, 47);
            this.ConfirmerButton.TabIndex = 3;
            this.ConfirmerButton.Text = "Confirmer";
            this.ConfirmerButton.UseVisualStyleBackColor = true;
            this.ConfirmerButton.Click += new System.EventHandler(this.ConfirmerButton_Click_1);
            // 
            // FormMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConfirmerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionLabelMarque);
            this.Controls.Add(this.TextBox1);
            this.Name = "FormMarque";
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