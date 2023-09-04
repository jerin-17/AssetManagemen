using AssetManagementAPI.MyExceptions;

namespace AssetManagementAPI.Utility
{
    public class AbbrValidator<T>
    {
        private List<T> _items;

        public AbbrValidator(List<T> items)
        {
            _items = items;
        }

        private T? GetItemByAbbr(string abbr, Func<T, string> abbrAccessor)
        {
            return _items.FirstOrDefault(item => abbrAccessor(item) == abbr);
        }

        public void ValidateAbbr(string abbreviation, Func<T, string> abbrAccessor)
        {
            if (abbreviation.Length != 3)
            {
                throw new FormatException("The abbreviation can contain only 3 letters");
            }
            if (GetItemByAbbr(abbreviation, abbrAccessor) != null)
            {
                throw new DataExistsException("Abbreviation must be unique");
            }
        }
    }

}
