
using FlyAPI.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FlyAPI.Controllers
{
    public class UserController : ApiController
    {

        [RoutePrefix("Api/User")]

        public class FlightManagementSystemEntities : ApiController
        {
            FlightManagementSystemEntities objEntity = new FlightManagementSystemEntities();

            [HttpGet]
            [Route("GetUserDetails")]
            public IQueryable<User> GetEmaployee()
            {
                try
                {
                    return objEntity.Configuration.BindParameter(User);
                }
                catch (Exception)
                {
                    throw;
                }
            }


            [HttpGet]
            [Route("GetUserDetailsById/{userId}")]
            public IHttpActionResult GetUserById(string userId)
            {
                User objUser = new User();
                int ID = Convert.ToInt32(userId);
                try
                {
                    objUser = objEntity.User;
                    if (objUser == null)
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                return Ok(objUser);
            }

            [HttpPost]
            [Route("InsertUserDetails")]
            public IHttpActionResult PostUser(User data)
            {
                string message = "";
                if (data != null)
                {

                    try
                    {
                        objEntity.User.(data);
                        int result = objEntity.GetUserById();
                        if (result > 0)
                        {
                            message = "User has been sussfully added";
                        }
                        else
                        {
                            message = "faild";
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                return Ok(message);
            }

            [HttpPut]
            [Route("UpdateEmployeeDetails")]
            public IHttpActionResult PutUserMaster(User user)
            {
                string message = "";
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    User objUser = new User();
                    objUser = objEntity.User.Find(user.UserId);
                    if (objUser != null)
                    {
                        objUser.Username = user.Username;
                        objUser.LastName = user.LastName;
                        objUser.EmailId = user.EmailId;
                        objUser.MobileNo = user.MobileNo;
                        objUser.Address = user.Address;
                        objUser.PinCode = user.PinCode;

                    }

                    int result = objEntity.SaveChanges();
                    if (result > 0)
                    {
                        message = "User has been sussfully updated";
                    }
                    else
                    {
                        message = "faild";
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                return Ok(message);
            }

            [HttpDelete]
            [Route("DeleteUserDetails/{id}")]
            public IHttpActionResult DeleteUserDelete(int id)
            {
                string message = "";
                UserDetail user = objEntity.UserDetails.Find(id);
                if (user == null)
                {
                    return NotFound();
                }

                objEntity.UserDetails.Remove(user);
                int result = objEntity.SaveChanges();
                if (result > 0)
                {
                    message = "User has been sussfully deleted";
                }
                else
                {
                    message = "faild";
                }

                return Ok(message);
            }
        }
    }
}

