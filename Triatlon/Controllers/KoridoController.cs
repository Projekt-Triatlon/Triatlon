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
	public class KoridoController : Controller
	{
		public ActionResult Index()
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.GetAll();

			return View(koridok);
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
						return Redirect(HttpContext.Request.Headers["Referer"]);
					}

					var koridoManager = TDI.Resolve<KoridoManager>();
					var koridok = new List<Korido>();
					using (var sreader = new StreamReader(postedFile.OpenReadStream()))
					{

						//string[] headers = sreader.ReadLine().Split(';');
						while (!sreader.EndOfStream)
						{
							string[] rows = sreader.ReadLine().Split(';');

							koridoManager.Add(new Korido
							{
								Szakasz = rows[0].ToString(),
								KorSzama = Int32.Parse(rows[1].ToString()),
								Ido = TimeSpan.Parse(rows[2].ToString()),
								VersenyVersenyzoOID = Int64.Parse(rows[3].ToString())
							});

						}
					}

					return Redirect(HttpContext.Request.Headers["Referer"]);
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
			return Redirect(HttpContext.Request.Headers["Referer"]);
		}

		public ActionResult List(long oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.GetKoridok(oid);

			return View(koridok);
		}

		public ActionResult Details(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		public ActionResult Create()
		{
			return View(new Korido());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var korido = new Korido()
				{
					Szakasz = collection["Szakasz"],
					KorSzama = Convert.ToInt32(collection["KorSzama"]),
					Ido = TimeSpan.Parse(collection["Ido"]),
					VersenyVersenyzoOID = Int64.Parse(collection["VersenyVersenyzoOID"]),
				};

				var koridoManager = TDI.Resolve<KoridoManager>();
				koridoManager.Add(korido);

				return RedirectToAction("List", "Korido", new { oid = collection["VersenyVersenyzoOID"] });
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int oid, IFormCollection collection)
		{
			try
			{
				var koridoManager = TDI.Resolve<KoridoManager>();

				var tempKorido = new Korido()
				{
					OID = oid,
					Szakasz = collection["Szakasz"],
					KorSzama = Convert.ToInt32(collection["KorSzama"]),
					Ido = TimeSpan.Parse(collection["Ido"]),
					VersenyVersenyzoOID = Int64.Parse(collection["VersenyVersenyzoOID"]),
				};

				koridoManager.Update(tempKorido);

				return RedirectToAction("List", "Korido", new { oid = tempKorido.VersenyVersenyzoOID });
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int oid)
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.Get(oid);

			return View(koridok);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int oid, IFormCollection collection)
		{
			try
			{
				var koridoManager = TDI.Resolve<KoridoManager>();
				int vvoid = Convert.ToInt32(collection["VersenyVersenyzoOID"]);
				koridoManager.Delete(oid);

				return RedirectToAction("List", "Korido", new { oid = vvoid });
			}

			catch
			{
				return View();
			}
		}

		public ActionResult DeleteAll()
		{
			var koridoManager = TDI.Resolve<KoridoManager>();
			var koridok = koridoManager.GetAll();

			foreach (var item in koridok)
			{
				koridoManager.Delete(item.OID);
			}

			return RedirectToAction("Select", "Eredmeny");
		}
	}
}
