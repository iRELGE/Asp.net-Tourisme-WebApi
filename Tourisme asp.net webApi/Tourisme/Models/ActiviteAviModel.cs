using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class ActiviteAviModel
    {
        public string AcriviteAvi_Titre { get; set; }
        public string AcriviteAvi_description { get; set; }
        public Nullable<double> AcriviteAvi_note { get; set; }
        public Nullable<System.DateTime> AcriviteAvi_datecreation { get; set; }

    }
}