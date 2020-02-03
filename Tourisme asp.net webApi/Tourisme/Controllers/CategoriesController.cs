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
    public class CategoriesController : ApiController
    {
        public TourismeEntities db = new TourismeEntities();



        // GET: api/Categories
        // notre fonction va retourner une liste des objet PostesDansCategorie
        public List<CategorieViewModel> GetCategories()
        {
            //instance List de type PostesDansCategorie
            List<CategorieViewModel> ListCat = new List<CategorieViewModel>();
            // instance objet de PostesDansCategorie

            //recuperer tout les valeur de categories 
            var cat = db.Categories.ToList();
            //boucler sur cat pour recuperer les categorie
            foreach (var c in cat)
            {
                //instance d'objet
                CategorieViewModel cvm = new CategorieViewModel();
                cvm.ID = c.ID;
                cvm.Categorie_title = c.Catégorie_title;
                cvm.Categorie_icone = c.Catégorie_icone;
                ListCat.Add(cvm);
            }
            return (ListCat);
 }

        // GET: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorie(int id)
        {
            //instance List de type PostesDansCategorie

            // instance objet de PostesDansCategorie
            var cvm = new CategorieViewModel();
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            else
            {
                cvm.ID = categorie.ID;
                cvm.Categorie_title = categorie.Catégorie_title;
                cvm.Categorie_icone = categorie.Catégorie_icone;

            }

            return Ok(cvm);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.ID)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categorie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categorie.ID }, categorie);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categories.Count(e => e.ID == id) > 0;
        }
    }
}