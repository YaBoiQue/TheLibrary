namespace TheWarehouse.Specifications.Ingredient
{
    public class GetIngredientsByMenuitem : Specification<Models.Ingredient>
    {
        public GetIngredientsByMenuitem(int menuitemId) 
        {
            _ = Query.Where(c => c.MenuItemId == menuitemId);
        }
    }
}
