using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Migrap.AspNet.Multitenant {
    public static class DictionaryExtensions {
        internal static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}