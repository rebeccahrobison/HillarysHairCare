using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class StylistDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool Active { get; set; }
  // public List<AppointmentDTO> Appointments { get; set; }
}