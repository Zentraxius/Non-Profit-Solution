using System.Collections.Generic;

namespace NonProfit.Models
{
  public class Donor 
  {
    public Donor()
    {
      this.Donations = new HashSet<Donation>();
    }
    public int DonorId { get; set;}
    public string Name { get; set;}
    public virtual ICollection<Donation> Donations {get;set;}
  }
}