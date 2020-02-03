using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Tourisme.Data;
using Tourisme.Models;

namespace Tourisme.Controllers
{
    public class PublicitNavBarsController : ApiController
    {
        private TourismeEntities db = new TourismeEntities();

        // GET: api/PublicitNavBars
       
        public List<NavBarViewModel> GetPublicitNavBars()

        {
            List<NavBarViewModel> ListNav = new List<NavBarViewModel>();
            var nv = db.PublicitNavBars.ToList();
            foreach(var n in nv)
            {
                NavBarViewModel nvb = new NavBarViewModel();
                nvb.ID = n.ID;
                nvb.Pub_image = n.Pub_image;
                nvb.Pub_title = n.Pub_title;
               
                ListNav.Add(nvb);
            }
            return ListNav;
        }

        // GET: api/PublicitNavBars/5
        [ResponseType(typeof(PublicitNavBar))]
        public IHttpActionResult GetPublicitNavBar(int id)
        {
            PublicitNavBar publicitNavBar = db.PublicitNavBars.Find(id);
            if (publicitNavBar == null)
            {
                return NotFound();
            }

            return Ok(publicitNavBar);
        }

        // PUT: api/PublicitNavBars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublicitNavBar(int id, PublicitNavBar publicitNavBar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publicitNavBar.ID)
            {
                return BadRequest();
            }

            db.Entry(publicitNavBar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicitNavBarExists(id))
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

        // POST: api/PublicitNavBars
        [ResponseType(typeof(PublicitNavBar))]
        public HttpResponseMessage PostPublicitNavBar()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);
            //Save to DB
            PublicitNavBar nvm = new PublicitNavBar();
            nvm.ID = 0;
            nvm.Pub_image = imageName;
            nvm.Pub_title = httpRequest["ImageCaption"];


                db.PublicitNavBars.Add(nvm);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // DELETE: api/PublicitNavBars/5
        [ResponseType(typeof(PublicitNavBar))]
        public IHttpActionResult DeletePublicitNavBar(int id)
        {
            PublicitNavBar publicitNavBar = db.PublicitNavBars.Find(id);
            if (publicitNavBar == null)
            {
                return NotFound();
            }

            db.PublicitNavBars.Remove(publicitNavBar);
            db.SaveChanges();

            return Ok(publicitNavBar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicitNavBarExists(int id)
        {
            return db.PublicitNavBars.Count(e => e.ID == id) > 0;
        }
    }
}