using ParcelViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using ParcelViewer.org.larimer.www;

namespace ParcelViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var parcels = GetParcels(true);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        private IQueryable<Parcel> GetParcels(bool updateFromApi = false)
        {
            // thing to return
            var parcels = new List<Parcel>();
            
            // read list of parcel numbers
            var filePath = @"D:\github\ParcelViewer\ParcelViewer\Models\parcelnumbers.csv";
            var listPath = @"D:\github\ParcelViewer\ParcelViewer\Models\parcelslist.csv";
            var streamReader = new StreamReader(filePath);
            var csv = new CsvReader(streamReader);


            var records = csv.GetRecords<Parcel>().ToList();
            if (updateFromApi) 
            {
                foreach (var record in records)
                {
                    var property = new PropertyInformation().GetPropertyInfo("", record.ParcelNumber);
                    record.Address = property.address;
                    record.Owner = property.ownerName1;
                    record.Subdivision = property.subdivDescr;
                    record.Legal = property.legal;
                }

                // write the file
                TextWriter textWriter = new StreamWriter(listPath);
                var csvWriter = new CsvWriter(textWriter);
                //foreach (var record in records)
                //{
                //    csvWriter.WriteRecord(record);
                //}
                csvWriter.WriteRecords(records);
                textWriter.Flush();
                textWriter.Close();
                
            }

            // write the records
            return parcels.AsQueryable();
        }

    }
}