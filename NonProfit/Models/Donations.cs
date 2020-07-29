using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace NonProfit.Models
{
  public class Donation
  {
    public int DonationId { get; set; }
    public int Money { get; set; }
    public int DonorId { get; set; }
    public virtual Donor Donor { get; set; }
  }
}