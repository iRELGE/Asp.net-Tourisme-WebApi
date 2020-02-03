using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class DemandeViewModel
    {
        public int ID { get; set; }
        public int ClientID2 { get; set; }
        public int ClientID { get; set; }
        public string Demande_title { get; set; }
        public string Demande_description { get; set; }
        public Nullable<System.DateTime> Date_debut { get; set; }
        public Nullable<System.DateTime> Date_fin { get; set; }

    }
}