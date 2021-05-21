
using System.ComponentModel.DataAnnotations;

namespace gregslist_finale.Models
{
  public class Recipe
  {
    public string Id { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public string Name { get; set; }
    public bool Spicy { get; set; }
    public string Picture { get; set; }
  }
}