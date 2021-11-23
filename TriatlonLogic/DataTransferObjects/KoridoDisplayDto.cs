using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TriatlonLogic.DataTransferObjects
{
	public class KoridoDisplayDto
	{
		public long OID { get; set; }

		[DisplayName("Chip kód")]
		public string ChipKod { get; set; }

		[DisplayName("Szakasz")]
		public string Szakasz { get; set; }

		[DisplayName("Kör száma")]
		public long KorSzama { get; set; }

		[DisplayName("Idő")]
		public TimeSpan Ido { get; set; }

		[DisplayName("ID")]
		public long VersenyVersenyzoOID { get; set; }

	}
}
