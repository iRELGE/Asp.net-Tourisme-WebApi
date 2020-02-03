using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class ActiviteApiModel
    {
        public int Id { get; set; }
        public string Activite_titre { get; set; }
        public string Activite_description { get; set; }
        public string Activite_image { get; set; }
        public Nullable<double> Activite_NoteAvis { get; set; }
        public int Activite_NombreAvis { get; set; }
        public string Activite_Catégorie { get; set; }
        //public List<ActiviteAviModel> AcriviteAvis { get; set; }
    }
}