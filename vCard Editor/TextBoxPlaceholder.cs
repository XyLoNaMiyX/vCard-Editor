using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vCard_Editor
{
	public partial class TextBoxPlaceholder : TextBox
	{
		public string Placeholder;
		public Color PlaceholderColor;
		public Color UnvariantForeColor;

		bool IsPlaceholderActive = true;

		public TextBoxPlaceholder()
		{
			InitializeComponent();

			this.GotFocus += TextBoxPlaceholder_GotFocus;
			this.LostFocus += TextBoxPlaceholder_LostFocus;
			this.TextChanged += TextBoxPlaceholder_TextChanged;
		}

		public override string Text
		{
			get
			{
				if (IsPlaceholderActive && base.Text == Placeholder)
					return String.Empty;

				return base.Text;
			}
			set { base.Text = value; }
		}

		protected override void OnCreateControl()
		{
			((Form)this.Parent).FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

			IsPlaceholderActive = true;
			this.Text = this.Placeholder;
			this.ForeColor = this.PlaceholderColor;

			base.OnCreateControl();
		}

		void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.PlaceholderColor == this.ForeColor && this.Text == this.Placeholder)
			{
				IsPlaceholderActive = false;
				this.ForeColor = this.UnvariantForeColor;
				this.Text = "";
			}
		}

		void TextBoxPlaceholder_TextChanged(object sender, EventArgs e)
		{
			if (Text == Placeholder) {
				IsPlaceholderActive = true;
				ForeColor = PlaceholderColor;
			}
			else if (Text == "" && ForeColor == PlaceholderColor) {
				IsPlaceholderActive = true;
				Text = Placeholder;
			}
			else if (Text != "" || Text != Placeholder) {
				IsPlaceholderActive = false;
				ForeColor = UnvariantForeColor;
			}
		}

		void TextBoxPlaceholder_LostFocus(object sender, System.EventArgs e)
		{
			if (this.Text == "")
			{
				Text = Placeholder;
				ForeColor = PlaceholderColor;
				IsPlaceholderActive = true;
			}
		}

		void TextBoxPlaceholder_GotFocus(object sender, System.EventArgs e)
		{
			if (IsPlaceholderActive)
			{
				IsPlaceholderActive = false;
				ForeColor = UnvariantForeColor;
				Text = "";
			}
		}
	}
}
