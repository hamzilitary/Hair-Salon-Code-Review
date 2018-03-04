using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/stylists/{categoryID}/clients/new")]
    public ActionResult CreateClientForm(int categoryId)
    {
      Stylist foundStylist = Stylist.Find(categoryId);
      return View(foundStylist);
    }

    //not used
    [HttpGet("/clients/{id}")]
    public ActionResult Detail(int id)
    {
      Client item = Client.Find(id);
      return View(item);
    }

    [HttpGet("/clients/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Client thisClient = Client.Find(id);
      return View(thisClient);
    }

    [HttpPost("/clients/{id}/update")]
    public ActionResult UpdateClient(int id)
    {
      Client thisClient = Client.Find(id);
      thisClient.Edit(Request.Form["newname"]);
      return RedirectToAction("Detail", "stylists", new {Id = thisClient.GetStylistId()});
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult DeleteForm(int id)
    {
      Client thisClient = Client.Find(id);
      thisClient.Delete();
      return RedirectToAction("Detail", "stylists", new {Id = thisClient.GetStylistId()});
    }


  }
}
