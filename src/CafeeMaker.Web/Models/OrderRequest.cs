using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CafeeMaker.Domain.Entities;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Web.Models {

    public class OrderRequest {

        [Required]
        public int DrinkId { get; set; }
        [Required]
        public IEnumerable<IngredientAmountEntry> Amounts { get; set; }
        [Required]
        public Mug Mug { get; set; }

        public int GetIngredientAmountOrDefault(int drinkIngredientId, int defaultAmount) {
            var entry = Amounts.FirstOrDefault(i => i.DrinkIngredientId == drinkIngredientId);
            return entry?.Amount ?? defaultAmount;
        }

    }

}