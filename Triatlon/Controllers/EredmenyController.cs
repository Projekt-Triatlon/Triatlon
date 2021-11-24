using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.DataTransferObjects;
using TriatlonLogic.Managers;
using TriatlonLogic.Models;

namespace Triatlon.Controllers
{
	public class EredmenyController : Controller
	{
		public ActionResult Index()
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmenyek = eredmenyManager.GetAll();

			return View(eredmenyek);

		}

		[HttpPost]
		public ActionResult Index(IFormFile postedFile)
		{
			if (postedFile != null)
			{
				try
				{
					string fileExtension = Path.GetExtension(postedFile.FileName);

					if (fileExtension != ".csv")
					{
						ViewBag.Message = "Csak .csv kiterjesztésű fájlt adhat meg!";
						return RedirectToAction("Select", "Eredmeny", new { area = "" });
					}



					var eredmenyManager = TDI.Resolve<EredmenyManager>();
					var eredmenyek = new List<VersenyVersenyzo>();
					using (var sreader = new StreamReader(postedFile.OpenReadStream()))
					{

						//string[] headers = sreader.ReadLine().Split(';');
						while (!sreader.EndOfStream)
						{
							string[] rows = sreader.ReadLine().Split(';');

							eredmenyManager.Add(new VersenyVersenyzo
							{
								//OID = Int64.Parse(rows[0].ToString()),
								ChipKod = rows[0].ToString(),
								Rajtszam = Int64.Parse(rows[1].ToString()),
								UszasIdo = TimeSpan.Parse(rows[2].ToString()),
								Depo1Ido = TimeSpan.Parse(rows[3].ToString()),
								KerekparIdo = TimeSpan.Parse(rows[4].ToString()),
								Depo2Ido = TimeSpan.Parse(rows[5].ToString()),
								FutasIdo = TimeSpan.Parse(rows[6].ToString()),
								CelIdo = TimeSpan.Parse(rows[7].ToString()),
								AbszolutHelyezes = 0,
								//AbszolutHelyezes = Int64.Parse(rows[8].ToString()),
								VersenyzoOID = Int64.Parse(rows[8].ToString()),
								VersenyOID = Int64.Parse(rows[9].ToString()),
							});

						}
					}

					return RedirectToAction("Select", "Eredmeny", new { area = "" });
				}
				catch (Exception ex)
				{
					ViewBag.Message = ex.Message;
				}
			}
			else
			{
				ViewBag.Message = "Kérem válassza ki a CSV fájlt először.";
			}
			return RedirectToAction("Select", "Eredmeny", new { area = "" });
		}

		public ActionResult List(string oid)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				var eredmenyek = eredmenyManager.GetSelected(oid);

				return View(eredmenyek);
			}
			catch
			{
				return View();
			}
		}

		// GET: EredmenyController/Details/5
		public ActionResult Details(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.GetEredmenyDisplayDto(oid);

			return View(eredmeny);
		}




		public ActionResult Create()
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmenyCreateDto = eredmenyManager.GetEredmenyCreateDto();

			return View(eredmenyCreateDto);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var eredmeny = new VersenyVersenyzo();
				eredmeny.ChipKod = collection["ChipKod"];
				eredmeny.Rajtszam = Convert.ToInt64(collection["Rajtszam"]);
				eredmeny.UszasIdo = TimeSpan.Parse(collection["UszasIdo"]);
				eredmeny.Depo1Ido = TimeSpan.Parse(collection["Depo1Ido"]);
				eredmeny.KerekparIdo = TimeSpan.Parse(collection["KerekparIdo"]);
				eredmeny.Depo2Ido = TimeSpan.Parse(collection["Depo2Ido"]);
				eredmeny.FutasIdo = TimeSpan.Parse(collection["FutasIdo"]);
				eredmeny.CelIdo = TimeSpan.Parse(collection["CelIdo"]);
				eredmeny.VersenyzoOID = Convert.ToInt64(collection["VersenyzoOID"]);
				eredmeny.VersenyOID = Convert.ToInt64(collection["VersenyOID"]);

				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				eredmenyManager.Add(eredmeny);

				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}
			catch
			{
				return View();
			}
		}

		// GET: EredmenyController/Edit/5
		public ActionResult Edit(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.Get(oid);

			return View(eredmeny);
		}

		// POST: EredmenyController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();

				var tempEredmeny = new VersenyVersenyzo()
				{
					OID = oid,
					ChipKod = collection["ChipKod"],
					Rajtszam = Convert.ToInt64(collection["Rajtszam"]),
					UszasIdo = TimeSpan.Parse(collection["UszasIdo"]),
					Depo1Ido = TimeSpan.Parse(collection["Depo1Ido"]),
					KerekparIdo = TimeSpan.Parse(collection["KerekparIdo"]),
					Depo2Ido = TimeSpan.Parse(collection["Depo2Ido"]),
					FutasIdo = TimeSpan.Parse(collection["FutasIdo"]),
					CelIdo = TimeSpan.Parse(collection["CelIdo"]),
					//VersenyzoOID = Convert.ToInt32(collection["VersenyzoOID"]),
					//VersenyOID = Convert.ToInt32(collection["VersenyOID"]),
				};

				eredmenyManager.Update(tempEredmeny);

				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}
			catch
			{
				return View();
			}
		}

		// GET: EredmenyController/Delete/5
		public ActionResult Delete(int oid)
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmeny = eredmenyManager.Get(oid);

			return View(eredmeny);
		}

		// POST: EredmenyController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				//eredmenyManager.SetDeleted(oid);
				eredmenyManager.Delete(oid);

				return RedirectToAction("Select", "Eredmeny", new { area = "" });
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Select()
		{
			var eredmenyManager = TDI.Resolve<EredmenyManager>();
			var eredmenySelectDto = eredmenyManager.GetEredmenySelectDto();

			return View(eredmenySelectDto);
		}
	}
}
