
using System.ComponentModel.DataAnnotations;

namespace gregslist_finale.Models
{
  public class Account
  {
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
  }
}