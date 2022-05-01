using flowers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class FavoriteFlowerController : ApiController
    {
        flowersplantationEntities51 db = new flowersplantationEntities51();




        [HttpPost]
        public HttpResponseMessage FavFlower(flower f)
        {
            try
            {
                var flower = db.flowers.Find(f.id);
                if (flower == null)

                { return Request.CreateResponse(HttpStatusCode.NotFound, "Flower Not Found"); }
                f.status = 0;
                db.Entry(flower).CurrentValues.SetValues(f);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Flower Modify  Successfully");


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }



        [HttpGet]
        public HttpResponseMessage ShowFavoriteFlowers()
        {
            try
            {
                var flower = db.flowers.Where(f => f.status == 1);







                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }











    }
}
