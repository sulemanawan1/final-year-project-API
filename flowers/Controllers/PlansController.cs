using flowers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class PlansController : ApiController
    {




        flowersplantationEntities35 db = new flowersplantationEntities35();




        [HttpPost]
        public HttpResponseMessage Addplan(plan plan)
        {
            try
            {



                db.plans.Add(plan);
                db.SaveChanges();

                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK, plan.planname);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }


        //[HttpGet]
        //public HttpResponseMessage AllPlans(int id)
        //{
        //    try
        //    { 
              

        //        //var myplan = db.plans.Join(db.flowers,
        //        //    d => d.p, f => f.id, (d, f) =>
        //        //    new { d, f }).Join(db.Users, plan => plan.d.plannedby,
        //        //    user => user.id, (plan, user) => new
        //        //    {
        //        //        user.username,
        //        //        user.id,
        //        //        plan.d.planname,
        //        //        plan.f.name,
        //        //        plan.d.flowerid,
        //        //        plan.d.startmonth,
                    
        //        //        plan.d.plannedby
        //        //    }
        //        //    ).Where(f => f.plannedby == id) . ToList();






        //        //return Request.CreateResponse(HttpStatusCode.OK, myplan);


        //    }

        //    catch (Exception exp)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
        //    }

        //}







        [HttpGet]
        public HttpResponseMessage PlanbyMonth(string input1 )
        {
            try
            {
                int val1 = 0;
                //int val2 = 0;


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

                //switch (input2)
                //{
                //    case "january":
                //    case "jan":
                //        input2 = "1";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "febuary":
                //    case "feb":
                //        input2 = "2";
                //        int.Parse(input2);
                //        break;

                //    case "march":
                //    case "mar":
                //        input2 = "3";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "april":
                //    case "apr":
                //        input2 = "4";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "may":
                //        input2 = "5";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "june":
                //    case "jun":
                //        input2 = "6";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "july":
                //    case "jul":
                //        input2 = "7";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "august":
                //    case "aug":
                //        input2 = "8";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "september":
                //    case "sep":
                //    case "sept":
                //        input2 = "9";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "october":
                //    case "oct":
                //        input2 = "10";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "november":
                //    case "nov":
                //        input2 = "11";
                //        val2 = int.Parse(input2);
                //        break;

                //    case "december":
                //    case "dec":
                //        input2 = "12";
                //        val2 = int.Parse(input2);
                //        break;



                     
                //}



                var myplan = db.flowers.Where(s => s.startmonth == val1 );

                return Request.CreateResponse(HttpStatusCode.OK, myplan);











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
