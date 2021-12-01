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



		public ActionResult List(string oid, string nem, string kategoria)
		{
			try
			{
				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				var eredmenyek = eredmenyManager.GetSelected(oid, nem, kategoria);
				foreach (var item in eredmenyek)
				{
					item.CelIdo = item.UszasIdo + item.Depo1Ido + item.KerekparIdo + item.Depo2Ido + item.FutasIdo;
					eredmenyManager.Update(item);
				}

				int x = 1;
				foreach (var item in eredmenyek)
				{
					item.AbszolutHelyezes = x;
					eredmenyManager.Update(item);
					x++;
				}

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


			switch (eredmeny.AbszolutHelyezes)
			{
				//120 96 77 61 49 39 31 25 20 16
				case 1:
					eredmeny.RanglistaPont = 120;
					break;
				case 2:
					eredmeny.RanglistaPont = 96;
					break;
				case 3:
					eredmeny.RanglistaPont = 77;
					break;
				case 4:
					eredmeny.RanglistaPont = 61;
					break;
				case 5:
					eredmeny.RanglistaPont = 49;
					break;
				case 6:
					eredmeny.RanglistaPont = 39;
					break;
				case 7:
					eredmeny.RanglistaPont = 31;
					break;
				case 8:
					eredmeny.RanglistaPont = 25;
					break;
				case 9:
					eredmeny.RanglistaPont = 20;
					break;
				case 10:
					eredmeny.RanglistaPont = 16;
					break;

				default:
					eredmeny.RanglistaPont = 0;
					break;
			}

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
				eredmeny.CelIdo = TimeSpan.Parse(collection["UszasIdo"])
					+ TimeSpan.Parse(collection["Depo1Ido"])
					+ TimeSpan.Parse(collection["KerekparIdo"])
					+ TimeSpan.Parse(collection["Depo2Ido"])
					+ TimeSpan.Parse(collection["FutasIdo"]);
				eredmeny.VersenyzoOID = Convert.ToInt64(collection["VersenyzoOID"]);
				eredmeny.VersenyOID = Convert.ToInt64(collection["VersenyOID"]);

				var eredmenyManager = TDI.Resolve<EredmenyManager>();
				eredmenyManager.Add(eredmeny);

				return RedirectToAction("List", "Eredmeny", new { oid = eredmeny.VersenyOID });
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
					VersenyzoOID = Convert.ToInt32(collection["VersenyzoOID"]),
					VersenyOID = Convert.ToInt32(collection["VersenyOID"]),

				};

				eredmenyManager.Update(tempEredmeny);

				return RedirectToAction("List", "Eredmeny", new { oid = tempEredmeny.VersenyOID });

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
				int versenyoid = Convert.ToInt32(collection["VersenyOID"]);
				eredmenyManager.Delete(oid);

				return RedirectToAction("List", "Eredmeny", new { oid = versenyoid });
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
						return RedirectToAction("Select", "Eredmeny");
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
								ChipKod = rows[0].ToString(),
								Rajtszam = Int64.Parse(rows[1].ToString()),
								UszasIdo = TimeSpan.Parse(rows[2].ToString()),
								Depo1Ido = TimeSpan.Parse(rows[3].ToString()),
								KerekparIdo = TimeSpan.Parse(rows[4].ToString()),
								Depo2Ido = TimeSpan.Parse(rows[5].ToString()),
								FutasIdo = TimeSpan.Parse(rows[6].ToString()),
								CelIdo = TimeSpan.Parse("00:00:00"),
								AbszolutHelyezes = 0,
								VersenyzoOID = Int64.Parse(rows[7].ToString()),
								VersenyOID = Int64.Parse(rows[8].ToString()),
							});

						}
					}

					return RedirectToAction("Select", "Eredmeny");
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
			return RedirectToAction("Select", "Eredmeny");
		}
	}
}
