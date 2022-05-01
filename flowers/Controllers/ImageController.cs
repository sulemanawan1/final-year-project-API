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
        flowersplantationEntities51 db = new flowersplantationEntities51();








        [HttpPost]

        public HttpResponseMessage UploadFiles()

        {
            var request = HttpContext.Current.Request;


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


            // image_name = postedFile.FileName








            var name = request.Form["name"];
            var color = request.Form["color"];
            var startmonth = request.Form["startmonth"];
            var endmonth = request.Form["endmonth"];
            var month = request.Form["month"];
            var season = request.Form["season"];
            var growtime = request.Form["growtime"];
            var height = request.Form["height"];
            var minheight = request.Form["minheight"];
            var maxheight = request.Form["maxheight"];
            var category = request.Form["category"];
            var shape = request.Form["shape"];
            var fragrance = request.Form["fragrance"];
            var lifetime = request.Form["lifetime"];
            var altitude = request.Form["altitude"];
            var minaltitude = request.Form["minaltitude"];
            var maxaltitude = request.Form["maxaltitude"];
            var area = request.Form["area"];
            var watering = request.Form["watering"];
            var sunlight = request.Form["sunlight"];
            var pesticide = request.Form["pesticide"];
            var disease = request.Form["disease"];
            var soiltype = request.Form["soiltype"];
            var fertilizer = request.Form["fertilizer"];
            var status = request.Form["status"];
          







            //  db.flowerimages.Add(new flowerimage { image_name=postedFile.FileName});

            flower f = new flower();
            f.name = name;
            f.color = color;
            f.startmonth = int.Parse( startmonth);
            f.endmonth = int.Parse( endmonth);
            f.month = month;
            f.season = season;
            f.growtime = int.Parse(       growtime);
            f.height = height;
            f.minheight =int.Parse(    minheight);
            f.maxheight =int.Parse(    maxheight);
            f.category = category;
            f.shape = shape;
            f.fragrance = fragrance;
            f.lifetime = int.Parse( lifetime);
            f.altitude = int.Parse(altitude);
            f.minaltitude = int.Parse  ( minaltitude);
            f.maxaltitude =int.Parse( maxaltitude);
            f.area = area;
            f.watering = watering;
            f.sunlight = sunlight;
            f.pesticide = pesticide;
            f.disease = disease;
            f.soiltype = soiltype;
            f.disease = disease;
            f.fertilizer = fertilizer;
            f.status =int.Parse( status="0");
           
            f.image = postedFile.FileName;
            db.flowers.Add(f);


            //            db.flowers.Add(new flower
            //           {


            //name= f.name,
            //color= f.color,
            //startmonth=f.startmonth,
            //endmonth=f.endmonth,
            //month= f.month,
            //season=f.season,
            //growtime=f.growtime,
            //  height=f.height   ,
            //minheight= f.minheight,
            //maxheight=f.maxaltitude,
            //category=f.category,
            //shape=f.shape,
            //fragrance=f.fragrance,
            //lifetime=f.lifetime,
            //altitude=f.altitude,
            //minaltitude=f.minaltitude,
            //maxaltitude=f.maxaltitude,
            //area=f.area,
            //watering=f.watering,
            //sunlight=f.sunlight,
            //pesticide=f.pesticide,
            //disease=f.disease,
            //soiltype=f.soiltype,
            //fertilizer=f.fertilizer,
            //id=f.id,
            //status=f.status,
            //image= postedFile.FileName
            //            }





            //                );


            db.SaveChanges();

            //Send OK Response to Client.


            return Request.CreateResponse(HttpStatusCode.OK, path + fileName);
        }
    }






}
