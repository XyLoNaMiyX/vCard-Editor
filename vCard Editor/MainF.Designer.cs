namespace vCard_Editor
{
	partial class MainF
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainF));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.saveTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.combineTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.helpTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.hhelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.checkUpdatesTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.languageTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.spanishTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.englishTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.frenchTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.listView = new System.Windows.Forms.ListView();
			this.nameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastnameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.phoneCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.removeTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.addTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.detailsGB = new System.Windows.Forms.GroupBox();
			this.infoL = new System.Windows.Forms.Label();
			this.sofd = new System.Windows.Forms.OpenFileDialog();
			this.mofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.newTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.listViewCMS.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.detailsGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileTSMI,
			this.helpTSMI,
			this.languageTSMI});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(534, 24);
			this.menuStrip.TabIndex = 0;
			// 
			// fileTSMI
			// 
			this.fileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newTSMI,
			this.openTSMI,
			this.saveTSMI,
			this.saveAsTSMI,
			this.toolStripSeparator1,
			this.combineTSMI});
			this.fileTSMI.Name = "fileTSMI";
			this.fileTSMI.Size = new System.Drawing.Size(60, 20);
			this.fileTSMI.Text = "Archivo";
			// 
			// openTSMI
			// 
			this.openTSMI.Name = "openTSMI";
			this.openTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openTSMI.Size = new System.Drawing.Size(245, 22);
			this.openTSMI.Text = "Abrir";
			this.openTSMI.Click += new System.EventHandler(this.openTSMI_Click);
			// 
			// saveTSMI
			// 
			this.saveTSMI.Name = "saveTSMI";
			this.saveTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveTSMI.Size = new System.Drawing.Size(245, 22);
			this.saveTSMI.Text = "Guardar";
			this.saveTSMI.Click += new System.EventHandler(this.saveTSMI_Click);
			// 
			// saveAsTSMI
			// 
			this.saveAsTSMI.Name = "saveAsTSMI";
			this.saveAsTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
			| System.Windows.Forms.Keys.S)));
			this.saveAsTSMI.Size = new System.Drawing.Size(245, 22);
			this.saveAsTSMI.Text = "Guardar como...";
			this.saveAsTSMI.Click += new System.EventHandler(this.saveAsTSMI_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
			// 
			// combineTSMI
			// 
			this.combineTSMI.Name = "combineTSMI";
			this.combineTSMI.Size = new System.Drawing.Size(245, 22);
			this.combineTSMI.Text = "Combinar vCards";
			this.combineTSMI.Click += new System.EventHandler(this.combineTSMI_Click);
			// 
			// helpTSMI
			// 
			this.helpTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.hhelpTSMI,
			this.checkUpdatesTSMI});
			this.helpTSMI.Name = "helpTSMI";
			this.helpTSMI.Size = new System.Drawing.Size(53, 20);
			this.helpTSMI.Text = "Ayuda";
			// 
			// hhelpTSMI
			// 
			this.hhelpTSMI.Name = "hhelpTSMI";
			this.hhelpTSMI.Size = new System.Drawing.Size(218, 22);
			this.hhelpTSMI.Text = "Ayuda";
			this.hhelpTSMI.Click += new System.EventHandler(this.helpTSMI_Click);
			// 
			// checkUpdatesTSMI
			// 
			this.checkUpdatesTSMI.Name = "checkUpdatesTSMI";
			this.checkUpdatesTSMI.Size = new System.Drawing.Size(218, 22);
			this.checkUpdatesTSMI.Text = "Comprobar actualizaciones";
			this.checkUpdatesTSMI.Click += new System.EventHandler(this.checkUpdatesTSMI_Click);
			// 
			// languageTSMI
			// 
			this.languageTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.spanishTSMI,
			this.englishTSMI,
			this.frenchTSMI});
			this.languageTSMI.Name = "languageTSMI";
			this.languageTSMI.Size = new System.Drawing.Size(67, 20);
			this.languageTSMI.Text = "Lenguaje";
			// 
			// spanishTSMI
			// 
			this.spanishTSMI.CheckOnClick = true;
			this.spanishTSMI.Name = "spanishTSMI";
			this.spanishTSMI.Size = new System.Drawing.Size(115, 22);
			this.spanishTSMI.Text = "Español";
			this.spanishTSMI.CheckedChanged += new System.EventHandler(this.spanishTSMI_CheckedChanged);
			// 
			// englishTSMI
			// 
			this.englishTSMI.CheckOnClick = true;
			this.englishTSMI.Name = "englishTSMI";
			this.englishTSMI.Size = new System.Drawing.Size(115, 22);
			this.englishTSMI.Text = "Inglés";
			this.englishTSMI.CheckedChanged += new System.EventHandler(this.englishTSMI_CheckedChanged);
			// 
			// frenchTSMI
			// 
			this.frenchTSMI.CheckOnClick = true;
			this.frenchTSMI.Name = "frenchTSMI";
			this.frenchTSMI.Size = new System.Drawing.Size(115, 22);
			this.frenchTSMI.Text = "Francés";
			this.frenchTSMI.CheckedChanged += new System.EventHandler(this.frenchTSMI_CheckedChanged);
			// 
			// listView
			// 
			this.listView.AllowDrop = true;
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.nameCH,
			this.lastnameCH,
			this.phoneCH});
			this.listView.ContextMenuStrip = this.listViewCMS;
			this.listView.FullRowSelect = true;
			this.listView.Location = new System.Drawing.Point(6, 27);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(400, 200);
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
			this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
			this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
			// 
			// nameCH
			// 
			this.nameCH.Text = "Nombre";
			this.nameCH.Width = 80;
			// 
			// lastnameCH
			// 
			this.lastnameCH.Text = "Apellidos";
			this.lastnameCH.Width = 140;
			// 
			// phoneCH
			// 
			this.phoneCH.Text = "Teléfono";
			this.phoneCH.Width = 80;
			// 
			// listViewCMS
			// 
			this.listViewCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.editTSMI,
			this.removeTSMI,
			this.addTSMI});
			this.listViewCMS.Name = "listViewCMS";
			this.listViewCMS.Size = new System.Drawing.Size(168, 70);
			this.listViewCMS.Opening += new System.ComponentModel.CancelEventHandler(this.listViewCMS_Opening);
			// 
			// editTSMI
			// 
			this.editTSMI.Name = "editTSMI";
			this.editTSMI.Size = new System.Drawing.Size(167, 22);
			this.editTSMI.Text = "Editar contacto";
			this.editTSMI.Click += new System.EventHandler(this.editTSMI_Click);
			// 
			// removeTSMI
			// 
			this.removeTSMI.Name = "removeTSMI";
			this.removeTSMI.Size = new System.Drawing.Size(167, 22);
			this.removeTSMI.Text = "Eliminar contacto";
			this.removeTSMI.Click += new System.EventHandler(this.removeTSMI_Click);
			// 
			// addTSMI
			// 
			this.addTSMI.Name = "addTSMI";
			this.addTSMI.Size = new System.Drawing.Size(167, 22);
			this.addTSMI.Text = "Añadir contacto";
			this.addTSMI.Click += new System.EventHandler(this.addTSMI_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(6, 19);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(96, 96);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// detailsGB
			// 
			this.detailsGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.detailsGB.Controls.Add(this.infoL);
			this.detailsGB.Controls.Add(this.pictureBox);
			this.detailsGB.Location = new System.Drawing.Point(412, 27);
			this.detailsGB.Name = "detailsGB";
			this.detailsGB.Size = new System.Drawing.Size(110, 200);
			this.detailsGB.TabIndex = 3;
			this.detailsGB.TabStop = false;
			this.detailsGB.Text = "Detalles";
			// 
			// infoL
			// 
			this.infoL.AutoSize = true;
			this.infoL.Location = new System.Drawing.Point(7, 122);
			this.infoL.MaximumSize = new System.Drawing.Size(100, 100);
			this.infoL.Name = "infoL";
			this.infoL.Size = new System.Drawing.Size(0, 13);
			this.infoL.TabIndex = 3;
			// 
			// sofd
			// 
			this.sofd.Filter = "Archivo vCard|*.vcf;*.vcard";
			this.sofd.Title = "Elija un archivo vCard";
			// 
			// mofd
			// 
			this.mofd.Filter = "Archivo vCard|*.vcf;*.vcard";
			this.mofd.Multiselect = true;
			this.mofd.Title = "Elija uno o varios archivos vCard";
			// 
			// sfd
			// 
			this.sfd.Filter = "Archivo vCard|*.vcf;*.vcard";
			this.sfd.Title = "Elija donde guardar el archivo vCard";
			// 
			// newTSMI
			// 
			this.newTSMI.Name = "newTSMI";
			this.newTSMI.Size = new System.Drawing.Size(245, 22);
			this.newTSMI.Text = "Nuevo";
			this.newTSMI.Click += new System.EventHandler(this.newTSMI_Click);
			// 
			// MainF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 236);
			this.Controls.Add(this.detailsGB);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(550, 275);
			this.Name = "MainF";
			this.Text = "vCard Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainF_FormClosing);
			this.Resize += new System.EventHandler(this.MainF_Resize);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.listViewCMS.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.detailsGB.ResumeLayout(false);
			this.detailsGB.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		System.Windows.Forms.MenuStrip menuStrip;
		System.Windows.Forms.ToolStripMenuItem fileTSMI;
		System.Windows.Forms.ToolStripMenuItem openTSMI;
		System.Windows.Forms.ToolStripMenuItem saveTSMI;
		System.Windows.Forms.ToolStripMenuItem saveAsTSMI;
		System.Windows.Forms.ToolStripMenuItem helpTSMI;
		System.Windows.Forms.ListView listView;
		System.Windows.Forms.PictureBox pictureBox;
		System.Windows.Forms.GroupBox detailsGB;
		System.Windows.Forms.Label infoL;
		System.Windows.Forms.ContextMenuStrip listViewCMS;
		System.Windows.Forms.ToolStripMenuItem editTSMI;
		System.Windows.Forms.ToolStripMenuItem removeTSMI;
		System.Windows.Forms.ToolStripMenuItem addTSMI;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		System.Windows.Forms.ToolStripMenuItem combineTSMI;
		System.Windows.Forms.ToolStripMenuItem languageTSMI;
		System.Windows.Forms.ColumnHeader nameCH;
		System.Windows.Forms.ColumnHeader lastnameCH;
		System.Windows.Forms.ColumnHeader phoneCH;
		System.Windows.Forms.ToolStripMenuItem spanishTSMI;
		System.Windows.Forms.ToolStripMenuItem englishTSMI;
		System.Windows.Forms.ToolStripMenuItem frenchTSMI;
		System.Windows.Forms.OpenFileDialog sofd;
		System.Windows.Forms.OpenFileDialog mofd;
		System.Windows.Forms.SaveFileDialog sfd;
		System.Windows.Forms.ToolStripMenuItem hhelpTSMI;
		System.Windows.Forms.ToolStripMenuItem checkUpdatesTSMI;
		System.Windows.Forms.ToolStripMenuItem newTSMI;
	}
}

