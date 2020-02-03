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
    public class DemandesController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();

        // GET: api/Demandes
        public List<DemandeViewModel> GetDemandes()
        {
            //instance List de type PostesDansCategorie
            List<DemandeViewModel> ListDem = new List<DemandeViewModel>();
            // instance objet de PostesDansCategorie

            //recuperer tout les valeur de categories 
            var dem = db.Demandes.ToList();
            //boucler sur cat pour recuperer les categorie
            foreach (var d in dem)
            {
                //instance d'objet
                DemandeViewModel dvm = new DemandeViewModel();
                dvm.ID = d.ID;
                dvm.ClientID2 = d.ClientID2;
                dvm.ClientID = d.ClientID;
                dvm.Demande_title = d.Demande_title;
                dvm.Demande_description = d.Demande_description;
                dvm.Date_debut = d.Date_debut;
                dvm.Date_fin = d.Date_fin;
               
                ListDem.Add(dvm);
            }





            return (ListDem);

        }

    
        // GET: api/Demandes/5
        [ResponseType(typeof(Demande))]
        public IHttpActionResult GetDemande(int id)
        {
            Demande demande = db.Demandes.Find(id);
            DemandeViewModel dvm = new DemandeViewModel();
            if (demande == null)
            {
                return NotFound();
            }
            else
            {
                dvm.ID = demande.ID;
                dvm.ClientID2 = demande.ClientID2;
                dvm.ClientID = demande.ClientID;
                dvm.Demande_title = demande.Demande_title;
                dvm.Demande_description = demande.Demande_description;
                dvm.Date_debut = demande.Date_debut;
                dvm.Date_fin = demande.Date_fin;

            }

            return Ok(dvm);
        }

        // PUT: api/Demandes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDemande(int id, Demande demande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != demande.ID)
            {
                return BadRequest();
            }

            db.Entry(demande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeExists(id))
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

        // POST: api/Demandes
        [ResponseType(typeof(Demande))]
        public IHttpActionResult PostDemande(Demande demande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Demandes.Add(demande);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = demande }, demande);
        }

        // DELETE: api/Demandes/5
        [ResponseType(typeof(Demande))]
        public IHttpActionResult DeleteDemande(int id)
        {
            Demande demande = db.Demandes.Find(id);
            if (demande == null)
            {
                return NotFound();
            }

            db.Demandes.Remove(demande);
            db.SaveChanges();

            return Ok(demande);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DemandeExists(int id)
        {
            return db.Demandes.Count(e => e.ID == id) > 0;
        }

    }
}