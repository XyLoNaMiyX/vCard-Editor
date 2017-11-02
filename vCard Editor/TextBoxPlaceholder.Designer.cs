namespace vCard_Editor
{
	partial class TextBoxPlaceholder : System.Windows.Forms.TextBox
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		void InitializeComponent()
		{
			components = new System.ComponentModel.Container();

			this.Text = this.Placeholder;
			this.PlaceholderColor = System.Drawing.Color.DarkGray;
			this.UnvariantForeColor = this.ForeColor;
		}

		#endregion
	}
}
