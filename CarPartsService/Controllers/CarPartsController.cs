using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using NIHFService.Models;

namespace NIHFService.Controllers
{
    public class CarPartsController : ApiController
    {
        private CarPartsServiceContext db = new CarPartsServiceContext();

        // GET: api/CarParts
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<CarPart> GetCarParts()
        {
            return db.CarParts;
        }

        // GET: api/CarParts/5
        [ResponseType(typeof(CarPart))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetCarPart(string id)
        {
            CarPart carPart = db.CarParts.Find(id);
            if (carPart == null)
            {
                return NotFound();
            }

            return Ok(carPart);
        }

        // POST: api/CarParts
        [ResponseType(typeof(CarPart))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostCarPart(CarPart carPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (db.CarParts.AsNoTracking().Any(cp => cp.Id.Equals(carPart.Id)))
            {
                db.Entry(carPart).State = EntityState.Modified;
            }
            else
            {
                db.CarParts.Add(carPart);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CarPartExists(carPart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = carPart.Id }, carPart);
        }

        // DELETE: api/CarParts/5
        [ResponseType(typeof(CarPart))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteCarPart(string id)
        {
            CarPart carPart = db.CarParts.Find(id);
            if (carPart == null)
            {
                return NotFound();
            }

            db.CarParts.Remove(carPart);
            db.SaveChanges();

            return Ok(carPart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarPartExists(string id)
        {
            return db.CarParts.Count(e => e.Id == id) > 0;
        }
    }
}