using flowers.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class PlansController : ApiController
    {




        flowersplantationEntities51 db = new flowersplantationEntities51();






        [HttpGet]
        public HttpResponseMessage AllPlans(int userid)
        {
            try
            {
                var flower = db.plans.Where(p => p.userid == userid).ToList();






                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }

















        [HttpPost]
        public HttpResponseMessage Addplan(plan p)
        {
            try
            {



                db.plans.Add(p);
                db.SaveChanges();

                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK, p.planname);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }






        [HttpPost]
        public HttpResponseMessage Addplanflower(planflower pf)
        {
            try
            {
                
                db.planflowers.Add(pf);
                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, pf.pid);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage PlanFlowerDisplay(int pid)
        {
            try
            {



                var f1 = db.plans.Join(db.planflowers,
                  plantable => plantable.pid,
                   planflowertable => planflowertable.pid, (plantable, planflowertable) => new
                   {
                       plantable,
                       planflowertable

                   }).Join(db.flowers,
                   flowertable => flowertable.planflowertable.fid,
                   f => f.id, (flowertable, f) => new
                   {


                       f.id,
                       f.color,
                       f.height,
                       f.maxaltitude,
                       f.minaltitude,
                       f.minheight,
                       f.maxheight,
                       f.image,
                       f.lifetime,
                       f.fertilizer,
                       f.fragrance,
                       f.growtime,
                       f.season,
                       f.watering,
                       f.soiltype,
                       f.shape,
                       f.pesticide,
                       f.sunlight,
                       f.startmonth,
                       f.endmonth,
                       f.disease,
                       f.area,
                       f.month,
                       f.category,
                       f.name,
                       flowertable.planflowertable.fid,
                       flowertable.planflowertable.pid,
                       flowertable.plantable.planname
                   }




                   ).Where(p => p.pid == pid);






                return Request.CreateResponse(HttpStatusCode.OK, f1);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }














        [HttpGet]
        public HttpResponseMessage PlanbyMonth(int pid)
        {
            try
            {

                var temp = db.plans.Where(u => u.pid == pid);


                var arr = temp.ToArray();

                string input1 = "";
                int val1 = 0;

                foreach (var Array in arr)
                {
                    input1 = Array.startmonth;







                }



                switch (input1)
                {
                    case "january":
                    case "jan":
                        input1 = "1";
                        val1 = int.Parse(input1);

                        break;

                    case "febuary":
                    case "feb":
                        input1 = "2";
                        val1 = int.Parse(input1);
                        break;

                    case "march":
                    case "mar":
                        input1 = "3";
                        val1 = int.Parse(input1);
                        break;

                    case "april":
                    case "apr":
                        input1 = "4";
                        val1 = int.Parse(input1);
                        break;

                    case "may":
                        input1 = "5";
                        val1 = int.Parse(input1);
                        break;

                    case "june":
                    case "jun":
                        input1 = "6";
                        val1 = int.Parse(input1);
                        break;

                    case "july":
                    case "jul":
                        input1 = "7";
                        val1 = int.Parse(input1);
                        break;

                    case "august":
                    case "aug":
                        input1 = "8";
                        val1 = int.Parse(input1);
                        break;

                    case "september":
                    case "sep":
                    case "sept":
                        input1 = "9";
                        val1 = int.Parse(input1);
                        break;

                    case "october":
                    case "oct":
                        input1 = "10";
                        val1 = int.Parse(input1);
                        break;

                    case "november":
                    case "nov":
                        input1 = "11";
                        val1 = int.Parse(input1);
                        break;

                    case "december":
                    case "dec":
                        input1 = "12";
                        val1 = int.Parse(input1);
                        break;
                }


                Console.WriteLine(val1);



                var flowers = db.flowers.Where(f => f.startmonth > val1);





                return Request.CreateResponse(HttpStatusCode.OK, flowers);











            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }







        //public HttpResponseMessage GetPlans()
        //{
        //    try
        //    {


        //        var myplan = db.flowers.Join(db.plans,
        //               f => f.id, fp => fp.flowerid, (f, fp) =>
        //               new { f.growtime, f.lifetime, f.id }).OrderByDescending(x => x.growtime).Take(1);
        //        var arr = myplan.ToArray();
        //        int growtime=0;
        //        int lifetime=0;
        //        int days = 0;
        //        foreach(var Array in arr)
        //        {

        //                growtime= (int)Array.growtime;
        //                lifetime= (int)Array.lifetime;
        //        }

        //        Console.WriteLine(growtime);
        //        Console.WriteLine(lifetime);
        //        days = growtime + lifetime;

        //        var finalplan = db.flowers.Where(f => f.growtime == days);






        //        return Request.CreateResponse(HttpStatusCode.OK,finalplan);


        //    }

        //    catch (Exception exp)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
        //    }

        //}


























    }
}
