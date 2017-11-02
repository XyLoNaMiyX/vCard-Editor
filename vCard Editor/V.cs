using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;

namespace vCard_Editor
{
	public static class Variables
	{
		public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			+ @"\LonamiWebs\vCard Editor";
	}

	public class VCard
	{
		public string LastName { get; set; }
		public string SurName { get; set; }
		public string[] AllNames { get; set; }
		public string DisplayName { get; set; }
		public Image ProfileImage { get; set; }
		public string Organization { get; set; }
		public string Url { get; set; }
		public string Email { get; set; }
		public List<string> PhoneNumbers { get; set; }
		public string[] Addresses { get; set; }


		public VCard()
		{
			LastName = "";
			SurName = "";
			AllNames = new string[5];
			DisplayName = "";
			ProfileImage = null;
			Email = "";
			PhoneNumbers = new List<string>();
			Addresses = new string[0];
			Organization = "";
			Url = "";
		}

		public VCard(string lastName, string surName, string email, string phone) {
			LastName = lastName;
			SurName = surName;
			DisplayName = surName + " " + lastName;
			AllNames = new string[5] { lastName, surName, "", "", "" };
			ProfileImage = null;
			Email = email;
			PhoneNumbers = new List<string>();
			PhoneNumbers.Add(phone);
			Addresses = new string[0];
			Organization = "";
			Url = "";
		}

		const string quotedPrintable = "QUOTED-PRINTABLE:";
		
		public static VCard[] ReadVCards(string[] vcardlines)
		{
			int cards = 0;
			foreach (string line in vcardlines)
				if (line.StartsWith("BEGIN:VCARD"))
					cards++;

			VCard[] vcards = new VCard[cards];
			
			for (int i = 0; i < cards; i++)
				vcards[i] = new VCard();

			int j = 0;

			bool isimage = false;
			var imagetext = new StringBuilder();

			foreach (string line in vcardlines)
			{
				if (line.StartsWith("N:"))
				{
					vcards[j].LastName = line.Split(':')[1].Split(';')[0];

					if (line.Split(':')[1].Split(';').Length > 1) // ...? What "N:" is this (<= 1)?
						vcards[j].SurName = line.Split(':')[1].Split(';')[1];

					vcards[j].AllNames = line.Split(':')[1].Split(';');
				}
				else if (line.StartsWith("N;CHARSET="))
				{
					if (line.Contains(quotedPrintable))
					{
						string charset = line.Split(new String[] { "N;CHARSET=" },
													StringSplitOptions.None)[1].Split(';')[0];
						string coded = line.Split(new String[] { quotedPrintable },
												  StringSplitOptions.RemoveEmptyEntries)[1];
						
						var spl = coded.Split(';');
						for (int i = 0; i < spl.Length; i++)
							spl[i] = DecodeString(spl[i], charset);
						
						vcards[j].LastName = spl[0];
	
						if (spl.Length > 1) // ...? What "N:" is this (<= 1)?
							vcards[j].SurName = spl[1];
	
						vcards[j].AllNames = spl;
					}
				}
				
				if (isimage)
				{
					if (line == "" || line.StartsWith("END:VCARD")) {
						vcards[j].ProfileImage = Base64ToImage(imagetext.ToString());

						isimage = false;
					}
					else if (line.StartsWith(" "))
							imagetext.Append(line);
				}

				if (line.StartsWith("PHOTO;"))
				{
					isimage = true;
					imagetext = new StringBuilder();
					imagetext.AppendLine(line.Split(':')[1]);
				}

				if (line.StartsWith("FN:"))
					vcards[j].DisplayName = line.Split(':')[1];
				if (line.StartsWith("ORG:"))
					vcards[j].Organization = line.Split(':')[1];
				if (line.StartsWith("URL:"))
					vcards[j].Url = line.Split(':')[1];
				if (line.StartsWith("EMAIL:"))
					vcards[j].Email = line.Split(':')[1];
				if (line.StartsWith("TEL;"))
					vcards[j].PhoneNumbers.Add(line.Split(':')[1]);
				if (line.StartsWith("ADR:"))
					vcards[j].Addresses = line.Split(':')[1].Split(new string[] { ";;" }, StringSplitOptions.None);

				if (line.Contains("END:VCARD"))
					j++;
			}

			return vcards;
		}

		static string DecodeString(string strBytes, string encoding)
		{
			string[] bytes = strBytes.Split('=');

			var byteres = new List<byte>();
			
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i].Length == 2)
					byteres.Add(byte.Parse(bytes[i], NumberStyles.HexNumber));
			}
			
			switch (encoding)
			{
				case "UTF-8":
					return Encoding.UTF8.GetString(byteres.ToArray());
					
				default:
					return Encoding.Default.GetString(byteres.ToArray());
			}
		}

		public static string SaveVCards(VCard[] vcards)
		{
			var sb = new StringBuilder();

			foreach (VCard vcard in vcards)
			{
				sb.AppendLine("BEGIN:VCARD");
				sb.AppendLine("VERSION:2.1");
				if (vcard.AllNames.Length > 0)
					sb.AppendLine("N:" + String.Join(";", vcard.AllNames));
				if (vcard.DisplayName.Length > 0)
					sb.AppendLine("FN:" + vcard.DisplayName);
				if (vcard.Organization.Length > 0)
					sb.AppendLine("ORG:" + vcard.Organization);
				if (vcard.Url.Length > 0)
					sb.AppendLine("URL:" + vcard.Url);
				if (vcard.Email.Length > 0)
					sb.AppendLine("EMAIL:" + vcard.Email);

				foreach (string phone in vcard.PhoneNumbers)
					if (phone.StartsWith("9"))
						sb.AppendLine("TEL;HOME:" + phone);
					else
						sb.AppendLine("TEL;CELL:" + phone);

				string image = ImageToBase64(vcard.ProfileImage);
				if (image != "")
					sb.AppendLine("PHOTO;ENCODING=BASE64;JPEG:" + image);

				if (vcard.Addresses.Length > 0)
					sb.AppendLine("ADR:" + String.Join(";", vcard.Addresses));
				sb.AppendLine("END:VCARD");
			}

			return sb.ToString();
		}

		public static string ImageToBase64(Image image, ImageFormat format = null)
		{
			if (format == null)
				format = ImageFormat.Jpeg;

			using (MemoryStream ms = new MemoryStream())
			{
				// Convert Image to byte[]
				image.Save(ms, format);
				byte[] imageBytes = ms.ToArray();

				// Convert byte[] to Base64 String
				string base64String = Convert.ToBase64String(imageBytes);
				return base64String;
			}
		}

		public static Image Base64ToImage(string base64String)
		{
			// Convert Base64 String to byte[]
			byte[] imageBytes = Convert.FromBase64String(base64String);
			MemoryStream ms = new MemoryStream(imageBytes, 0,
			  imageBytes.Length);

			// Convert byte[] to Image
			ms.Write(imageBytes, 0, imageBytes.Length);
			Image image = Image.FromStream(ms, true);
			return image;
		}

		/*
		public static Image LoadImage(string text)
		{
			Image image = null;

			text = text.Replace("\r\n", "").Replace(" ", "");
			if (text != "")
				try
				{
					System.Diagnostics.Debug.WriteLine("Loading img: " + text);
					byte[] bytes = Convert.FromBase64String(text);
					using (MemoryStream ms = new MemoryStream(bytes))
						image = Image.FromStream(ms);
				}
				catch { }
			return image;
		}
		 */
	}
}