using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TriatlonLogic.Interfaces;

namespace TriatlonLogic.Models
{
	[Table("Korido")]
	public class Korido : IOid
	{
		[Key]
		public long OID { get; set; }

		[Required]
		[DisplayName("Szakasz")]
		public string Szakasz { get; set; }

		[Required]
		[DisplayName("Kör száma")]
		public long KorSzama { get; set; }

		[DisplayName("Köridő")]
		public DateTime Ido { get; set; }

		public long VersenyVersenyzoOID { get; set; }

		[ForeignKey("VersenyVersenyzoOID")]
		public virtual VersenyVersenyzo VersenyVersenyzo { get; set; }


	}
}
