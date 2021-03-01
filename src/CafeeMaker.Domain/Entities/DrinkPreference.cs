using System.Collections.Generic;

namespace CafeeMaker.Domain.Entities {

    public class DrinkPreference {

        public DrinkPreference(IEnumerable<IngredientAmount> amounts, Mug mug) {
            Amounts = amounts;
            Mug = mug;
        }

        public IEnumerable<IngredientAmount> Amounts { get; }
        public Mug Mug { get; }

    }

}