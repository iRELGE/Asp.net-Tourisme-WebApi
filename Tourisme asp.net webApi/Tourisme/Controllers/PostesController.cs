using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tourisme.Data;
using Tourisme.Models;

namespace Tourisme.Controllers
{
    public class PostesController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();
        public IHttpActionResult GetUsersPostsInfos(string email)
        {

            var user = db.Clients.FirstOrDefault(p => p.Email == email);

            var userPostes = db.Postes.Where(p => p.ID == user.ID).ToList();
            var userActivites = db.Activites.Where(p => p.Activite_client_id == user.ID).ToList();
            PostTraitemenrInfo pti = new PostTraitemenrInfo();
            pti.nombrePosts = userPostes.Count();
            pti.nombreActivites = userActivites.Count();
            List<PostsUserApiModel> pu = new List<PostsUserApiModel>();
            foreach (var up in userPostes)
            {
                PostsUserApiModel puam = new PostsUserApiModel();
                puam.ID = up.ID;
                puam.Poste_title = up.Poste_title;
                puam.Poste_description = up.Poste_description;
                puam.Date_CreationPost = up.Date_CreationPost;
                puam.Pay = up.Pay;
                pu.Add(puam);





            }
            pti.posts = pu;






            return Ok(pti);
        }

        //// GET: api/Postes
        //public List<PosteViewModel> GetPostes()
        //{
        //    //instance List de type PostesDansCategorie
        //    List<PosteViewModel> ListPos = new List<PosteViewModel>();
        //    // instance objet de PostesDansCategorie

        //    //recuperer tout les valeur de categories 
        //    var pos = db.Postes.ToList();
        //    //boucler sur cat pour recuperer les categorie
        //    foreach (var p in pos)
        //    {
        //        //instance d'objet
        //        PosteViewModel pvm = new PosteViewModel();
        //        pvm.ID = p.ID;
        //        pvm.CategorieID = p.CategorieID;
        //        pvm.ClientID2 = p.ClientID2;
        //        pvm.Poste_title = p.Poste_title;
        //        pvm.Poste_image = p.Poste_image;
        //        pvm.Poste_description = p.Poste_description;
        //        pvm.Date_debut = p.Date_debut;
        //        pvm.Date_fin = p.Date_fin;
        //        pvm.Etat = p.Etat;
        //        ListPos.Add(pvm);
        //    }
        //    return (ListPos);
        //}

        public IHttpActionResult GetPostesAvis(int prend=0,string option="")
        {
            //instance List de type PostesDansCategorie
            List<PosteViewModelAvis> ListPos = new List<PosteViewModelAvis>();
            // instance objet de PostesDansCategorie
           
                if (option == "best")
                {
                    //recuperer tout les valeur de categories 
                   // var pos1= db.Postes.OrderByDescending(p => p.Avis.Average(l => l.Note)).Take(prend).ToList();
                var pos = db.Postes.OrderByDescending(p => p.Avis.Average(l => l.Note)).Take(prend).ToList(); ;
                    //boucler sur cat pour recuperer les categorie
                    foreach (var p in pos)
                    {
                        //instance d'objet
                        PosteViewModelAvis pvm = new PosteViewModelAvis();
                        pvm.ID = p.ID;
                        pvm.CategorieID = p.CategorieID;
                        pvm.ClientID2 = p.ClientID2;
                        pvm.Poste_title = p.Poste_title;
                        pvm.Poste_image = p.Poste_image;
                        pvm.Poste_description = p.Poste_description;
                        pvm.Date_debut = p.Date_debut;
                        pvm.Date_fin = p.Date_fin;
                        pvm.Etat = p.Etat;
                    pvm.Pay = p.Pay;
                        pvm.nombreAvis = p.Avis.Count();
                        pvm.noteAvis = (p.Avis.Average(f => f.Note)) / 2;
                    pvm.Categorie = p.Categorie.Catégorie_title;
                        List<AvisViewModel> avm = new List<AvisViewModel>();
                        foreach (var a in p.Avis)
                        {
                            AvisViewModel amv = new AvisViewModel();
                            amv.Id = a.Id;
                            amv.Nom = a.Nom;
                            amv.Description = a.Description;
                            amv.Note = a.Note;
                            amv.IdPoste = a.IdPoste;
                            amv.DateAvi = a.DateAvi;
                            amv.IdClient = a.IdClient;
                            avm.Add(amv);




                        }

                    pvm.ClientID = p.ClientID;
                    pvm.Client_Prenom = p.Client.Client_Prenom;
                    pvm.Client_Nom = p.Client.Client_Nom;
                    pvm.Client_image = p.Client.Client_image;
                    pvm.Email = p.Client.Email;
                    pvm.Client_adresse = p.Client.Client_adresse;

                    pvm.avis = avm;

                        ListPos.Add(pvm);
                    }
                }
               
                else if (option == "date")
                {
                    var pos = db.Postes.OrderByDescending(p=>p.Date_CreationPost).Take(prend).ToList();
                    //boucler sur cat pour recuperer les categorie
                    foreach (var p in pos)
                    {
                        //instance d'objet
                        PosteViewModelAvis pvm = new PosteViewModelAvis();
                        pvm.ID = p.ID;
                        pvm.CategorieID = p.CategorieID;
                        pvm.ClientID2 = p.ClientID2;
                        pvm.Poste_title = p.Poste_title;
                        pvm.Poste_image = p.Poste_image;
                        pvm.Poste_description = p.Poste_description;
                        pvm.Date_debut = p.Date_debut;
                        pvm.Date_fin = p.Date_fin;
                        pvm.Etat = p.Etat;
                        pvm.nombreAvis = p.Avis.Count();
                        pvm.noteAvis = (p.Avis.Average(f => f.Note)) / 2;
                        List<AvisViewModel> avm = new List<AvisViewModel>();
                        foreach (var a in p.Avis)
                        {
                            AvisViewModel amv = new AvisViewModel();
                            amv.Id = a.Id;
                            amv.Nom = a.Nom;
                            amv.Description = a.Description;
                            amv.Note = a.Note;
                            amv.IdPoste = a.IdPoste;
                            amv.DateAvi = a.DateAvi;
                            amv.IdClient = a.IdClient;
                            avm.Add(amv);




                        }

                       
                        

                        pvm.ClientID = p.ClientID;
                        pvm.Client_Prenom = p.Client.Client_Prenom;
                        pvm.Client_Nom = p.Client.Client_Nom;
                        pvm.Client_image = p.Client.Client_image;
                        pvm.Email = p.Client.Email;
                        pvm.Client_adresse = p.Client.Client_adresse;

                      





                        pvm.avis = avm;

                        ListPos.Add(pvm);
                    }

                }
            else
            {
                var pos = db.Postes.OrderBy(x => Guid.NewGuid()).Take(prend).ToList();
                //boucler sur cat pour recuperer les categorie
                foreach (var p in pos)
                {
                    //instance d'objet
                    PosteViewModelAvis pvm = new PosteViewModelAvis();
                    pvm.ID = p.ID;
                    pvm.CategorieID = p.CategorieID;
                    pvm.ClientID2 = p.ClientID2;
                    pvm.Poste_title = p.Poste_title;
                    pvm.Poste_image = p.Poste_image;
                    pvm.Poste_description = p.Poste_description;
                    pvm.Date_debut = p.Date_debut;
                    pvm.Date_fin = p.Date_fin;
                    pvm.Etat = p.Etat;
                    pvm.nombreAvis = p.Avis.Count();
                    pvm.noteAvis = (p.Avis.Average(f => f.Note)) / 2;
                    List<AvisViewModel> avm = new List<AvisViewModel>();
                    foreach (var a in p.Avis)
                    {
                        AvisViewModel amv = new AvisViewModel();
                        amv.Id = a.Id;
                        amv.Nom = a.Nom;
                        amv.Description = a.Description;
                        amv.Note = a.Note;
                        amv.IdPoste = a.IdPoste;
                        amv.DateAvi = a.DateAvi;
                        amv.IdClient = a.IdClient;
                        avm.Add(amv);




                    }

                    ClientApiModel cam = new ClientApiModel();

                    cam.ID = p.Client.ID;
                    cam.Client_Prenom = p.Client.Client_Prenom;
                    cam.Client_Nom = p.Client.Client_Nom;
                    cam.Client_image = p.Client.Client_image;
                    cam.Email = p.Client.Email;
                    cam.Client_adresse = p.Client.Client_adresse;

                    pvm.Client = cam;





                    pvm.avis = avm;

                    ListPos.Add(pvm);
                }

            }

            return Ok(ListPos);
           
        }

        ////GET: api/Postes/5
        //[ResponseType(typeof(Poste))]
        //public IHttpActionResult GetPoste(int id)
        //{
        //    var pvm = new PosteViewModel();
        //    Poste poste = db.Postes.Find(id);
        //    if (poste == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        pvm.ID = poste.ID;
        //        pvm.CategorieID = poste.CategorieID;
        //        pvm.ClientID2 = poste.ClientID2;
        //        pvm.Poste_title = poste.Poste_title;
        //        pvm.Poste_image = poste.Poste_image;
        //        pvm.Poste_description = poste.Poste_description;
        //        pvm.Date_debut = poste.Date_debut;
        //        pvm.Date_fin = poste.Date_fin;
        //        pvm.Etat = poste.Etat;


        //    }

        //    return Ok(pvm);
        //}
        // GET: api/Postes/5
        [ResponseType(typeof(Poste))]
        public IHttpActionResult GetPosteAvis(int id)
        {
           
            var pvm = new PosteViewModelAvis();
            Poste poste = db.Postes.Find(id);
            if (poste == null)
            {
                return NotFound();
            }
            else
            {
                pvm.ID = poste.ID;
                pvm.CategorieID = poste.CategorieID;
                pvm.ClientID2 = poste.ClientID2;
                pvm.Poste_title = poste.Poste_title;
                pvm.Poste_image = poste.Poste_image;
                pvm.Poste_description = poste.Poste_description;
                pvm.Date_debut = poste.Date_debut;
                pvm.Date_fin = poste.Date_fin;
                pvm.Etat = poste.Etat;
                pvm.Pay = poste.Pay;
                pvm.Ville = poste.Ville;
                pvm.Adress = pvm.Adress;
               
                pvm.nombreAvis = db.Avis.Count();
                pvm.noteAvis = db.Avis.Average(p => p.Note);
                List<AvisViewModel> avm = new List<AvisViewModel>();
                foreach(var a in poste.Avis)
                {
                    AvisViewModel amv = new AvisViewModel();
                    amv.Id = a.Id;
                    amv.Nom = a.Nom;
                    amv.Description = a.Description;
                    amv.Note = a.Note;
                    amv.IdPoste = a.IdPoste;
                    amv.DateAvi = a.DateAvi;
                    amv.IdClient = a.IdClient;
                    avm.Add(amv);



                   
                }
                pvm.avis = avm;
                pvm.Client_Prenom = poste.Client.Client_Prenom;
                pvm.Client_image = poste.Client.Client_image;






            }

            return Ok(pvm);

           // OrderBy(x => Guid.NewGuid()).Take(4).ToList()
        }

        // PUT: api/Postes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoste(int id, Poste poste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poste.ID)
            {
                return BadRequest();
            }

            db.Entry(poste).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Postes
        [Authorize]
        [ResponseType(typeof(Poste))]
        public IHttpActionResult PostPoste(Poste poste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Postes.Add(poste);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poste.ID }, poste);
        }

        // DELETE: api/Postes/5
        [ResponseType(typeof(Poste))]
        public IHttpActionResult DeletePoste(string id)
        {
            int a = int.Parse(id);
            Poste poste = db.Postes.Find(a);
            if (poste == null)
            {
                return NotFound();
            }

            db.Postes.Remove(poste);
            db.SaveChanges();

            return Ok(poste);
        }
        [ResponseType(typeof(Poste))]
        public IHttpActionResult GetPosteSearch(string type, string country,string destination,string dateDebut,string dateFin)
        {
            var pvm = new PosteViewModel();
            Poste poste = db.Postes.Find(type,country,destination,dateDebut,dateFin);
            if (poste == null)
            {
                return NotFound();
            }

            else
            {
                pvm.ID = poste.ID;
                pvm.CategorieID = poste.CategorieID;
                pvm.ClientID2 = poste.ClientID2;
                pvm.Poste_title = poste.Poste_title;
                pvm.Poste_image = poste.Poste_image;
                pvm.Poste_description = poste.Poste_description;
                pvm.Date_debut = poste.Date_debut;
                pvm.Date_fin = poste.Date_fin;
                pvm.Etat = poste.Etat;


            }

            return Ok(pvm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosteExists(int id)
        {
            return db.Postes.Count(e => e.ID == id) > 0;
        }

    }
}