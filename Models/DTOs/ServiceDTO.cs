using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class ServiceDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
}