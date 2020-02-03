using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Tourisme.Data;
using Tourisme.Models;

namespace Tourisme.Controllers
{
    public class UserDataController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();
       
        public IHttpActionResult GetUserPosts(string ID)
        {
            int a=  int.Parse(ID);
           
            var user = db.Clients.FirstOrDefault(p => p.ID == a);

            var userPostes = db.Postes.Where(p => p.ClientID == user.ID).ToList();
            var userActivites = db.Activites.Where(p => p.Activite_client_id == user.ID).ToList();
            PostTraitemenrInfo pti = new PostTraitemenrInfo();
            pti.nombrePosts = userPostes.Count();
            pti.nombreActivites = userActivites.Count();
            List<PostsUserApiModel> pu = new List<PostsUserApiModel>();
            foreach(var up in userPostes)
            {
                PostsUserApiModel puam = new PostsUserApiModel();
                puam.ID = up.ID;
                puam.Poste_title = up.Poste_title;
                puam.Poste_description = up.Poste_description;
                puam.Date_CreationPost = up.Date_CreationPost;
                puam.Pay = up.Pay;
                puam.Poste_image = up.Poste_image;
                puam.nombreActivitiesParPoste= up.Activites.Count();

                pu.Add(puam);





            }
            pti.posts = pu;






            return Ok(pti);
        }
    }
}
