namespace TheWarehouse.Helpers
{
    public static class Constants
    {
        public enum SortByParameter
        {
            NameAsc = 0, NameDesc,
            LNameAsc, LNameDesc,
            CreatedAsc, CreatedDesc,
            UpdatedAsc, UpdatedDesc,
            PriceAsc, PriceDesc,
            AmountAsc, AmountDesc,
            TypeAsc, TypeDesc,
            TimeAsc, TimeDesc
        }

        public enum OderByParameter
        {
            Ascending = 0,
            Descending
        }
    }
}
