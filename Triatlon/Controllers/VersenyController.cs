using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.Managers;
using TriatlonLogic.Models;

namespace Triatlon.Controllers
{
	public class VersenyController : Controller
	{
		public ActionResult Index()
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var versenyek = versenyManager.GetAll();
			return View(versenyek);
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
						return RedirectToAction(nameof(Index));
					}

					var versenyManager = TDI.Resolve<VersenyManager>();
					var versenyek = new List<Verseny>();
					using (var sreader = new StreamReader(postedFile.OpenReadStream()))
					{

						//string[] headers = sreader.ReadLine().Split(';');
						while (!sreader.EndOfStream)
						{
							string[] rows = sreader.ReadLine().Split(';');

							versenyManager.Add(new Verseny
							{
								//OID = Int64.Parse(rows[0].ToString()),
								Nev = rows[0].ToString(),
								Helyszin = rows[1].ToString(),
								Datum = DateTime.Parse(rows[2].ToString()),
								UTavolsag = Int32.Parse(rows[3].ToString()),
								UKorokSzama = Int32.Parse(rows[4].ToString()),
								UTipus = rows[5].ToString(),
								UNeopren = Boolean.Parse(rows[6].ToString()),
								UMelyseg = Double.Parse(rows[7].ToString()),
								UVizHofok = Double.Parse(rows[8].ToString()),
								UHullamzas = rows[9].ToString(),
								USzel = Double.Parse(rows[10].ToString()),
								UCsapadek = Double.Parse(rows[11].ToString()),
								ULevegoHomerseklet = Double.Parse(rows[12].ToString()),
								ULevegoParatartalom = Double.Parse(rows[13].ToString()),
								KTavolsag = Int32.Parse(rows[14].ToString()),
								KMinoseg = rows[15].ToString(),
								KSzintemelkedes = Double.Parse(rows[16].ToString()),
								KKorokSzama = Int32.Parse(rows[17].ToString()),
								KSzel = Double.Parse(rows[18].ToString()),
								KCsapadek = Double.Parse(rows[19].ToString()),
								KLevegoHomerseklet = Double.Parse(rows[20].ToString()),
								KLevegoParatartalom = Double.Parse(rows[21].ToString()),
								FTavolsag = Int32.Parse(rows[22].ToString()),
								FMinoseg = rows[23].ToString(),
								FSzintemelkedes = Double.Parse(rows[24].ToString()),
								FKorokSzama = Int32.Parse(rows[25].ToString()),
								FSzel = Double.Parse(rows[26].ToString()),
								FCsapadek = Double.Parse(rows[27].ToString()),
								FLevegoHomerseklet = Double.Parse(rows[28].ToString()),
								FLevegoParatartalom = Double.Parse(rows[29].ToString()),
							});

						}
					}

					return RedirectToAction(nameof(Index));
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
			return RedirectToAction(nameof(Index));
		}

		public ActionResult Details(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}


		public ActionResult Create()
		{
			return View(new Verseny());
		}

		public ActionResult CreateFull()
		{
			return View(new Verseny());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var verseny = new Verseny()
				{
					Nev = collection["Nev"],
					Helyszin = collection["Helyszin"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
				};

				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Add(verseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateFull(IFormCollection collection)
		{
			try
			{
				var verseny = new Verseny()
				{
					Nev = collection["Nev"],
					Helyszin = collection["Helyszin"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = Convert.ToBoolean(collection["UNeopren"]),
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Add(verseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		public ActionResult EditFull(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();

				var tempVerseny = new Verseny()
				{
					OID = oid,
					Nev = collection["Nev"],
					Helyszin = collection["Helyszin"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = Convert.ToBoolean(collection["UNeopren"]),
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				versenyManager.Update(tempVerseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditFull(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();

				var tempVerseny = new Verseny()
				{
					OID = oid,
					Nev = collection["Nev"],
					Helyszin = collection["Helyszin"],
					Datum = Convert.ToDateTime(collection["Datum"]),
					UTavolsag = Convert.ToDouble(collection["UTavolsag"]),
					UKorokSzama = Convert.ToInt32(collection["UKorokSzama"]),
					UNeopren = false,
					UTipus = collection["UTipus"],
					UMelyseg = Convert.ToDouble(collection["UMelyseg"]),
					UVizHofok = Convert.ToDouble(collection["UVizHofok"]),
					UHullamzas = collection["UHullamzas"],
					USzel = Convert.ToDouble(collection["USzel"]),
					UCsapadek = Convert.ToDouble(collection["UCsapadek"]),
					ULevegoHomerseklet = Convert.ToDouble(collection["ULevegoHomerseklet"]),
					ULevegoParatartalom = Convert.ToDouble(collection["ULevegoParatartalom"]),
					KTavolsag = Convert.ToDouble(collection["KTavolsag"]),
					KMinoseg = collection["KMinoseg"],
					KSzintemelkedes = Convert.ToDouble(collection["KSzintemelkedes"]),
					KKorokSzama = Convert.ToInt32(collection["KKorokSzama"]),
					KSzel = Convert.ToDouble(collection["KSzel"]),
					KCsapadek = Convert.ToDouble(collection["KCsapadek"]),
					KLevegoHomerseklet = Convert.ToDouble(collection["KLevegoHomerseklet"]),
					KLevegoParatartalom = Convert.ToDouble(collection["KLevegoParatartalom"]),
					FTavolsag = Convert.ToDouble(collection["FTavolsag"]),
					FMinoseg = collection["FMinoseg"],
					FSzintemelkedes = Convert.ToDouble(collection["FSzintemelkedes"]),
					FKorokSzama = Convert.ToInt32(collection["FKorokSzama"]),
					FSzel = Convert.ToDouble(collection["FSzel"]),
					FCsapadek = Convert.ToDouble(collection["FCsapadek"]),
					FLevegoHomerseklet = Convert.ToDouble(collection["FLevegoHomerseklet"]),
					FLevegoParatartalom = Convert.ToDouble(collection["FLevegoParatartalom"]),
				};

				versenyManager.Update(tempVerseny);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int oid)
		{
			var versenyManager = TDI.Resolve<VersenyManager>();
			var verseny = versenyManager.Get(oid);

			return View(verseny);
		}

		// POST: VersenyzoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var versenyManager = TDI.Resolve<VersenyManager>();
				versenyManager.Delete(oid);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}

}
