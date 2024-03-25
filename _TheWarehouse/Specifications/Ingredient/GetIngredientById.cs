namespace TheWarehouse.Specifications.Ingredient
{
    public class GetIngredientById : Specification<Models.Ingredient>
    {
        public GetIngredientById(int ingredientId)
        {
            _ = Query.Where(c => c.IngredientId == ingredientId);
        }
    }
}
