using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class OrderDetailsUpdateDTO
{
    [Required]
    public int OrderDetailId { get; set; }
    [Required]
    [Range(1,5)]
    public int Rating { get; set; }
}
