using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace UpdateChecker
{
	public partial class UpdateChecker : Form
	{

		#region Variables and setup

		public UpdateChecker(string filepath, string shortname)
		{
			InitializeComponent();

			CurrentVersion = GetVersionFromFile(filepath);
			FileShortname = shortname;
			Architecture = GetArchitecture(filepath);
		}

		int GetVersionFromFile(string file) {
			var versionInfo = FileVersionInfo.GetVersionInfo(file);
			string version = versionInfo.ProductVersion;

			return Int32.Parse(version.Replace(".", ""));
		}

		string GetArchitecture(string file) {
			var assembly = AssemblyName.GetAssemblyName(file);
			string sassembly = assembly.ProcessorArchitecture.ToString().ToLower();

			if (sassembly.Contains("64"))
				return "64";
			else if (sassembly.Contains("86"))
				return "86";
			else
				return "";
		}

		int CurrentVersion;
		int NewVersion = 0;
		string FileShortname;
		string Filename = "Unknown";
		string Architecture;

		#endregion

		#region Check button

		void checkB_Click(object sender, EventArgs e)
		{
			switch (checkB.Text)
			{
				case "Actualizar":
					DownloadUpdate();
					break;
				case "Aceptar y salir":
					this.Close();
					break;

				default:
					CheckUpdates();
					break;
			}
		}

		#endregion

		#region Check updates

		void CheckUpdates()
		{
			checkingPB.MarqueeAnimationSpeed = 10;
			infoL.Text = "Comprobando actualizaciones...";
			
			Uri uri = new Uri ("http://lonamiwebs.github.io/_DOWNLOADS/checkupdates.php?q=" + FileShortname);
			string lwa = "permission=lwAccess";

			using (WebClient wc = new WebClient())
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);

				try { wc.UploadStringAsync(uri, lwa); }
				catch { }
			}
		}


		void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				infoL.Text = "No se pudo comprobar si existen actualizaciones\r\n" +
					"Compruebe que dispone de conexión a internet";
				return;
			}

			checkingPB.MarqueeAnimationSpeed = 0;
			checkingPB.Style = ProgressBarStyle.Continuous;

			NewVersion = Int32.Parse(e.Result);
			if (NewVersion > CurrentVersion)
			{
				infoL.Text = "Se ha encontrado una nuva versión\r\n"
				+ "Haga clic en actualizar para descargarla atuomáticamente";

				checkB.Text = "Actualizar";
			}
			else
			{
				infoL.Text = "Ya está utilizando la última versión\r\n"
				+ "No es necesario actualizar";

				checkB.Text = "Aceptar y salir";
			}
		}

		#endregion

		#region Update

		void DownloadUpdate() {
			SetTextUpdating(0);
			checkB.Text = "Actualizando...";
			checkB.Enabled = false;

			string fileurl = new WebClient().DownloadString(
				"http://lonamiwebs.github.io/_DOWNLOADS/getfileurl.php?q=" + FileShortname + Architecture);
			Uri uri = new Uri(fileurl);
			Filename = fileurl.Split('/')[fileurl.Split('/').Length - 1].Replace("%20", "");

			using (WebClient wc = new WebClient())
			{
				wc.DownloadProgressChanged += wc_DownloadProgressChanged;
				wc.DownloadFileCompleted += wc_DownloadFileCompleted;

				wc.DownloadFileAsync(uri, Filename);
			}
		}

		void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double percentage = (double)e.BytesReceived / (double)e.TotalBytesToReceive * 100d;
			SetTextUpdating(percentage);
			checkingPB.Value = e.ProgressPercentage;
		}

		void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			string path = Path.GetFullPath(Filename);
			Debug.WriteLine("Exists " + path + "? " + File.Exists(path));
			if (MessageBox.Show("El programa se ha descargado correctamente.\r\n\r\nBorre la versión actual y " +
				"extraiga el archivo comprimido descargado en:\r\n" + path + "\r\n\r\n¿Desea abrir la carpeta?",
				"Actualización descargada", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				Process.Start(new ProcessStartInfo() { FileName = "explorer.exe",
					Arguments = "/e, /select, \"" + path + "\""});

			this.Close();
		}

		void SetTextUpdating(double percentage)
		{
			string cv = String.Join(".", CurrentVersion.ToString("D" + 4).ToCharArray());
			string nv = String.Join(".", NewVersion.ToString("D" + 4).ToCharArray());
			infoL.Text = "Actualizando desde la versión " + cv + "\r\n" +
				"a la última versión disponible " + nv + "... " + percentage.ToString("F") + "%";
		}

		#endregion
	}
}
