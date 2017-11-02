namespace UpdateChecker
{
	partial class UpdateChecker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateChecker));
			this.checkB = new System.Windows.Forms.Button();
			this.infoL = new System.Windows.Forms.Label();
			this.checkingPB = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// checkB
			// 
			this.checkB.Location = new System.Drawing.Point(12, 82);
			this.checkB.Name = "checkB";
			this.checkB.Size = new System.Drawing.Size(288, 23);
			this.checkB.TabIndex = 0;
			this.checkB.Text = "Comprobar actualizaciones";
			this.checkB.UseVisualStyleBackColor = true;
			this.checkB.Click += new System.EventHandler(this.checkB_Click);
			// 
			// infoL
			// 
			this.infoL.AutoSize = true;
			this.infoL.Location = new System.Drawing.Point(13, 13);
			this.infoL.Name = "infoL";
			this.infoL.Size = new System.Drawing.Size(273, 26);
			this.infoL.TabIndex = 1;
			this.infoL.Text = "Presione el botón de \"Comprobar actualizaciones\" para\r\ncomprobar si existe una nu" +
	"eva versión de este programa";
			// 
			// checkingPB
			// 
			this.checkingPB.Location = new System.Drawing.Point(12, 53);
			this.checkingPB.MarqueeAnimationSpeed = 0;
			this.checkingPB.Name = "checkingPB";
			this.checkingPB.Size = new System.Drawing.Size(288, 23);
			this.checkingPB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.checkingPB.TabIndex = 2;
			// 
			// UpdateChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 113);
			this.Controls.Add(this.checkingPB);
			this.Controls.Add(this.infoL);
			this.Controls.Add(this.checkB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateChecker";
			this.Text = "Comprobar actualizaciones";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		System.Windows.Forms.Button checkB;
		System.Windows.Forms.Label infoL;
		System.Windows.Forms.ProgressBar checkingPB;
	}
}

