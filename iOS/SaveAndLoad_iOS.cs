using System;
using System.IO;
using EnGarde.iOS;
using Xamarin.Forms;

[assembly: Dependency (typeof (SaveAndLoad_iOS))]
namespace EnGarde.iOS
{
	public class SaveAndLoad_iOS : ISaveAndLoad
	{
		public SaveAndLoad_iOS ()
		{
		}

		public bool CheckFile (string fileName)
		{
			var docPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (docPath, fileName);
			return File.Exists (filePath);
		}

		public DateTime CheckFileCreationTime (string fileName)
		{
			var docPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (docPath, fileName);
			return File.GetCreationTimeUtc (filePath);
		}

		public void SaveBytes (string fileName, byte [] bytes)
		{
			var docPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (docPath, fileName);
			System.IO.File.WriteAllBytes (filePath, bytes);
		}
	}
}
