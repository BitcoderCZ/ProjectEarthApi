﻿using System;
using System.ComponentModel;
using System.Globalization;
using Uma.Uuid;

namespace ProjectEarthServerAPI.Util
{
    // TypeConverter from string to Uuid, useful for directly storing uuids instead of strings
    public class StringToUuidConv : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string str)
            {
                return new Uuid(str);
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Uuid uuid)
            {
                return uuid.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}