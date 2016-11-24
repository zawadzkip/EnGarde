using System;
namespace EnGarde
{
	public interface ISaveAndLoad
	{
		void SaveBytes (string fileName, byte [] bytes);
		bool CheckFile (string fileName);
		DateTime CheckFileCreationTime (string fileName);
	}
}
