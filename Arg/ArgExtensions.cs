using System;
using System.Collections.Generic;
using System.Linq;

namespace Arg
{
    public static class ArgExtensions
    {
        public static IArgument GetArgument(this List<IArgument> list, string id)
        {
            return list.Find(f => f.Name.Equals(id, StringComparison.OrdinalIgnoreCase) || f.Identifiers.Contains(id, StringComparer.OrdinalIgnoreCase));
        }

        public static string GetValue(this List<IArgument> list, string id)
        {
            return list.GetValue<string>(id);
        }

        public static T GetValue<T>(this List<IArgument> list, string id)
        {
            var found = list.GetArgument(id);

            if (found != null)
            {
                return (T)Convert.ChangeType(found.Value, typeof(T));
            }

            throw new KeyNotFoundException($"Value with id {id} does not exist!");
        }

        public static T GetValueOrDefault<T>(this List<IArgument> list, string id, T defaultValue)
        {
            var found = list.GetArgument(id);

            if (found != null)
            {
                return (T)Convert.ChangeType(found.Value, typeof(T));
            }

            return defaultValue;
        }

        public static bool HasValue(this List<IArgument> list, string id)
        {
            return list.GetArgument(id) != null;
        }
    }
}