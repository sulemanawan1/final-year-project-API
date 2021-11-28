using flowers.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace flowers.Controllers
{
    public class ImageController : ApiController
    {
        flowersplantationEntities35 db = new flowersplantationEntities35();





        [HttpGet]
        public HttpResponseMessage GetFlowerImages()
        {
            try
            {

                var Images = db.flowerimages.OrderBy(f=>f.id);
                return Request.CreateResponse(HttpStatusCode.OK, Images);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }




        [HttpPost]

        public HttpResponseMessage UploadFiles()

        {


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


            db.flowerimages.Add(new  flowerimage
            {
               

                image_name = postedFile.FileName
            }
                );


            db.SaveChanges();

            //Send OK Response to Client.


            return Request.CreateResponse(HttpStatusCode.OK, path + fileName);
        }
    }






}
