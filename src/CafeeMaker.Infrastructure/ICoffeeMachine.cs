using System.Threading.Tasks;

namespace CafeeMaker.Infrastructure {

    public interface ICoffeeMachine {

        Task MakeDrink(DrinkRequest request);

    }

}