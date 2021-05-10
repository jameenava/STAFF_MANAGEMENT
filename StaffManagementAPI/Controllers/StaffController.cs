using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using StaffLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StaffManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class StaffController : ControllerBase
    {
        DbProcedures dbObject = new DbProcedures();
        [HttpGet]
        public ActionResult GetAllStaff()
        {
            var staffList = dbObject.GetAllStaff();
            StringBuilder sb = new StringBuilder();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Ok(staffList);
        }
       
        [HttpGet("{type}")]
        public ActionResult GetStaffByItem(string type)
        {
            
            int choice;
            if (type == "teaching")
                choice = 1;
            else if (type == "administration")
                choice = 2;
            else
                choice = 3;
            List<dynamic> staffList = dbObject.GetEachStaffType(choice).Cast<dynamic>().ToList();

            if (staffList == null)
            {
                return NotFound();
            }
            return Ok(staffList);

        }
        [HttpGet("{id:int}")]
        public ActionResult GetStaff(int id)
        {
            var staffObj = dbObject.GetStaffByID(id);

           if(staffObj==null)
            {
                return NotFound();
            }
            return Ok(staffObj);

        }
        [HttpPost]
        public ActionResult AddStaff(dynamic json)
        {

            var details = JObject.Parse(json.ToString());
            dynamic staffObj;
            if (details["Designation"] == 1)
            {
                staffObj = JsonConvert.DeserializeObject<Teaching>(json.ToString());
            }
            else if (details["Designation"] == 2)
            {
                staffObj = JsonConvert.DeserializeObject<Administration>(json.ToString());
            }
            else
            {
                staffObj = JsonConvert.DeserializeObject<Supporting>(json.ToString());
            }

            dbObject.AddStaff(staffObj);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStaff(int id)
        {

            bool isFound = dbObject.DeleteStaff(id);

            if (!isFound)
            {
                return NotFound();
            }
            return Ok();

        }
        [HttpPut]
        public ActionResult UpdateStaff( dynamic json)
        {
            var details = JObject.Parse(json.ToString());
            var iD = (int)details["StaffID"];
            var item=dbObject.GetStaffByID(iD);
            if(item==null)
            {
                return NotFound();
            }
            dynamic staffObj;
            if (details["Designation"] == 1)
            {
                staffObj = JsonConvert.DeserializeObject<Teaching>(json.ToString());
            }
            else if (details["Designation"] == 2)
            {
                staffObj = JsonConvert.DeserializeObject<Administration>(json.ToString());
            }
            else
            {
                staffObj = JsonConvert.DeserializeObject<Supporting>(json.ToString());
            }

            dbObject.UpdateStaff(staffObj);
            return Ok();

        }
    }
}
