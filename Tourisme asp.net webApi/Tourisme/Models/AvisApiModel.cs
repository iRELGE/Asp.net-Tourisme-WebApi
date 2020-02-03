using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class AvisApiModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public string Client_image { get; set; }
        public string Client_Prenom { get; set; }

    }
}