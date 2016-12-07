using System;
namespace EnGarde
{
	public interface INotify
	{
		void LocalNotification (string title, string message, double timeFromNow = 1);
	}
}
