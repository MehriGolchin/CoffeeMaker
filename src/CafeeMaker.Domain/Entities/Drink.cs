using System.Collections.Generic;

namespace CafeeMaker.Domain.Entities {

    public class Drink {

        private Drink() {
        }
        
        public Drink(int id, string name, IEnumerable<DrinkIngredient> ingredients) {
            Id = id;
            Name = name;
            Ingredients = ingredients;
        }

        public int Id { get; }
        public string Name { get; }
        public IEnumerable<DrinkIngredient> Ingredients { get; }

    }

}