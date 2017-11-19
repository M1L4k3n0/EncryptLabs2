using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using ConsoleRedirection;

/// <summary>
/// Summary description for FrmDriver.
/// </summary>
public class FrmDriver : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txbInput;
		private System.Windows.Forms.TextBox txbOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		private MD5.MD5 md =new MD5.MD5();
    private Button button1;
    private TextBox textBox1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    TextWriter _writer = null;
    public FrmDriver()
		{
        //
        // Required for Windows Form Designer support
        //
        // That's our custom TextWriter class


        InitializeComponent();
        _writer = new TextBoxStreamWriter(textBox1);
        // Redirect the out Console stream
        Console.SetOut(_writer);

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
    }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txbInput = new System.Windows.Forms.TextBox();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbInput
            // 
            this.txbInput.Location = new System.Drawing.Point(72, 12);
            this.txbInput.Name = "txbInput";
            this.txbInput.Size = new System.Drawing.Size(240, 20);
            this.txbInput.TabIndex = 0;
            this.txbInput.Text = "vas";
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(72, 404);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.Size = new System.Drawing.Size(240, 20);
            this.txbOutput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "string";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "MD5";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(618, 292);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FrmDriver
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(643, 439);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.txbInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDriver";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Drive";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		

    private void button1_Click(object sender, EventArgs e)
    {
        md.Value = txbInput.Text;
        txbOutput.Text = md.FingerPrint;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
}

