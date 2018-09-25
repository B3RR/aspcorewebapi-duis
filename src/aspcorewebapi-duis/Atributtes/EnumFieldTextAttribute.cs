using System;

namespace aspcorewebapi_duis.Atributtes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumFieldTextAttribute: Attribute
    {
        private string _enumFieldText;

        public EnumFieldTextAttribute(string enumFieldText)
        {
            _enumFieldText = enumFieldText;
        }

        public string EnumFieldText
        {
            get { return _enumFieldText; }
            set { _enumFieldText = value; }
        }
    }
}