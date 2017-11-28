namespace SolingScrew
{
partial class Login
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
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        this.SuspendLayout();
        //
        // textBox1
        //
        this.textBox1.Location = new System.Drawing.Point(78, 162);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(327, 21);
        this.textBox1.TabIndex = 0;
        this.textBox1.Text = "请输入用户名";
        //
        // button1
        //
        this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        this.button1.Location = new System.Drawing.Point(177, 227);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(141, 54);
        this.button1.TabIndex = 2;
        this.button1.Text = "登入";
        this.button1.UseVisualStyleBackColor = true;
        //
        // pictureBox1
        //
        this.pictureBox1.Image = global::SolingScrew.Properties.Resources.soling_login01;
        this.pictureBox1.Location = new System.Drawing.Point(78, 23);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(329, 80);
        this.pictureBox1.TabIndex = 3;
        this.pictureBox1.TabStop = false;
        //
        // pictureBox2
        //
        this.pictureBox2.Image = global::SolingScrew.Properties.Resources.soling_login02;
        this.pictureBox2.Location = new System.Drawing.Point(12, 148);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(48, 45);
        this.pictureBox2.TabIndex = 3;
        this.pictureBox2.TabStop = false;
        //
        // Login
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(484, 312);
        this.Controls.Add(this.pictureBox2);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox1);
        this.Name = "Login";
        this.Text = "登入";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox2;
}
}