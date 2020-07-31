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
      Donation thisDonation = _db.Donations.Include(Donation => Donation.Donor).FirstOrDefault(donations => donations.DonationId == id);
      return View(thisDonation);
    }
    public ActionResult Create()
    {
    ViewBag.DonorId = new SelectList(_db.Donors, "DonorId", "Name");
    return View();
    }
    public ActionResult Edit (int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(Donations => Donations.DonationId == id);
      ViewBag.DonorId = new SelectList(_db.Donors, "DonorId", "Name");
      return View(thisDonation);
    }
    
    public ActionResult Delete(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      return View(thisDonation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      _db.Donations.Remove(thisDonation);
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
      _db.Donations.Add(donation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Index()
    {
      List<Donation> model = _db.Donations.Include(donations => donations.Donor).ToList();
      return View(model);
    }
  }
}