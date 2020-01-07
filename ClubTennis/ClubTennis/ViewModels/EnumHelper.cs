using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.ViewModels
{
    public static class EnumHelper 
    {
        /// <summary>
        /// Permet d'obtenir la description de n'importe quel Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
