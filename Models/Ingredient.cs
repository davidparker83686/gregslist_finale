
using System.ComponentModel.DataAnnotations;

namespace gregslist_finale.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    [Required]
    public int RecipeId { get; set; }
    [Required]
    public string Name { get; set; }
    public string FoodGroup { get; set; }
    public string Picture { get; set; }
  }
}