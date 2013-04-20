using System;

namespace DIBS.Client
{
    public class IgnoreHashingAttribute : Attribute
    {
        public IgnoreHashingAttribute(string value)
        {
            ValueIsSet = true;
            ExceptWhenValueIs = value;
        }

        public IgnoreHashingAttribute()
        {
        }

        public string ExceptWhenValueIs { get; set; }
        public bool ValueIsSet { get; set; }
    }
}