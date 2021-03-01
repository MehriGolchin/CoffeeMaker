using System;
using System.Threading.Tasks;

namespace CafeeMaker.Infrastructure {

    public class DummyCoffeeMachine : ICoffeeMachine {

        public async Task MakeDrink(DrinkRequest request) {
            Console.WriteLine("Making drink...");
            await Task.Delay(3000);
            Console.WriteLine("Enjoy :)");
        }

    }

}