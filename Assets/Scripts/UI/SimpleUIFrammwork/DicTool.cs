namespace UI
{
    using System.Collections.Generic;

    public static class DicTool
    {
        public static Tvalue GetValue<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
        {
            Tvalue value = default(Tvalue);
            dict.TryGetValue(key, out value);
            return value;
        }
    }

}