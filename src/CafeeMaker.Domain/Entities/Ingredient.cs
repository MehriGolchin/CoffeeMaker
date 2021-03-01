using System.Collections;
using System.Collections.Generic;

namespace CafeeMaker.Domain.Entities {

    public class Ingredient {

        private Ingredient() {
        }
        
        public Ingredient(int ingredientId, string name) {
            IngredientId = ingredientId;
            Name = name;
        }
        
        public int IngredientId { get; }
        public string Name { get; }

    }

}