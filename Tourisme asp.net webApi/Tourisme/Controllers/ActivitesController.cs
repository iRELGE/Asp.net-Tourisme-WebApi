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
    public class ActivitesController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();

        // GET: api/Activites
        [HttpGet]
        public IHttpActionResult GetActivites()
        {
            List<ActiviteApiModel> acts = new List<ActiviteApiModel>();
            var activites = db.Activites.ToList();
            foreach(var a in activites)
            {
                ActiviteApiModel act = new ActiviteApiModel();
                act.Id = a.Id;
                act.Activite_titre = a.Activite_titre;
                act.Activite_description = a.Activite_description;
                act.Activite_image = a.Activite_image;
                act.Activite_NombreAvis = a.AcriviteAvis.Count();
                act.Activite_NoteAvis = a.AcriviteAvis.Average(p => p.AcriviteAvi_note);
                act.Activite_Catégorie = a.Poste.Categorie.Catégorie_title;
                //List<ActiviteAviModel> lav = new List<ActiviteAviModel>();
                //foreach(var av in a.AcriviteAvis)
                //{
                //    ActiviteAviModel acta = new ActiviteAviModel();
                //    acta.AcriviteAvi_Titre = av.AcriviteAvi_Titre;
                //    acta.AcriviteAvi_datecreation = av.AcriviteAvi_datecreation;
                //    acta.AcriviteAvi_description = av.AcriviteAvi_description;
                //    acta.AcriviteAvi_note = av.AcriviteAvi_note;
                //    lav.Add(acta);


                //}
                //act.AcriviteAvis = lav;
                acts.Add(act);

            }
            var lacts = acts.OrderByDescending(p => p.Activite_NombreAvis).ToList();

            return Ok(lacts.OrderByDescending(p => p.Activite_NoteAvis).Take(3).ToList());
        }

        // GET: api/Activites/5
        [ResponseType(typeof(Activite))]
        public IHttpActionResult GetActivite(int id)
        {
            Activite activite = db.Activites.Find(id);
            if (activite == null)
            {
                return NotFound();
            }

            return Ok(activite);
        }

        // PUT: api/Activites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivite(int id, Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activite.Id)
            {
                return BadRequest();
            }

            db.Entry(activite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiviteExists(id))
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

        // POST: api/Activites
        [ResponseType(typeof(Activite))]
        public IHttpActionResult PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activites.Add(activite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activite.Id }, activite);
        }

        // DELETE: api/Activites/5
        [ResponseType(typeof(Activite))]
        public IHttpActionResult DeleteActivite(int id)
        {
            Activite activite = db.Activites.Find(id);
            if (activite == null)
            {
                return NotFound();
            }

            db.Activites.Remove(activite);
            db.SaveChanges();

            return Ok(activite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActiviteExists(int id)
        {
            return db.Activites.Count(e => e.Id == id) > 0;
        }
    }
}