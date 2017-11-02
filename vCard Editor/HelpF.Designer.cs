namespace vCard_Editor
{
	partial class HelpF
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components = null;

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
		void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpF));
			this.helpRTB = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// helpRTB
			// 
			this.helpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.helpRTB.Location = new System.Drawing.Point(0, 0);
			this.helpRTB.Name = "helpRTB";
			this.helpRTB.Size = new System.Drawing.Size(584, 361);
			this.helpRTB.TabIndex = 0;
			this.helpRTB.Text = "";
			// 
			// HelpF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.helpRTB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "HelpF";
			this.Text = "Ayuda";
			this.Load += new System.EventHandler(this.HelpF_Load);
			this.ResumeLayout(false);

		}

		#endregion

		System.Windows.Forms.RichTextBox helpRTB;
	}
}