using System.Collections.Generic;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Infrastructure {

    public class DrinkRequest {
    
        public DrinkRequest(IEnumerable<Ingredient> ingredients, Mug mug) {
            Ingredients = ingredients;
            Mug = mug;
        }
        public IEnumerable<Ingredient> Ingredients { get; }
        public Mug Mug { get; }
            
        public class Ingredient {
    
            public Ingredient(string name, int amount) {
                Name = name;
                Amount = amount;
            }
    
            public string Name { get; }
            public int Amount { get; }
    
        }
    }

}