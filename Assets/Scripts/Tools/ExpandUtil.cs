using System;
using UI;

namespace Tools
{
    public static class ExpandUtil
    {
          public static string  EnumToString(this UIPanelType type)
            {
                return Enum.GetName(typeof(UIPanelType),type);
            }
    }
}