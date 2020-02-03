using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class ClientApiModel
    {
        public int ID { get; set; }
        public string Client_Nom { get; set; }
        public string Client_image { get; set; }
        public string Client_adresse { get; set; }
     
        public string Client_Prenom { get; set; }
        public string Email { get; set; }
      

    }
}