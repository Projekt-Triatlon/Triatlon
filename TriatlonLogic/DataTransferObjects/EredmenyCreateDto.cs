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

		public string ChipKod { get; set; }

		public long Rajtszam { get; set; }

		public TimeSpan UszasIdo { get; set; }

		public TimeSpan Depo1Ido { get; set; }

		public TimeSpan KerekparIdo { get; set; }

		public TimeSpan Depo2Ido { get; set; }

		public TimeSpan FutasIdo { get; set; }

		public TimeSpan CelIdo { get; set; }


		public long VersenyzoOID { get; set; }

		public List<SelectListItem> VersenyzoSelectList { get; set; }

		public long VersenyOID { get; set; }

		public List<SelectListItem> VersenySelectList { get; set; }

	}


}
