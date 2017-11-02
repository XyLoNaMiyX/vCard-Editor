using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vCard_Editor
{
	public partial class MainF : Form
	{
		#region Set up and variables

		public MainF()
		{
			InitializeComponent();
			string lang = Properties.Settings.Default.lang;
			if (lang == "es")
				spanishTSMI.Checked = true;
			if (lang == "en")
				englishTSMI.Checked = true;
			if (lang == "fr")
				frenchTSMI.Checked = true;
		}

		VCard[] vcards = new VCard[0];

		string openedPath = "";

		bool changesSaved = true;

		#endregion

		#region Menu strip

		void openTSMI_Click(object sender, EventArgs e)
		{
			if (sofd.ShowDialog() == DialogResult.OK)
				LoadVCard(sofd.FileName);
		}
		void newTSMI_Click(object sender, EventArgs e)
		{
			if (!changesSaved)
				if (ChangesMade() == DialogResult.Yes)
					Save("2.1");

			openedPath = "";
			vcards = new VCard[0];
			RefreshVCards();
			changesSaved = true;
		}

		void combineTSMI_Click(object sender, EventArgs e)
		{
			if (mofd.ShowDialog() == DialogResult.OK)
				AddVCards(mofd.FileNames);
		}

		void saveTSMI_Click(object sender, EventArgs e) { Save(); }

		void saveAsTSMI_Click(object sender, EventArgs e) { SaveAs(); }

		void helpTSMI_Click(object sender, EventArgs e)
		{
			string lang = GetCheckedLang();
			if (lang == "en")
				MessageBox.Show("For english documentation about vCard Editor, please check out the next website:" +
					"\r\nhttp://lonamiwebs.github.io/docs/en", "Documentation not available", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			else if (lang == "fr")
				MessageBox.Show("Pour la documentation française sur vCard Editor, s'il vous plaît consulter le site Web suivant:" +
					"\r\nhttp://lonamiwebs.github.io/docs/fr", "Documentation non disponible", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			else
				new HelpF().Show();
		}

		#endregion

		#region vCard loading & refreshing

		void LoadVCard(string path) {
			if (!changesSaved)
				if (ChangesMade() == DialogResult.Yes)
					Save("2.1");

			openedPath = path;
			vcards = VCard.ReadVCards(File.ReadAllLines(path));
			RefreshVCards();
			changesSaved = true;
		}

		void AddVCards(string[] paths) {
			List<VCard> vc = vcards.ToList();
			foreach (string card in paths)
				vc.AddRange(VCard.ReadVCards(File.ReadAllLines(card)));

			vcards = vc.ToArray();
			RefreshVCards();
		}

		void RefreshVCards() {
			listView.Items.Clear();

			foreach (VCard vcard in vcards)
				if (vcard.PhoneNumbers.Count > 0)
					listView.Items.Add(new ListViewItem(new[] {
						vcard.SurName,
						vcard.LastName,
						vcard.PhoneNumbers[0]
					}));
				else
					listView.Items.Add(new ListViewItem(new[] {
						vcard.SurName,
						vcard.LastName
					}));

			changesSaved = false;
		}

		#endregion

		#region vCard Saving

		void Save() {
			if (openedPath != "")
				Save(openedPath);
			else
				SaveAs();
		}

		void SaveAs()
		{
			if (sfd.ShowDialog() == DialogResult.OK)
				Save(sfd.FileName);
		}

		void Save(string path) {
			try
			{
				openedPath = path;
				File.WriteAllText(path, VCard.SaveVCards(vcards), Encoding.ASCII);
				changesSaved = true;
			}
			catch { MessageBox.Show(couldNotSaveC, couldNotSaveT, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		string couldNotSaveC = "No se pudo guardar el archivo actual. Pruebe a guardarlo en una ruta diferente";
		string couldNotSaveT = "Error el guardar archivo";

		#endregion

		#region Info refreshing

		void listView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView.SelectedIndices.Count > 0)
			{
				int i = listView.SelectedIndices[0];
				if (i < vcards.Length)
					RefreshInfo(i);
			} 
		}

		void RefreshInfo(int index) {
			VCard vc = vcards[index];
			if (vc.ProfileImage == null)
			{
				pictureBox.Visible = false;
				pictureBox.Height = 0;
			}
			else {
				pictureBox.Visible = true;
				pictureBox.Height = 100;

				pictureBox.Image = vc.ProfileImage;
			}

			StringBuilder info = new StringBuilder();
			if (vc.SurName != "")
				if (vc.LastName != "")
					info.AppendLine(vc.SurName + ", " + vc.LastName);
				else
					info.AppendLine(vc.SurName);
			else
				if (vc.LastName != "")
					info.AppendLine(vc.LastName);
				else
					info.AppendLine(unnamed);

			StringBuilder phones = new StringBuilder();
			foreach (string phone in vc.PhoneNumbers)
				phones.AppendLine(phone);

			info.AppendLine(phones.ToString());

			if (vc.Organization != "")
				info.AppendLine(vc.Organization);
			if (vc.Url != "")
				info.AppendLine(vc.Url);
			if (vc.Email != "")
				info.AppendLine(vc.Email);

			StringBuilder addresses = new StringBuilder();
			foreach (string address in vc.Addresses)
				addresses.AppendLine(address);

			info.AppendLine(addresses.ToString());

			infoL.Text = info.ToString();

			RefreshInfoLAndMS();

			listView.Items[index].Selected = true;
			listView.Items[index].Focused = true;
		}

		string unnamed = "Sin nombre";

		void RefreshInfoLAndMS() {
			infoL.MaximumSize = new Size(detailsGB.Width - 4, detailsGB.Height - pictureBox.Height - 8);
			infoL.Location = new Point(3, pictureBox.Height + (infoL.Height / 2));
		}

		#endregion

		#region Adding, editing and removing cards

		public void AddCard(VCard vcard) {
			List<VCard> vcrds = vcards.ToList();
			vcrds.Add(vcard);
			vcards = vcrds.ToArray();
			RefreshVCards();
		}

		public void EditCard(VCard vcard, int index) {
			vcards[index] = vcard;
			RefreshVCards();
			RefreshInfo(index);

			listView.TopItem = listView.Items[index];
		}

		void RemoveCard(int index)
		{
			if (MessageBox.Show(ensureRemoveC + vcards[index].SurName + " " + 
				vcards[index].LastName + "?", ensureRemoveT, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
				== DialogResult.Yes)
			{
				List<VCard> vcrds = vcards.ToList();
				vcrds.RemoveAt(index);
				vcards = vcrds.ToArray();
				RefreshVCards();
			}
		}

		void RemoveCards(int[] indicies) {
				if (MessageBox.Show("¿Estás seguro de que quieres eliminar " + indicies.Length + " contactos?",
				"Eliminar contactos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
				== DialogResult.Yes) {
					List<VCard> vcrds = vcards.ToList();

					foreach (int i in indicies)
						vcrds[i] = null;

					vcrds.RemoveAll(x => x == null);

					vcards = vcrds.ToArray();
					RefreshVCards();
				}
		}

		string ensureRemoveC = "¿Estás seguro de que quieres eliminar a ";
		string ensureRemoveT = "Eliminar contacto";

		#endregion

		#region Context Menu Strip

		void addTSMI_Click(object sender, EventArgs e)
		{
			new ContactF().Show();
		}

		void listView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				foreach (int i in listView.SelectedIndices)
					new ContactF(vcards[i], i).Show();
			else if (e.KeyCode == Keys.Delete)
				Remove();
		}

		void editTSMI_Click(object sender, EventArgs e)
		{
			foreach (int i in listView.SelectedIndices)
				new ContactF(vcards[i], i).Show();
		}

		void listView_DoubleClick(object sender, EventArgs e)
		{
			foreach (int i in listView.SelectedIndices)
				new ContactF(vcards[i], i).Show();
		}

		void removeTSMI_Click(object sender, EventArgs e) {
			Remove();
		}

		void Remove() {
			int c = listView.SelectedIndices.Count;
			if (c > 1) {
				int[] indicies = new int[c];
				for (int i = 0; i < c; i++)
					indicies[i] = listView.SelectedIndices[i];

				RemoveCards(indicies);
			}
			else if (c == 1)
				RemoveCard(listView.SelectedIndices[0]);
		}

		void listViewCMS_Opening(object sender, CancelEventArgs e)
		{
			int i = EnsureLV();
			if (i != -1) {
				editTSMI.Enabled = true;
				removeTSMI.Enabled = true;
			} else {
				editTSMI.Enabled = false;
				removeTSMI.Enabled = false;
			}
		}

		int EnsureLV() {
			int i = -1;
			
			if (listView.SelectedIndices.Count > 0)
				if (i < vcards.Length)
					i = listView.SelectedIndices[0];

			return i;
		}

		#endregion

		#region Drag'n'drop

		void listView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		void listView_DragDrop(object sender, DragEventArgs e)
		{
			string[] draggedcards = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			AddVCards(draggedcards);
		}

		#endregion

		#region Form resizing, closing and prompting

		void MainF_Resize(object sender, EventArgs e)
		{
			RefreshInfoLAndMS();
		}

		void MainF_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!changesSaved)
				if (ChangesMade() == DialogResult.Yes)
					Save();
		}

		DialogResult ChangesMade() {
			return MessageBox.Show(listChangedC, listChangedT, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		}

		string listChangedC = "La lista de contactos actual ha sufrido cambios y todavía no se ha guardado. Si no guarda, estos cambios se perderán. ¿Desea guardar la lista ahora?";
		string listChangedT = "Cambios sin guardar";

		#endregion

		#region Language

		public string GetCheckedLang() {
			if (spanishTSMI.Checked)
				return "es";
			else if (englishTSMI.Checked)
				return "en";
			else if (frenchTSMI.Checked)
				return "fr";

			return "es";
		}

		void spanishTSMI_CheckedChanged(object sender, EventArgs e)
		{
			if (spanishTSMI.Checked)
			{
				SetLang("es");
				spanishTSMI.Checked = true;
				englishTSMI.Checked = false;
				frenchTSMI.Checked = false;
			}
		}

		void englishTSMI_CheckedChanged(object sender, EventArgs e)
		{
			if (englishTSMI.Checked)
			{
				SetLang("en");
				spanishTSMI.Checked = false;
				englishTSMI.Checked = true;
				frenchTSMI.Checked = false;
			}
		}

		void frenchTSMI_CheckedChanged(object sender, EventArgs e)
		{
			if (frenchTSMI.Checked)
			{
				SetLang("fr");
				spanishTSMI.Checked = false;
				englishTSMI.Checked = false;
				frenchTSMI.Checked = true;
			}
		}


		void SetLang(string lang)
		{
			if (lang == "es")
			{
				fileTSMI.Text = "Archivo";
				openTSMI.Text = "Abrir";
				saveTSMI.Text = "Guardar";
				saveAsTSMI.Text = "Guardar como...";
				combineTSMI.Text = "Combinar vCards";
				helpTSMI.Text = "Ayuda";
				editTSMI.Text = "Editar contacto";
				removeTSMI.Text = "Eliminar contacto";
				addTSMI.Text = "Añadir contacto";
				detailsGB.Text = "Detalles";
				languageTSMI.Text = "Lenguaje";
				spanishTSMI.Text = "Español";
				englishTSMI.Text = "Inglés";
				frenchTSMI.Text = "Francés";
				nameCH.Text = "Nombre";
				lastnameCH.Text = "Apellidos";
				phoneCH.Text = "Teléfono";
				sofd.Title = "Elija un archivo vCard";
				mofd.Title = "Elija uno o varios archivos vCard";
				sofd.Filter = mofd.Filter = sfd.Filter = "Archivo vCard|*.vcf;*.vcard";
				sfd.Title = "Elija donde guardar el archivo vCard";
				couldNotSaveC = "No se pudo guardar el archivo actual. Pruebe a guardarlo en una ruta diferente";
				couldNotSaveT = "Error el guardar archivo";
				unnamed = "Sin nombre";
				ensureRemoveC = "¿Estás seguro de que quieres eliminar a ";
				ensureRemoveT = "Eliminar contacto";
				listChangedC = "La lista de contactos actual ha sufrido cambios y todavía no se ha guardado. Si no guarda, estos cambios se perderán. ¿Desea guardar la lista ahora?";
				listChangedT = "Cambios sin guardar";
			}
			if (lang == "en")
			{
				fileTSMI.Text = "File";
				openTSMI.Text = "Open";
				saveTSMI.Text = "Save";
				saveAsTSMI.Text = "Save as...";
				combineTSMI.Text = "Combine vCards";
				helpTSMI.Text = "Help";
				editTSMI.Text = "Edit contact";
				removeTSMI.Text = "Remove contact";
				addTSMI.Text = "Add contact";
				detailsGB.Text = "Details";
				languageTSMI.Text = "Language";
				spanishTSMI.Text = "Spanish";
				englishTSMI.Text = "English";
				frenchTSMI.Text = "French";
				nameCH.Text = "Name";
				lastnameCH.Text = "Lastnames";
				phoneCH.Text = "Phone number";
				sofd.Title = "Pick a vCard file";
				mofd.Title = "Pick one or more vCard files";
				sofd.Filter = mofd.Filter = sfd.Filter = "vCard file|*.vcf;*.vcard";
				sfd.Title = "Pick where to save the vCard file";
				couldNotSaveC = "An error occured while trying to save the current file. Try saving it in another path";
				couldNotSaveT = "An error occured";
				unnamed = "Unnamed";
				ensureRemoveC = "Are you sure you want to remove to ";
				ensureRemoveT = "Remove contact";
				listChangedC = "Unsaved changes have been made to the current contact list. If you don't save it, these changes will be lost. Do you wish to save the list now?";
				listChangedT = "Unsaved changes";
			}
			if (lang == "fr")
			{
				fileTSMI.Text = "Fichier";
				openTSMI.Text = "Ouvrir";
				saveTSMI.Text = "Enregistrer";
				saveAsTSMI.Text = "Enregistrer sous...";
				combineTSMI.Text = "Combine vCards";
				helpTSMI.Text = "Aide";
				editTSMI.Text = "Modifie le contact";
				removeTSMI.Text = "Retirer le contact";
				addTSMI.Text = "Ajouter un contact";
				detailsGB.Text = "Détails";
				languageTSMI.Text = "Langue";
				spanishTSMI.Text = "Espagnol";
				englishTSMI.Text = "Anglais";
				frenchTSMI.Text = "Français";
				nameCH.Text = "Nom";
				lastnameCH.Text = "Noms";
				phoneCH.Text = "Téléphone";
				sofd.Title = "Sélectionner fichier vCard";
				mofd.Title = "Sélectionnez un ou plusieurs fichiers vCard";
				sofd.Filter = mofd.Filter = sfd.Filter = "Fichier vCard|*.vcf;*.vcard";
				sfd.Title = "Choisissez l'emplacement où enregistrer le fichier vCard";
				couldNotSaveC = "Impossible d'enregistrer le fichier en cours. Essayez d'enregistrer un itinéraire différent";
				couldNotSaveT = "Enregistrer le fichier erreur";
				unnamed = "Sans nom";
				ensureRemoveC = "Etes-vous sûr de vouloir supprimer ";
				ensureRemoveT = "Supprimer le contact";
				listChangedC = "La liste de contacts a été changé et pas enregistré encore. Si pas enregistré, ces modifications seront perdues. Voulez-vous enregistrer la liste maintenant?";
				listChangedT = "Modifications non enregistrées";
			}

			Properties.Settings.Default.lang = lang;
			Properties.Settings.Default.Save();
		}

		#endregion

		void checkUpdatesTSMI_Click(object sender, EventArgs e)
		{
			new UpdateChecker.UpdateChecker(System.Reflection.Assembly.GetExecutingAssembly().Location, "vce").Show();
		}
	}
}
