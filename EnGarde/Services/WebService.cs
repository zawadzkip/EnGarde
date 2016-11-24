using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;

namespace EnGarde
{

	public static class WebService
	{
		private static readonly string PDF_URL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTe94IE_KK44Nga1f67S6aymWJJ-HY-_6yYRSi6u6W3oCA0yBthA3_PRJugjBmYao66vdn3C8pSwAyu/pub?gid=624780587&single=true&output=csv";
		public static readonly string PDF_FILE_NAME = "fencing_rules.pdf";
		public static async Task<bool> DownloadRulesPDF ()
		{
			string ruleUrl = null;
			using (var httpClient = new HttpClient ()) {
				httpClient.Timeout = new TimeSpan (0, 0, 6);
				try {
					var response = await httpClient.GetAsync (PDF_URL);
					if (response != null && response.IsSuccessStatusCode) {
						ruleUrl = await response.Content.ReadAsStringAsync ();
					} else {
						return false;
					}
				} catch (Exception e) {
					return false;
				}
				try {
					var pdfResponse = await httpClient.GetByteArrayAsync (PDF_URL);
					if (pdfResponse != null) {
						DependencyService.Get<ISaveAndLoad> ().SaveBytes (PDF_FILE_NAME, pdfResponse);
						return true;
					}
				} catch (Exception e) {
					return false;
				}
				return false;
			}

		}

	}
}
