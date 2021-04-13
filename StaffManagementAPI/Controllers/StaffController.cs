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
            foreach (object staffs in staffList)
            {
                var jsonString = System.Text.Json.JsonSerializer.Serialize(staffs, staffs.GetType(), options);
                sb.Append(jsonString);
            }
            var staffDetails= sb.ToString();
            return Ok(staffDetails);
        }
        [HttpGet("{id}")]
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
        public ActionResult AddStaff([FromBody]dynamic json)
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
            return Ok();

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
        public ActionResult UpdateStaff([FromBody] dynamic json)
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
