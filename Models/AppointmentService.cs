using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models;

public class AppointmentService
{
  public int Id { get; set; }
  public int AppointmentId { get; set; }
  public int ServiceId { get; set; }
}