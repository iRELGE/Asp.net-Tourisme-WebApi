using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class AvisViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Nullable<double> Note { get; set; }
        public Nullable<int> IdPoste { get; set; }
        public Nullable<System.DateTime> DateAvi { get; set; }
        public int IdClient { get; set; }
    }
}