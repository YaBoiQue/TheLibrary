namespace TheWarehouse.Specifications.Ingredient
{
    public class GetIngredientsBySupply : Specification<Models.Ingredient>
    {
        public GetIngredientsBySupply(int supplyId)
        {
            _ = Query.Where( i => i.SupplyId == supplyId );
        }
    }
}
