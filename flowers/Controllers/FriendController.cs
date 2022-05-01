using flowers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flowers.Controllers
{
    public class FriendController : ApiController
    {
        flowersplantationEntities51 db = new flowersplantationEntities51();






       
















        // Send Requests

        [HttpPost]
        public HttpResponseMessage SendRequest(userrequest u)
        {
            try
            {


                db.userrequests.Add(new userrequest {
                    id=u.id,
                    reciever=u.reciever,
                    sender=u.sender,
                    status=u.status=0,
                
                });
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, u);

            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }

        // Request Accept/Reject

        [HttpGet]
        public HttpResponseMessage GetSendRequest(int userid)
        {

            try
            {
                var userrequests = db.userrequests.Join(db.Users, userreqtable => userreqtable.sender,
                    usertable => usertable.id, (userreqtable, userstable) =>
                  new {
                      userstable.username,
                      userstable.city,
                      userstable.id,
                      userreqtable.sender,
                      userreqtable.status,
                      userreqtable.reciever
                  }).Where(u => u.reciever == userid && u.status==0 );

                return Request.CreateResponse(HttpStatusCode.OK, userrequests);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }
        // Notification Bell







        [HttpGet]
        public HttpResponseMessage GetSendRequestCount(int userid)
        {

            try
            {
                var userrequests = db.userrequests.Join(db.Users, userreqtable => userreqtable.sender,
                    usertable => usertable.id, (userreqtable, userstable) =>
                  new {
                      userstable.username,
                      userstable.city,
                      userstable.id,
                      userreqtable.sender,
                      userreqtable.status,
                      userreqtable.reciever
                  }). Count(    u => u.reciever == userid && u.status == 0);

                List<myObj> objlist = new List<myObj>();

                objlist.Add(new myObj
                {
                    ob1 = userrequests,
                   
                });
                



                return Request.CreateResponse(HttpStatusCode.OK, objlist);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }














        [HttpGet]
        public HttpResponseMessage GetFriends(int userid )
        {

            try
            {
                //important
                //var friends = db.friends.Join(db.Users,f=>f.friend1,u=>u.id
                //, (f,u)=> new {   f.friend1,f.friend2,u.id,u.username,u.role,u.city })

                //    .Where(f => f.friend2 == userid );


                var friends = db.friends.Join(db.Users, f => f.friend1, u => u.id
                , (f, u) => new { f,u }).Join(db.Users, ff=>ff.f.friend2,uu=>uu.id,(ff,uu)=>new


                { loginuser= ff.u.username, friendcity = uu.city, friend =uu.username,friendid=ff.f.friend2 ,userid=ff.u.id     })

                    .Where(f => f.userid== userid );



                return Request.CreateResponse(HttpStatusCode.OK, friends);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }
        // Notification Bell



        [HttpGet]

        public HttpResponseMessage UsersList(int id)


        {


            try
            {

                var userslist = db.Users.Where(u => u.role == "user" && u.id != id);

                return Request.CreateResponse(HttpStatusCode.OK, userslist);



            }
            catch (Exception e)

            { return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); }


  }




        [HttpPost]
        public HttpResponseMessage Friends(friend f)
        {
            try
            {

                db.friends.Add(f);
                db.SaveChanges();
                db.friends.Add(new friend {friend1=f.friend2,friend2=f.friend1 });
                db.SaveChanges();

                int friend = (int)f.friend1;
                int friend2 = (int)f.friend2;
                int sender = 0;
                int reciever = 0;
                int status = 0;
                int id = 0;

                var userrequests = db.userrequests.Where(u => u.reciever == friend ||  u.reciever == friend2);
                var temp = userrequests.ToArray();


                foreach (var Array in temp)
                {
                    id = Array.id;
                    sender = Array.sender;
                    reciever = Array.reciever;
                    status = (int)Array.status;


                }
                status = 1;



                var userrequetsupdate = new userrequest
                {
                    id = id,
                    status = status,
                    sender = sender,
                  reciever =reciever,
                  




                };

                var req = db.userrequests.Find(id);

                db.Entry(req).CurrentValues.SetValues(userrequetsupdate);



                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, id);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }










        //////////////// Friend Plan Display ///////////////////////////









        [HttpGet]

        public HttpResponseMessage FriendPlanDisplay(int friendid)


        {


            try
            {
                // var user = db.Users.SqlQuery($"select * from users where username='{username}' and password='{password}' ").ToList();

                var friendplan = db.plans.Where(p => p.userid == friendid && p.plantype.Contains("private")).ToList();


              

                    return Request.CreateResponse(HttpStatusCode.OK, friendplan);








            }
            catch (Exception e)

            { return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); }








        }








        [HttpPost]
        public HttpResponseMessage UnFriends(friend f)
        {
            try
            {


                int friend = (int)f.friend1;
                int friend2 = (int)f.friend2;
                int sender = 0;
                int reciever = 0;
                int status = 0;
                int id = 0;

                var userrequests = db.userrequests.Where(u => u.reciever == friend || u.reciever == friend2);
                var temp = userrequests.ToArray();


                foreach (var Array in temp)
                {
                    id = Array.id;
                    sender = Array.sender;
                    reciever = Array.reciever;
                    status = (int)Array.status;


                }
                status = 2;



                var userrequetsupdate = new userrequest
                {
                    id = id,
                    status = status,
                    sender = sender,
                    reciever = reciever,





                };

                var req = db.userrequests.Find(id);

                db.Entry(req).CurrentValues.SetValues(userrequetsupdate);



                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, id);


            }

            catch (Exception exp)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.Message);
            }

        }






















        [HttpGet]

        public HttpResponseMessage FriendPlanFlowerDisplay(int pid)

            //
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
                       flowertable.plantable.planname,
                       flowertable.plantable.plantype
                     
                   }




                   ).Where(p => p.pid == pid && p.plantype=="private" );




                return Request.CreateResponse(HttpStatusCode.OK, f1);








            }
            catch (Exception e)

            { return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); }

































            /// new work////
            /// 


























        }

        private class myObj
        {
            public int ob1 { get; set; }
        }
    }
}
