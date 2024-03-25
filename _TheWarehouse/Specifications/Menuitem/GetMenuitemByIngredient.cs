namespace TheWarehouse.Specifications.Menuitem
{
    public class GetMenuitemByIngredient : Specification<Models.Menuitem>
    {
        public GetMenuitemByIngredient(int ingredientId)
        {
            _ = Query.Where(m => m.Ingredients.Any(i => i.IngredientId == ingredientId));
        }
    }
}
