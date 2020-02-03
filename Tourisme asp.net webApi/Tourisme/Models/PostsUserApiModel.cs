using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class PostsUserApiModel
    {
        public int ID { get; set; }
        public int nombreActivitiesParPoste { get; set; }
        public string Poste_title { get; set; }
        public string Poste_description { get; set; }
        public Nullable<System.DateTime> Date_CreationPost { get; set; }
        public string Poste_image { get; set; }
        public string Pay { get; set; }


    }
}