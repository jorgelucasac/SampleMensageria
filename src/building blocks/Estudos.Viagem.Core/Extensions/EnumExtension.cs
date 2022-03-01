using System.ComponentModel;
using System.Reflection;

namespace Estudos.Viagem.Core.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo is not null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return enumerationValue.ToString();
        }
    }
}