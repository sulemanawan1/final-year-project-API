using flowers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class NurseryController : ApiController
    {
        flowersplantationEntities51 db = new flowersplantationEntities51();




        [HttpPost]
        public HttpResponseMessage AddNursery(nursery n)
        {
            try
            {


                db.nurseries.Add(n);
                db.SaveChanges();


                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK,n.nid);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }



        [HttpGet]
        public HttpResponseMessage AllNurseries( int userid)
        {
            try
            {
                var nursery = db.nurseries.Where(u => u.userid == userid);





                return Request.CreateResponse(HttpStatusCode.OK, nursery);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }






        [HttpPost]
        public HttpResponseMessage AddNurseryStock(nurserystock n)
        {
            try
            {


                db.nurserystocks.Add(n);
                db.SaveChanges();


                //Send OK Response to Client.


                return Request.CreateResponse(HttpStatusCode.OK, n.fid);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }
        }






        [HttpGet]
        public HttpResponseMessage NurseryFlowerQuantity(int userid, int nid)
        {
            try
            {
                var nursery = db.nurserystocks.Join(db.nurseries, nurserystocktable => nurserystocktable.nid,
                    nurserytable => nurserytable.nid, (nurserystocktable, nurserytable) => new
                    {
                        nurserystocktable,
                        nurserytable
                    }).Join(db.flowers, nurserystocktable => nurserystocktable.nurserystocktable.fid,

                    flowerstable => flowerstable.id, (nurserystocktable, flowerstable) => new { nurserystocktable, flowerstable }
                    ).Join(db.Users, nurserytable => nurserytable.nurserystocktable.nurserytable.userid,
                    userstable => userstable.id, (nurserytable, usertable) => new
                    {
                        nurserytable.nurserystocktable.nurserystocktable.flowerquantity,
                        nurserytable.nurserystocktable.nurserystocktable.fid,
                        nurserytable.nurserystocktable.nurserystocktable.id,
                        nurserytable.flowerstable.name,
          
                        nurserytable.nurserystocktable.nurserytable.userid,
                        nurserytable.nurserystocktable.nurserytable.nid,
                       
                    }
                    ).Where(u =>u.userid == userid && u.nid==nid);





                return Request.CreateResponse(HttpStatusCode.OK, nursery);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }





        [HttpGet]
        public HttpResponseMessage ShowAllNursery(int fid)
        {
            try
            {
                var nursery = db.nurserystocks.Join(db.nurseries, nurserystocktable => nurserystocktable.nid,
                    nurserytable => nurserytable.nid, (nurserystocktable, nurserytable) => new
                    {
                        nurserystocktable,
                        nurserytable
                    }).Join(db.flowers, nurserystocktable => nurserystocktable.nurserystocktable.fid,

                    flowerstable => flowerstable.id,
                    (nurserystocktable, flowerstable) => new { nurserystocktable.nurserytable.naddress,

                       nurserystocktable.nurserystocktable.flowerquantity,
             
                        nurserystocktable.nurserytable.nid,
                        nurserystocktable.nurserytable.nname,
                        nurserystocktable.nurserytable.ncontact,
                        nurserystocktable.nurserytable.userid,
                        flowerstable.name,
                        flowerstable .id}
                    ). Where(u => u.id == fid);





                return Request.CreateResponse(HttpStatusCode.OK, nursery);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }



        [HttpPost]
        public HttpResponseMessage UpdateNurseryStock( nurserystock n)
        {
            try
            {

                var nstock = db.nurserystocks.Find(n.id);
                if (nstock == null)

                { return Request.CreateResponse(HttpStatusCode.NotFound, " Not Found"); }

                db.Entry(nstock).CurrentValues.SetValues(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Mursery Stock  Modify  Successfully");


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }



        [HttpPost]
        public HttpResponseMessage AddSeedlingStock( nurserystock n,int count)
        {
            try
            {
                
                //var nstock = db.nurserystocks.Find(n.id);


                var nstocks = db.nurserystocks.Where(m=>m.id==n.id).FirstOrDefault();
                if (nstocks == null)

                { return Request.CreateResponse(HttpStatusCode.NotFound, " Not Found"); }


                n.flowerquantity =  ( n.flowerquantity+count);
               db.Entry(nstocks).CurrentValues.SetValues(n);
                db.SaveChanges();



                var nursery = db.nurserystocks.Join(db.nurseries, nurserystocktable => nurserystocktable.nid,
                   nurserytable => nurserytable.nid, (nurserystocktable, nurserytable) => new
                   {
                       nurserystocktable,
                       nurserytable
                   }).Join(db.flowers, nurserystocktable => nurserystocktable.nurserystocktable.fid,

                   flowerstable => flowerstable.id, (nurserystocktable, flowerstable) => new { nurserystocktable, flowerstable }
                   ).Join(db.Users, nurserytable => nurserytable.nurserystocktable.nurserytable.userid,
                   userstable => userstable.id, (nurserytable, usertable) => new
                   {
                       nurserytable.nurserystocktable.nurserystocktable.flowerquantity,
                       nurserytable.nurserystocktable.nurserystocktable.fid,
                       nurserytable.nurserystocktable.nurserystocktable.id,
                       nurserytable.flowerstable.name,

                       nurserytable.nurserystocktable.nurserytable.userid,
                       nurserytable.nurserystocktable.nurserytable.nid,

                   }
                   ).Where(u =>u.nid ==n. nid);



                return Request.CreateResponse(HttpStatusCode.OK,nursery);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }





        [HttpPost]
        public HttpResponseMessage SubSeedlingStock(nurserystock n, int count)
        {
            try
            {

                //var nstock = db.nurserystocks.Find(n.id);


                var nstocks = db.nurserystocks.Where(m => m.id == n.id).FirstOrDefault();
                if (nstocks == null)

                { return Request.CreateResponse(HttpStatusCode.NotFound, " Not Found"); }


                n.flowerquantity = (n.flowerquantity - count);
                db.Entry(nstocks).CurrentValues.SetValues(n);
                db.SaveChanges();



                var nursery = db.nurserystocks.Join(db.nurseries, nurserystocktable => nurserystocktable.nid,
                   nurserytable => nurserytable.nid, (nurserystocktable, nurserytable) => new
                   {
                       nurserystocktable,
                       nurserytable
                   }).Join(db.flowers, nurserystocktable => nurserystocktable.nurserystocktable.fid,

                   flowerstable => flowerstable.id, (nurserystocktable, flowerstable) => new { nurserystocktable, flowerstable }
                   ).Join(db.Users, nurserytable => nurserytable.nurserystocktable.nurserytable.userid,
                   userstable => userstable.id, (nurserytable, usertable) => new
                   {
                       nurserytable.nurserystocktable.nurserystocktable.flowerquantity,
                       nurserytable.nurserystocktable.nurserystocktable.fid,
                       nurserytable.nurserystocktable.nurserystocktable.id,
                       nurserytable.flowerstable.name,

                       nurserytable.nurserystocktable.nurserytable.userid,
                       nurserytable.nurserystocktable.nurserytable.nid,

                   }
                   ).Where(u => u.nid == n.nid);



                return Request.CreateResponse(HttpStatusCode.OK, nursery);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }




    }
}
