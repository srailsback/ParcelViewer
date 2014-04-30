using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcelViewer.Models
{
    public class Parcel
    {
        public string ParcelNumber { get; set; }
        public string ScheduleNumber { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public string Legal { get; set; }
        public string Subdivision { get; set; }
    }


    public class ParcelModelMap : CsvClassMap<Parcel>
    {
        // csv.ccon
        public override void CreateMap()
        {
            Map(x => x.ParcelNumber).Name("ParcelNumber");
            Map(x => x.ScheduleNumber).Name("ScheduleNumber");
            Map(x => x.Address).Name("Address");
            Map(x => x.Owner).Name("Owner");
            Map(x => x.Legal).Name("Legal");
            Map(x => x.Subdivision).Name("Subdivision");
        }

    }
}

