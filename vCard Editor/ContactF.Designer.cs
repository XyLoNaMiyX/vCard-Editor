namespace vCard_Editor
{
	partial class ContactF
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactF));
			this.acceptB = new System.Windows.Forms.Button();
			this.cancelB = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.changeImgTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.saveImgTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyImgTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.urlPTB = new vCard_Editor.TextBoxPlaceholder();
			this.organizationPTB = new vCard_Editor.TextBoxPlaceholder();
			this.addressesTPB = new vCard_Editor.TextBoxPlaceholder();
			this.emailPTB = new vCard_Editor.TextBoxPlaceholder();
			this.displaynamePTB = new vCard_Editor.TextBoxPlaceholder();
			this.phoneTBP = new vCard_Editor.TextBoxPlaceholder();
			this.lastnameTBP = new vCard_Editor.TextBoxPlaceholder();
			this.nameTBP = new vCard_Editor.TextBoxPlaceholder();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// acceptB
			// 
			this.acceptB.Location = new System.Drawing.Point(510, 116);
			this.acceptB.Name = "acceptB";
			this.acceptB.Size = new System.Drawing.Size(75, 23);
			this.acceptB.TabIndex = 2;
			this.acceptB.Text = "Aceptar";
			this.acceptB.UseVisualStyleBackColor = true;
			this.acceptB.Click += new System.EventHandler(this.acceptB_Click);
			// 
			// cancelB
			// 
			this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelB.Location = new System.Drawing.Point(12, 116);
			this.cancelB.Name = "cancelB";
			this.cancelB.Size = new System.Drawing.Size(75, 23);
			this.cancelB.TabIndex = 3;
			this.cancelB.Text = "Cancelar";
			this.cancelB.UseVisualStyleBackColor = true;
			this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
			this.pictureBox.Location = new System.Drawing.Point(306, 14);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(96, 95);
			this.pictureBox.TabIndex = 5;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.changeImgTSMI,
			this.saveImgTSMI,
			this.copyImgTSMI});
			this.contextMenuStrip.Name = "contextMenuStrip1";
			this.contextMenuStrip.Size = new System.Drawing.Size(163, 70);
			// 
			// changeImgTSMI
			// 
			this.changeImgTSMI.Name = "changeImgTSMI";
			this.changeImgTSMI.Size = new System.Drawing.Size(162, 22);
			this.changeImgTSMI.Text = "Cambiar imagen";
			this.changeImgTSMI.Click += new System.EventHandler(this.changeImgTSMI_Click);
			// 
			// saveImgTSMI
			// 
			this.saveImgTSMI.Name = "saveImgTSMI";
			this.saveImgTSMI.Size = new System.Drawing.Size(162, 22);
			this.saveImgTSMI.Text = "Guardar imagen";
			this.saveImgTSMI.Click += new System.EventHandler(this.saveImgTSMI_Click);
			// 
			// copyImgTSMI
			// 
			this.copyImgTSMI.Name = "copyImgTSMI";
			this.copyImgTSMI.Size = new System.Drawing.Size(162, 22);
			this.copyImgTSMI.Text = "Copiar imagen";
			this.copyImgTSMI.Click += new System.EventHandler(this.copyImgTSMI_Click);
			// 
			// urlPTB
			// 
			this.urlPTB.ForeColor = System.Drawing.Color.DarkGray;
			this.urlPTB.Location = new System.Drawing.Point(409, 89);
			this.urlPTB.Name = "urlPTB";
			this.urlPTB.Placeholder = "Dirección URL";
			this.urlPTB.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.urlPTB.Size = new System.Drawing.Size(176, 20);
			this.urlPTB.TabIndex = 10;
			this.urlPTB.Text = "Dirección URL";
			this.urlPTB.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.urlPTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// organizationPTB
			// 
			this.organizationPTB.ForeColor = System.Drawing.Color.DarkGray;
			this.organizationPTB.Location = new System.Drawing.Point(409, 64);
			this.organizationPTB.Name = "organizationPTB";
			this.organizationPTB.Placeholder = "Organización";
			this.organizationPTB.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.organizationPTB.Size = new System.Drawing.Size(176, 20);
			this.organizationPTB.TabIndex = 9;
			this.organizationPTB.Text = "Organización";
			this.organizationPTB.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.organizationPTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// addressesTPB
			// 
			this.addressesTPB.ForeColor = System.Drawing.Color.DarkGray;
			this.addressesTPB.Location = new System.Drawing.Point(409, 12);
			this.addressesTPB.Multiline = true;
			this.addressesTPB.Name = "addressesTPB";
			this.addressesTPB.Placeholder = "Direcciones (una por línea)";
			this.addressesTPB.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.addressesTPB.Size = new System.Drawing.Size(176, 46);
			this.addressesTPB.TabIndex = 8;
			this.addressesTPB.Text = "Direcciones (una por línea)";
			this.addressesTPB.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// emailPTB
			// 
			this.emailPTB.ForeColor = System.Drawing.Color.DarkGray;
			this.emailPTB.Location = new System.Drawing.Point(12, 90);
			this.emailPTB.Name = "emailPTB";
			this.emailPTB.Placeholder = "Correo electrónico";
			this.emailPTB.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.emailPTB.Size = new System.Drawing.Size(141, 20);
			this.emailPTB.TabIndex = 7;
			this.emailPTB.Text = "Correo electrónico";
			this.emailPTB.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.emailPTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// displaynamePTB
			// 
			this.displaynamePTB.ForeColor = System.Drawing.Color.DarkGray;
			this.displaynamePTB.Location = new System.Drawing.Point(12, 12);
			this.displaynamePTB.Name = "displaynamePTB";
			this.displaynamePTB.Placeholder = "Nombre a mostrar";
			this.displaynamePTB.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.displaynamePTB.Size = new System.Drawing.Size(141, 20);
			this.displaynamePTB.TabIndex = 6;
			this.displaynamePTB.Text = "Nombre a mostrar";
			this.displaynamePTB.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.displaynamePTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// phoneTBP
			// 
			this.phoneTBP.ForeColor = System.Drawing.Color.DarkGray;
			this.phoneTBP.Location = new System.Drawing.Point(159, 14);
			this.phoneTBP.Multiline = true;
			this.phoneTBP.Name = "phoneTBP";
			this.phoneTBP.Placeholder = "Teléfono (uno por línea)";
			this.phoneTBP.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.phoneTBP.Size = new System.Drawing.Size(141, 96);
			this.phoneTBP.TabIndex = 4;
			this.phoneTBP.Text = "Teléfono (uno por línea)";
			this.phoneTBP.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// lastnameTBP
			// 
			this.lastnameTBP.ForeColor = System.Drawing.Color.DarkGray;
			this.lastnameTBP.Location = new System.Drawing.Point(12, 64);
			this.lastnameTBP.Name = "lastnameTBP";
			this.lastnameTBP.Placeholder = "Apellido(s)";
			this.lastnameTBP.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.lastnameTBP.Size = new System.Drawing.Size(141, 20);
			this.lastnameTBP.TabIndex = 1;
			this.lastnameTBP.Text = "Apellido(s)";
			this.lastnameTBP.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.lastnameTBP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// nameTBP
			// 
			this.nameTBP.ForeColor = System.Drawing.Color.DarkGray;
			this.nameTBP.Location = new System.Drawing.Point(12, 38);
			this.nameTBP.Name = "nameTBP";
			this.nameTBP.Placeholder = "Nombre";
			this.nameTBP.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.nameTBP.Size = new System.Drawing.Size(141, 20);
			this.nameTBP.TabIndex = 0;
			this.nameTBP.Text = "Nombre";
			this.nameTBP.UnvariantForeColor = System.Drawing.SystemColors.WindowText;
			this.nameTBP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.displaynamePTB_KeyDown);
			// 
			// ContactF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelB;
			this.ClientSize = new System.Drawing.Size(597, 144);
			this.Controls.Add(this.urlPTB);
			this.Controls.Add(this.organizationPTB);
			this.Controls.Add(this.addressesTPB);
			this.Controls.Add(this.emailPTB);
			this.Controls.Add(this.displaynamePTB);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.phoneTBP);
			this.Controls.Add(this.cancelB);
			this.Controls.Add(this.acceptB);
			this.Controls.Add(this.lastnameTBP);
			this.Controls.Add(this.nameTBP);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ContactF";
			this.Text = "Añadir contacto";
			this.Load += new System.EventHandler(this.ContactF_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		TextBoxPlaceholder nameTBP;
		TextBoxPlaceholder lastnameTBP;
		System.Windows.Forms.Button acceptB;
		System.Windows.Forms.Button cancelB;
		TextBoxPlaceholder phoneTBP;
		System.Windows.Forms.PictureBox pictureBox;
		System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		System.Windows.Forms.ToolStripMenuItem changeImgTSMI;
		System.Windows.Forms.ToolStripMenuItem saveImgTSMI;
		System.Windows.Forms.ToolStripMenuItem copyImgTSMI;
		TextBoxPlaceholder displaynamePTB;
		TextBoxPlaceholder emailPTB;
		TextBoxPlaceholder addressesTPB;
		TextBoxPlaceholder organizationPTB;
		TextBoxPlaceholder urlPTB;


	}
}