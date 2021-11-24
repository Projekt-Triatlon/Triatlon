using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TriatlonLogic.DataTransferObjects
{
	public class EredmenySelectDto
	{
		public long VersenyOID { get; set; }

		public List<SelectListItem> VersenySelectList { get; set; }
	}
}
