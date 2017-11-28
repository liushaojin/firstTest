namespace SolingScrew.UI
{
    partial class CpkCalculate
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
            this.cpkCalTitleLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // cpkCalTitleLb
            //
            this.cpkCalTitleLb.AutoSize = true;
            this.cpkCalTitleLb.BackColor = System.Drawing.Color.LightSeaGreen;
            this.cpkCalTitleLb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cpkCalTitleLb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpkCalTitleLb.Location = new System.Drawing.Point(443, 12);
            this.cpkCalTitleLb.Name = "cpkCalTitleLb";
            this.cpkCalTitleLb.Size = new System.Drawing.Size(90, 21);
            this.cpkCalTitleLb.TabIndex = 4;
            this.cpkCalTitleLb.Text = "CPK计算";
            //
            // label1
            //
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(985, 45);
            this.label1.TabIndex = 5;
            //
            // CpkCalculate
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.cpkCalTitleLb);
            this.Controls.Add(this.label1);
            this.Name = "CpkCalculate";
            this.Text = "CpkCalculate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cpkCalTitleLb;
        private System.Windows.Forms.Label label1;
    }
}