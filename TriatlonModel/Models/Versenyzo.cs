using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TriatlonLogic.Interfaces;

namespace TriatlonLogic.Models
{
	[Table("Versenyzo")]

	public class Versenyzo : IOid
	{
		[Key]
		public long OID { get; set; }

		[Required]
		[MaxLength(100)]
		[DisplayName("Név")]
		public string Nev { get; set; }

		[DisplayName("Nem")]
		public string Nem { get; set; }

		[Required]
		[DisplayName("Születési idő")]
		public DateTime SzulIdo { get; set; }

		[DisplayName("Egyesület")]
		public string Egyesulet { get; set; }

		[DisplayName("Licence")]
		public string Licence { get; set; }

		public virtual ICollection<VersenyVersenyzo> VersenyVersenyzok { get; set; }

	}
}
