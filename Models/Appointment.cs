using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models;

public class Appointment
{
  public int Id { get; set; }
  public int StylistId { get; set; }
  public int CustomerId { get; set; }
  public List<Service> Services { get; set; }
  public DateTime ApptTime { get; set; }
}