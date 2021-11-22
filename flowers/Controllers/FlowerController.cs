using flowers.Models;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;

namespace flowers.Controllers
{
    public class FlowerController : ApiController
    {
        flowersplantationEntities8 db = new flowersplantationEntities8();
       


        [HttpGet]
        public HttpResponseMessage GetFlowerImages()
        {
            try
            {
                
                var Images = db.flowerimages.OrderBy(f =>f.id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, Images);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }




        [HttpGet]
        public HttpResponseMessage DeleteFlower(int id)
        {
            try
            {
                var flower = db.myflowers.SingleOrDefault(x => x.id == id);
                db.myflowers.Remove(flower);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "flower deleted successfully ");


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }


        [HttpPost]
        public HttpResponseMessage UpdateFlower(myflower f)
        {
            try
            {
                var flower = db.myflowers.Find(f.id);

                db.Entry(flower).CurrentValues.SetValues(f);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Flower Modify  Successfully ");


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }












        [HttpGet]
        public HttpResponseMessage AllFlowers( )
        {
            try
            {
                var flower =db.myflowers.SqlQuery($"select * from myflowers ").ToList();
               
                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }
        [HttpGet]
        public HttpResponseMessage flowerbyseason(String season)
        {
            try
            {
               var flower = db.myflowers.SqlQuery($"select * from myflowers where season= '{season}'");
            


                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }
            catch (Exception exp)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }


        [HttpGet]
        public HttpResponseMessage flowerbygroup(String season)
        {
            try
            {
                var flower = db.myflowers.SqlQuery($"select season,count(season)  from flowersdata group by ${season}");

                return Request.CreateResponse(HttpStatusCode.OK, flower);


            }
            catch (Exception exp)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }


        [HttpPost]
        public HttpResponseMessage AddFlower(myflower f)
        {
            try
            { 

               
                db.myflowers.Add(f);
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

        public HttpResponseMessage UploadFiles()

        {


            string line = "\\";
            //Create the Directory.
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Fetch the File Name.
            string fileName = Path.GetFileName(postedFile.FileName);

            //Save the File.
            postedFile.SaveAs(path + fileName);
            // save data to database
            
      db.flowerimages.Add(new flowerimage
      {

        
          image_name= postedFile.FileName
      }
          );


            db.SaveChanges();

            //Send OK Response to Client.


            return Request.CreateResponse(HttpStatusCode.OK, path + fileName);
        }
    }

}