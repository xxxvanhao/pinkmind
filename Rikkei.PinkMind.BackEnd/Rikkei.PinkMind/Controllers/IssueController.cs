using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Implementation;
using Rikkei.PindMind.DAO.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  public class IssueController : Controller
  {
    IssueReponsetory Issuerp;
    public IssueController(IssueReponsetory issueReponsetory)
    {
      Issuerp = issueReponsetory;
    }
    // GET: api/<controller>
    [HttpGet]
    public string Get()
    {
      var item = Issuerp.GetAll();
      string toJson = Newtonsoft.Json.JsonConvert.SerializeObject(item);
      return toJson;
    }
    public async Task<ActionResult<IEnumerable<Issue>>> GetIssue()
    {
      List<Issue> item = Issuerp.GetAll();
      return item;
    }
    // GET api/<controller>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      var item = Issuerp.GetById(id);
      return item.ToString();
    }

    // POST api/<controller>
    [HttpPost]
    public void Post([FromBody]string value)
    {

    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
