using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonProfit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NonProfit.Controllers
{
  public class DonationsController : Controller
  {
    private readonly NonProfitContext _db;
    public DonationsController(NonProfitContext db)
    {
      _db = db;
    }
    public ActionResult Details( int id )
    {
      Item thisItem = _db.Donations.FirstOrDefault(donations => donations.DonationsId == id);
      return View(thisDonation);
    }
    public ActionResult Create()
    {
    ViewBag.DonorsId = new SelectList(_db.Donors, "DonorId", "Name");
    return View();
    }
    public ActionResult Edit (int id)
    {
      var thisItem = _db.Donations.FirstOrDefault(Donations => Donations.DonationId == id);
      ViewBag.CategoryId = new SelectList(_db.Donor, "DonorId", "Name");
      return View(thisDonation);
    }
    
    public ActionResult Delete(int id)
    {
      var thisItem = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      return View(thisDonation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisItem = _db.Donations.FirstOrDefault(donations => donations.DonationsId == id);
      _db.Items.Remove(thisDonation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult Edit(Donation donation)
    {
      _db.Entry(donation).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult Create(Donation donation)
    {
      _db.Items.Add(donation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Index()
    {
      List<Item> model = _db.Donation.Include(donations => donations.Donor).ToList();
      return View(model);
    }
  }
}