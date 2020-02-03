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
    public class AvisController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();

        // GET: api/Avis
        public IHttpActionResult GetAvis()
        {
            List<AvisApiModel> avcs = new List<AvisApiModel>();
            var av = db.Avis.ToList();
            foreach(var a in av)
            {
                AvisApiModel avc = new AvisApiModel();
                avc.Id = a.Id;
                avc.Description = a.Description;
                avc.IdClient = a.IdClient;
                avc.Client_image = a.Client.Client_image;
                avc.Client_Prenom = a.Client.Client_Nom;

                avcs.Add(avc);



            }

            return Ok(avcs.OrderBy(x => Guid.NewGuid()).Take(3).ToList());
        }

        // GET: api/Avis/5
        [ResponseType(typeof(Avi))]
        public IHttpActionResult GetAvi(int id)
        {
            Avi avi = db.Avis.Find(id);
            if (avi == null)
            {
                return NotFound();
            }

            return Ok(avi);
        }

        // PUT: api/Avis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAvi(int id, Avi avi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avi.Id)
            {
                return BadRequest();
            }

            db.Entry(avi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AviExists(id))
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

        // POST: api/Avis
        [ResponseType(typeof(Avi))]
        public IHttpActionResult PostAvi(Avi avi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avis.Add(avi);
            db.SaveChanges();
           



            
            return CreatedAtRoute("DefaultApi", new { id = avi.Id }, avi);
        }

        // DELETE: api/Avis/5
        [ResponseType(typeof(Avi))]
        public IHttpActionResult DeleteAvi(int id)
        {
            Avi avi = db.Avis.Find(id);
            if (avi == null)
            {
                return NotFound();
            }

            db.Avis.Remove(avi);
            db.SaveChanges();

            return Ok(avi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AviExists(int id)
        {
            return db.Avis.Count(e => e.Id == id) > 0;
        }
    }
}