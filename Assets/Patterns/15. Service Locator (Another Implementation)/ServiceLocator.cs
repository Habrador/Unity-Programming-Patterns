using System.Collections.Generic;
using System.Linq;

namespace ServiceLocatorPattern
{
    public static class ServiceLocator
    {
        private static readonly HashSet<object> _registeredObjects;

        static ServiceLocator()
        {
            _registeredObjects = new HashSet<object>();
        }

        public static void Register<T>(T obj) where T : class
        {
            _registeredObjects.Add(obj);
        }

        public static void Unregister<T>(T obj) where T : class
        {
            _registeredObjects.Remove(obj);
        }

        public static T Resolve<T>() where T : class
        {
            var obj = _registeredObjects.SingleOrDefault(x => x is T);
            if (obj != null)
                return obj as T;

            return null;
        }
    }
}
