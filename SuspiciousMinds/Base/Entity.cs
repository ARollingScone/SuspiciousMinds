using System;
using System.Collections.Generic;

namespace SuspiciousMinds.Base
{
    public class Entity
    {
        public Dictionary<Type, object> Components = new Dictionary<Type, object>();

        public T GetComponent<T>() where T : class
        {
            Components.TryGetValue(
                typeof(T), 
                out object result);

            return result as T;
        }
    }
}
