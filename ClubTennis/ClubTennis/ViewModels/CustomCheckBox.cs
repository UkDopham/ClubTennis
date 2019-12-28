using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClubTennis.ViewModels
{
    public class CustomCheckBox<T> : CheckBox
    {
        private T _value;

        public T Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public CustomCheckBox(T value)
        {
            this._value = value;
        }
    }
}
