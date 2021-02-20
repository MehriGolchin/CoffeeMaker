namespace CafeeMaker.Domain.Entities {

    public class Ingredient {

        private Ingredient() {
        }
        
        public Ingredient(int id, string name) {
            Id = id;
            Name = name;
        }
        
        public int Id { get; }
        public string Name { get; }

    }

}