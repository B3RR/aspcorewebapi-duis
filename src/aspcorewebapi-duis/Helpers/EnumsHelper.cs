using System.Linq;
using aspcorewebapi_duis.Atributtes;

namespace aspcorewebapi_duis.Helpers
{
    public class EnumsHelper
    {
        public static string GetEnumFieldText(object type)
        {
            foreach (var info in type.GetType().GetFields())
            {
                if (type.ToString() == info.Name)
                {
                    foreach (var attribute in info.GetCustomAttributes(true).Where(x => x.GetType() == typeof(EnumFieldTextAttribute)))
                    {
                        if (attribute != null)
                        {
                            return ((EnumFieldTextAttribute)attribute).EnumFieldText;
                        }
                    }
                }
            }
            return "";
        }


    }
}