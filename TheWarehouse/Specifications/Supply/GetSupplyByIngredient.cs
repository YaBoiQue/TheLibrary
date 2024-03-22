namespace TheWarehouse.Specifications.Supply
{
    public class GetSupplyByIngredient : Specification<Models.Supply>
    {
        public GetSupplyByIngredient(int ingredientId)
        {
            _ = Query.Where(s => s.Ingredients.Any(i => i.IngredientId == ingredientId));
        }
    }
}
