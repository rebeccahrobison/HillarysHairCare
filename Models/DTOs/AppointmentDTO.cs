using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class AppointmentDTO
{
  public int Id { get; set; }
  public int StylistId { get; set; }
  public int CustomerId { get; set; }
  public List<ServiceDTO> Services { get; set; }
  public DateTime ApptTime { get; set; }
}