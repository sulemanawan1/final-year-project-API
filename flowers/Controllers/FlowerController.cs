using flowers.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class FlowerController : ApiController
    {
        flowersplantationEntities35 db = new flowersplantationEntities35();





        [HttpGet]
        public HttpResponseMessage DeleteFlower(int id)
        {
            try
            {
                var flower = db.flowers.SingleOrDefault(x => x.id == id);
                db.flowers.Remove(flower);

                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "flower deleted successfully ");


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }


        [HttpPost]
        public HttpResponseMessage UpdateFlower(flower f)
        {
            try
            {
                var flower = db.flowers.Find(f.id);
                if (flower == null)

                { return Request.CreateResponse(HttpStatusCode.NotFound, "Flower Not Found"); }

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
        public HttpResponseMessage AllFlowers()
        {
            try
            {
                var flower = db.flowers.SqlQuery($"select * from flowers ").ToList();







                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }






        [HttpGet]
        public HttpResponseMessage AllFlowersbyCity(String area)
        {
            try
            {
                //var flower = db.flowers.SqlQuery($"select * from flowers ").ToList();

                var flower = db.flowers.Join(db.flowercities,
                    flower1 => flower1.area,
                    flowercity => flowercity.area,
                    (flower1, flowercity) => new
                    {
                        flower1.name,
                        flower1.color,
                        flower1.startmonth,
                        flower1.endmonth,
                        flower1.season,

                        flower1.growtime,
                        flower1.maxheight,
                        flower1.minheight,
                        flower1.category,
                        flower1.shape,
                        flower1.fragrance,
                        flower1.lifetime,
                        flower1.minaltitude,
                        flower1.maxaltitude,
                        flower1.watering,
                        flower1.sunlight,
                        flower1.disease,
                        flower1.pesticide,
                        flower1.soiltype,
                        flower1.fertilizer,

                        flowercity.area
                    }).
                    Where(ff => ff.area == area);




                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }














        [HttpGet]
        public HttpResponseMessage searchbycolors(String color, int minaltitude
            , int maxaltitude, String category, int minheight, int maxheight
            )
        {
            try
            {

                var f = db.flowers.
                  Join(db.flowercolors,
                  fid => fid.id,
                  cid => cid.id,
                  (fid, uid) => new
                  {
                      fid.name,
                      uid.color,
                      fid.category,
                      fid.season,
                      fid.month,
                      fid.pesticide,
                      fid.minheight,
                      fid.maxheight,
                      fid.endmonth,
                      fid.fragrance,
                      fid.fertilizer,
                      fid.disease,
                      fid.sunlight,
                      fid.watering,
                      fid.area,
                      fid.altitude,
                      fid.minaltitude,
                      fid.maxaltitude,
                      fid.height,
                      fid.growtime,
                      fid.lifetime,
                      fid.shape,
                      fid.soiltype
                  }).Where(c => c.color == color && c.minaltitude >= minaltitude && c.maxaltitude <= maxaltitude && c.category == category &&
                  c.minheight >= minheight && c.maxheight <= maxheight

                  );







                return Request.CreateResponse(HttpStatusCode.OK, f);


            }



            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }


















        [HttpGet]
        public HttpResponseMessage colors(String red, String blue, String purple, String white, String orange, String pink, String yellow
            , String black, String brown, String green, String category, String season, String area)
        {
            try
            {

                //var f = db.flowers.
                //  Join(db.flowercolors,
                //  fid => fid.id,
                //  cid => cid.id,
                //  (fid, uid) => new
                //  {
                //      fid.name,
                //      uid.color,
                //      fid.category,
                //      fid.season,
                //      fid.month,
                //      fid.pesticide,
                //      fid.minheight,
                //      fid.maxheight,
                //      fid.endmonth,
                //      fid.fragrance,
                //      fid.fertilizer,
                //      fid.disease,
                //      fid.sunlight,
                //      fid.watering,
                //      fid.area,
                //      fid.altitude,
                //      fid.minaltitude,
                //      fid.maxaltitude,
                //      fid.height,
                //      fid.growtime,
                //      fid.lifetime,
                //      fid.shape,
                //      fid.soiltype
                //  }).Where(c => c.color == red || c.color == blue || c.color == purple || c.color == white || c.color == yellow || c.color == pink
                //|| c.color == brown || c.color == black || c.color == orange || c.color == green


                //  ).Where(c => c.category == category);







                var f = db.flowers.
                  Join(db.flowercolors,
                  flowertable => flowertable.id,
                  flowercolortable => flowercolortable.id,
                  (flowertable, flowercolortable) => new
                  {
                      flowertable,
                      flowercolortable
                  }).Join(db.flowercities,
                  flowercitytable => flowercitytable.flowertable.area,
                  flowertable => flowertable.area,
                  (flowercitytable, flowertable) => new
                  {
                      flowercitytable.flowertable.name,
                      flowercitytable.flowercolortable.color,
                      flowercitytable.flowertable.month,
                      flowercitytable.flowertable.startmonth,
                      flowercitytable.flowertable.endmonth,
                      flowercitytable.flowertable.season,
                      flowercitytable.flowertable.growtime,
                      flowercitytable.flowertable.minheight,
                      flowercitytable.flowertable.maxheight,
                      flowercitytable.flowertable.category,
                      flowercitytable.flowertable.shape,
                      flowercitytable.flowertable.fragrance,
                      flowercitytable.flowertable.lifetime,
                      flowercitytable.flowertable.minaltitude,
                      flowercitytable.flowertable.maxaltitude,
                      flowercitytable.flowertable.watering,
                      flowercitytable.flowertable.sunlight,
                      flowercitytable.flowertable.disease,
                      flowercitytable.flowertable.pesticide,
                      flowercitytable.flowertable.soiltype,
                      flowercitytable.flowertable.fertilizer,
                      flowertable.area,





                  }).Where(c => c.color == red || c.color == blue || c.color == purple || c.color == white || c.color == yellow || c.color == pink
                || c.color == brown || c.color == black || c.color == orange || c.color == green

                  ).Where(c => c.category == category && c.season.Contains(season) && c.area == area);



















                return Request.CreateResponse(HttpStatusCode.OK, f);


            }



            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }




















        [HttpGet]
        public HttpResponseMessage search(String q)
        {
            try
            {
                var flower = db.flowers.Where(s => s.name.Contains(q));

                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }















        [HttpPost]
        public HttpResponseMessage AddFlower(flower f)
        {
            try
            {


                db.flowers.Add(f);
                db.SaveChanges();


                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK, f.id);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }


        [HttpPost]
        public HttpResponseMessage AddColors(flowercolor f)
        {
            try
            {


                db.flowercolors.Add(new flowercolor
                {
                    color = f.color

                });
                db.SaveChanges();


                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK, f.id);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }





    }

}