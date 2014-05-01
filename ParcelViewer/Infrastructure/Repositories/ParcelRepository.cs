using ParcelViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace ParcelViewer.Infrastructure.Repositories
{
    public interface IParcelRepository
    {
        IQueryable<Parcel> All { get; }
        Parcel Find(string parcelNumber);
    }

    public class ParcelRepository : IParcelRepository
    {
        private CsvReader _reader { get; set; }

        public ParcelRepository()
        {
            string filePath = @"D:\github\ParcelViewer\ParcelViewer\Models\parcelslist.csv";
            var streamReader = new StreamReader(filePath);
            this._reader = new CsvReader(streamReader);
        }

        public IQueryable<Parcel> All
        {
            get
            {
                var parcels = _reader.GetRecords<Parcel>();
                return parcels.AsQueryable();
            }
        }

        public Parcel Find(string parcelNumber)
        {
            var parcels = _reader.GetRecords<Parcel>();
            return parcels.SingleOrDefault(x => x.ParcelNumber == parcelNumber);
        }
    }
}


        //private IQueryable<Parcel> GetParcels(bool updateFromApi = false)
        //{
        //    // thing to return
        //    var parcels = new List<Parcel>();
            
        //    // read list of parcel numbers
        //    var filePath = @"D:\github\ParcelViewer\ParcelViewer\Models\parcelnumbers.csv";
        //    var listPath = @"D:\github\ParcelViewer\ParcelViewer\Models\parcelslist.csv";
        //    var streamReader = new StreamReader(filePath);
        //    var csv = new CsvReader(streamReader);


        //    var records = csv.GetRecords<Parcel>().ToList();
        //    if (updateFromApi) 
        //    {
        //        foreach (var record in records)
        //        {
        //            var property = new PropertyInformation().GetPropertyInfo("", record.ParcelNumber);
        //            record.Address = property.address;
        //            record.Owner = property.ownerName1;
        //            record.Subdivision = property.subdivDescr;
        //            record.Legal = property.legal;
        //        }

        //        // write the file
        //        TextWriter textWriter = new StreamWriter(listPath);
        //        var csvWriter = new CsvWriter(textWriter);
        //        //foreach (var record in records)
        //        //{
        //        //    csvWriter.WriteRecord(record);
        //        //}
        //        csvWriter.WriteRecords(records);
        //        textWriter.Flush();
        //        textWriter.Close();
                
        //    }

        //    // write the records
        //    return parcels.AsQueryable();
        //}
