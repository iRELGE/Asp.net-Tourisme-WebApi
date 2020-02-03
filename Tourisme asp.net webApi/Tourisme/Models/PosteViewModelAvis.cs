using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourisme.Data;

namespace Tourisme.Models
{
    public class PosteViewModelAvis
    {
        public int ID { get; set; }
        public int CategorieID { get; set; }
        public string Categorie { get; set; }
        public int ClientID2 { get; set; }
        public int ClientID { get; set; }
        public string Poste_title { get; set; }
        public string Poste_image { get; set; }
        public string Poste_description { get; set; }
        public Nullable<System.DateTime> Date_debut { get; set; }
        public Nullable<System.DateTime> Date_fin { get; set; }
        public string Pay { get; set; }
        public string Ville { get; set; }
        public string Adress { get; set; }
        public Nullable<bool> Etat { get; set; }
        public float nombreAvis { get; set; }
        public Nullable<double> noteAvis { get; set; }
        public string Client_Nom { get; set; }
        public string Client_image { get; set; }
        public string Client_adresse { get; set; }

        public string Client_Prenom { get; set; }
        public string Email { get; set; }

        public List<AvisViewModel> avis { get; internal set; }
        public ClientApiModel Client { get; set; }
      //  public Client Client1 { get; set; }

    }
}