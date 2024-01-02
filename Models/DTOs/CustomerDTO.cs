using System.ComponentModel.DataAnnotations;

namespace HillarysHairCare.Models.DTOs;

public class CustomerDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
}