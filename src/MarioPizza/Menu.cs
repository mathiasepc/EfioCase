using System.Collections.Generic;

namespace MarioPizza;

public class Menu : IMenu
{
  public ICollection<IPizza> AllPizzas { get; set; }

    /// <summary>
    /// opretter en liste som skal indeholde det kunden gerne vil have
    /// </summary>
    /// <param name="mustHaveIngredients"></param>
    /// <param name="wontHaveIngredients"></param>
    /// <returns></returns>
    public ICollection<string> FindPizza(IList<string> mustHaveIngredients, IList<string> wontHaveIngredients)
    {
        //instantiere min List
        List<string> displayPizza = new();

        //går List AllPizza igennem
        foreach (var infoPizza in AllPizzas)
        {
            //hvis ingredients indeholder ham og ikke Pineapple tilføj
            if (infoPizza.Ingredients.Contains(mustHaveIngredients.FirstOrDefault()) && !infoPizza.Ingredients.Contains(wontHaveIngredients.FirstOrDefault()))
                displayPizza.Add(infoPizza.Name);
        }

        return displayPizza;
    }
}
