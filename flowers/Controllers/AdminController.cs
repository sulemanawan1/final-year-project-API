using flowers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class AdminController : ApiController
    {
        flowersplantationEntities8 db = new flowersplantationEntities8();
        [HttpPost]

        public HttpResponseMessage AddUser(User user)


        {

            try
           {


                var users = db.Users.SqlQuery($"select * from users where username='{user.username}' and password='" +
                    $"{user.password}' ").ToList();


                if (users.Count > 0 )
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "username " + user.username + " already taken");
                }
                else


                    db.Users.Add(user);
                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, user.id);

            }
            catch (Exception e)

            { return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); }




        }

        [HttpGet]

        public HttpResponseMessage LoginUser(String username, String password)


        {


            try
            {
                var user = db.Users.SqlQuery($"select * from users where username='{username}' and password='{password}' ").ToList();

                if (user.Count==0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "login faild register your self");
                }
                else

                return Request.CreateResponse(HttpStatusCode.OK, user);








            }
            catch (Exception e)

            { return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); }








        } 

    }
}
