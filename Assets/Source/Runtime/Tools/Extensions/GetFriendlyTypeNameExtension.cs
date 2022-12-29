using System;

namespace SwampAttack.Runtime.Tools.Extensions
{
    public static class GetFriendlyTypeNameExtension
    {
        public static string GetFriendlyName(this Type type)
        {
            var friendlyName = type.Name;
            if (!type.IsGenericType)
                return friendlyName;

            var backtickIndex = friendlyName.IndexOf('`');
            if (backtickIndex > 0)
                friendlyName = friendlyName.Remove(backtickIndex);

            friendlyName += "(";
            var typeParameters = type.GetGenericArguments();

            for (var i = 0; i < typeParameters.Length; ++i)
            {
                var typeParamName = GetFriendlyName(typeParameters[i]);
                friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
            }

            friendlyName += ")";
            return friendlyName;
        }
    }
}