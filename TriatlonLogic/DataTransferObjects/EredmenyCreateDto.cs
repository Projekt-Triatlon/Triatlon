using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TriatlonLogic.DataTransferObjects
{
	public class EredmenyCreateDto
	{
		public long OID { get; set; }

		[DisplayName("Chipkód")]
		public string ChipKod { get; set; }

		[DisplayName("Rajtszám")]
		public long Rajtszam { get; set; }

		[DisplayName("Úszás idő")]
		public TimeSpan UszasIdo { get; set; }

		[DisplayName("Depo 1 idő")]
		public TimeSpan Depo1Ido { get; set; }

		[DisplayName("Kerékpár idő")]
		public TimeSpan KerekparIdo { get; set; }

		[DisplayName("Depo 2 idő")]
		public TimeSpan Depo2Ido { get; set; }

		[DisplayName("Futás idő")]
		public TimeSpan FutasIdo { get; set; }

		[DisplayName("Cél idő")]
		public TimeSpan CelIdo { get; set; }

		[DisplayName("Versenyző")]
		public long VersenyzoOID { get; set; }

		public List<SelectListItem> VersenyzoSelectList { get; set; }

		[DisplayName("Verseny")]
		public long VersenyOID { get; set; }

		public List<SelectListItem> VersenySelectList { get; set; }

	}


}
