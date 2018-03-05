using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      List<Stylist> allStylist = Stylist.GetAll();
      return View("Index", allStylist);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateStylistForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult CreateStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["name"]);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Detail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> allClients = selectedStylist.GetClients();
      model.Add("stylist", selectedStylist);
      model.Add("clients", allClients);
      return View(model);
    }

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult CreateClient(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist foundStylist = Stylist.Find(id);
        List<Client> stylistClients = foundStylist.GetClients();
        Client newClient = new Client(Request.Form["new-client"]);
        newClient.SetStylistId(foundStylist.GetId());
        stylistClients.Add(newClient);
        newClient.Save();
        model.Add("clients", stylistClients);
        model.Add("stylist", foundStylist);
        return View("Detail", model);
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult DeleteStylist(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/{id}/clients/sort")]
    public ActionResult Sort(int id)
    {
      Stylist sortCat = Stylist.Find(id);
      List<Client> sortedClients = new List<Client>{};
      if(Request.Form["selection"].Equals("ASC"))
      {
        sortedClients = sortCat.Sort("ASC");
      }
      else if(Request.Form["selection"].Equals("DESC"))
      {
        sortedClients = sortCat.Sort("DESC");
      }
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("stylist", sortCat);
      model.Add("clients", sortedClients);
      return View("Detail", model);

    }
  }
}
