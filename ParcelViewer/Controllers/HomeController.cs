using ParcelViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcelViewer.Infrastructure.Repositories;
using DataTables.Mvc;

namespace ParcelViewer.Controllers
{
    public class HomeController : Controller
    {
        protected IParcelRepository _parcelRepo;
        public HomeController(IParcelRepository parcelRepo)
        {
            _parcelRepo = parcelRepo;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var parcels = _parcelRepo.All.ToList();
            var paged = parcels.Skip(requestModel.Start).Take(requestModel.Length);
            var result = Json(new DataTablesResponse(requestModel.Draw, paged, parcels.Count(), parcels.Count()));
            return result;

        }

    }
}