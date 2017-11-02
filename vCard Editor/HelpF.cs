using System;
using System.Windows.Forms;

namespace vCard_Editor
{
	public partial class HelpF : Form
	{
		public HelpF()
		{
			InitializeComponent();
		}

		void HelpF_Load(object sender, EventArgs e)
		{
			helpRTB.Rtf = Properties.Resources.help;
		}
	}
}
