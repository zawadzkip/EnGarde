using System;
using System.IO;
using EnGarde.Droid;
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Dependency (typeof (SaveAndLoad_Android))]
namespace EnGarde.Droid
{
	public class SaveAndLoad_Android : ISaveAndLoad
	{
		public SaveAndLoad_Android ()
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
			Debug.WriteLine (filePath);
			System.IO.File.WriteAllBytes (filePath, bytes);
		}
	}
}
