using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace vCard_Editor
{
	public partial class ContactF : Form
	{
		public ContactF()
		{
			InitializeComponent();
			LoadLang(false);
		}

		public ContactF(VCard card, int indx)
		{
			vcard = card;
			index = indx;
			InitializeComponent();
			LoadLang(true);
		}

		VCard vcard = new VCard();
		int index = -1;

		void ContactF_Load(object sender, EventArgs e)
		{
			nameTBP.Text = vcard.SurName;
			lastnameTBP.Text = vcard.LastName;
			displaynamePTB.Text = vcard.DisplayName;
			emailPTB.Text = vcard.Email;
			StringBuilder sb = new StringBuilder();
			foreach (string phone in vcard.PhoneNumbers)
				sb.AppendLine(phone);
			phoneTBP.Text = sb.ToString();
			sb = new StringBuilder();
			foreach (string address in vcard.Addresses)
				sb.AppendLine(address);
			addressesTPB.Text = sb.ToString();
			organizationPTB.Text = vcard.Organization;
			urlPTB.Text = vcard.Url;
			pictureBox.Image = vcard.ProfileImage;
		}

		void acceptB_Click(object sender, EventArgs e) {
			Accept();
		}

		void Accept()
		{

			List<string> addresses = addressesTPB.Text.Split('\n').ToList();
			addresses.RemoveAll(string.IsNullOrWhiteSpace);
			
			var card = new VCard()
			{
				SurName = nameTBP.Text,
				LastName = lastnameTBP.Text,
				DisplayName = displaynamePTB.Text,
				AllNames = new string[5] { lastnameTBP.Text, nameTBP.Text,
					vcard.AllNames[2], vcard.AllNames[3], vcard.AllNames[4] },

				ProfileImage = pictureBox.Image,
				
				Email = emailPTB.Text,
				
				Addresses = addresses.ToArray(),
				
				Organization = organizationPTB.Text,
				Url = urlPTB.Text
			};

			card.PhoneNumbers.AddRange(phoneTBP.Text.Split('\n'));
			card.PhoneNumbers.RemoveAll(string.IsNullOrWhiteSpace);

			var f = (MainF)Application.OpenForms["MainF"];

			if (index < 0)
				f.AddCard(card);
			else
				f.EditCard(card, index);

			Close();
		}

		void cancelB_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void PickImage() {
			string imgexts = "*.jpg;*.gif;*.png;*.bmp;*.jpe;*.jpeg;*.wmf;*.emf;*.xbm;*.ico;*.eps;*.tif;*.tiff;*.g01;*.g02;*.g03;*.g04;*.g05;*.g06;*.g07;*.g08";
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Elija una nueva imagen de perfil";
			ofd.Filter = "Archivos de imagen|" + imgexts + "|Todos los archivos|*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (IsValidImage(ofd.FileName))
					pictureBox.Image = ResizeImage(Image.FromFile(ofd.FileName), pictureBox.Size);
				else
					MessageBox.Show("La imagen elegida no es válida o está dañada", "Imagen no válida",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Image utils

		bool IsValidImage(string filename)
		{
			try
			{
				Image newImage = Image.FromFile(filename);
			}
			catch  { return false; }

			return true;
		}

		public static Image ResizeImage(Image imgToResize, Size size)
		{
			return (Image)(new Bitmap(imgToResize, size));
		}

		public void ExportToBmp(string path)
		{ //this way we don't have unwanted exceptions
			using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
			{
				pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
				ImageFormat imageFormat = null;

				string extension = Path.GetExtension(path);
				switch (extension)
				{
					case ".bmp":
						imageFormat = ImageFormat.Bmp;
						break;
					case ".png":
						imageFormat = ImageFormat.Png;
						break;
					case ".jpeg":
					case ".jpg":
						imageFormat = ImageFormat.Jpeg;
						break;
					case ".gif":
						imageFormat = ImageFormat.Gif;
						break;
					case ".tiff":
						imageFormat = ImageFormat.Tiff;
						break;
					default:
						imageFormat = ImageFormat.Png;
						break;
				}

				bitmap.Save(path, imageFormat);
			}
		}

		#endregion

		void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				PickImage();
		}

		#region Context Menu Strip

		void changeImgTSMI_Click(object sender, EventArgs e)
		{
			PickImage();
		}

		void saveImgTSMI_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Elija donde guardar la imagen";
			sfd.Filter = "Archivo de imagen Portable Network Graphics|*.png|Archivo de imagen comprimido|*.jpg;*.jpeg|" +
				"Archivo en formato de intercambios de gráficos|*.gif|Archivo de mapa de bits|*.bmp|Archivo de imagen etiquetado|*.tiff|Todos los archivos|*";
			if (sfd.ShowDialog() == DialogResult.OK)
				ExportToBmp(sfd.FileName);
		}

		void copyImgTSMI_Click(object sender, EventArgs e)
		{
			using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
			{ //we don't want ObjectDisposedException nor ExternalExceptions
				pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
				Clipboard.SetImage(bitmap);
			}
		}

		#endregion



		void displaynamePTB_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Accept();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}



		#region Language

		public void LoadLang(bool edit)
		{
			MainF f = (MainF)Application.OpenForms["MainF"];
			SetLang(f.GetCheckedLang(), edit);
		}

		void SetLang(string lang, bool edit)
		{
			if (lang == "es")
			{
				acceptB.Text = "Aceptar";
				cancelB.Text = "Cancelar";
				changeImgTSMI.Text = "Cambiar imagen";
				saveImgTSMI.Text = "Guardar imagen";
				copyImgTSMI.Text = "Copiar imagen";
				nameTBP.Placeholder = "Nombre";
				displaynamePTB.Placeholder = "Nombre a mostrar";
				lastnameTBP.Placeholder = "Apellido(s)";
				phoneTBP.Placeholder = "Teléfono (uno por línea)";
				emailPTB.Placeholder = "Correo electrónico";
				addressesTPB.Placeholder = "Direcciones (una por línea)";
				organizationPTB.Placeholder = "Organización";
				urlPTB.Text = "Dirección URL";
				if (edit)
					this.Text = "Editar contacto";
				else
					this.Text = "Añadir contacto";
			}
			if (lang == "en")
			{
				acceptB.Text = "Accept";
				cancelB.Text = "Cancel";
				changeImgTSMI.Text = "Change image";
				saveImgTSMI.Text = "Save image";
				copyImgTSMI.Text = "Copy image";
				nameTBP.Placeholder = "Name";
				displaynamePTB.Placeholder = "Display name";
				lastnameTBP.Placeholder = "Last name(s)";
				phoneTBP.Placeholder = "Phone numbers (one per line)";
				emailPTB.Placeholder = "Email";
				addressesTPB.Placeholder = "Addresses (one per line)";
				organizationPTB.Placeholder = "Organization";
				urlPTB.Text = "URL";
				if (edit)
					this.Text = "Edit contact";
				else
					this.Text = "Add contact";
			}
			if (lang == "fr")
			{
				acceptB.Text = "Accepter";
				 cancelB.Text = "Annuler";
				 changeImgTSMI.Text = "Changer l'image";
				 saveImgTSMI.Text = "Enregistrer l'image";
				 copyImgTSMI.Text = "Copier l'image";
				 nameTBP.Placeholder = "Nom";
				 displaynamePTB.Placeholder = "Nom d'affichage";
				 lastnameTBP.Placeholder = "Nom(s)";
				 phoneTBP.Placeholder = "Numéros de téléphone (un par ligne)";
				 emailPTB.Placeholder = "Email";
				 addressesTPB.Placeholder = "Adresses (un par ligne)";
				 organizationPTB.Placeholder = "Organisation";
				 urlPTB.Text = "URL";
				 if (edit)
					 this.Text = "Modifie contact";
				 else
					 this.Text = "Ajouter contact";
			}
		}

		#endregion

	}
}
