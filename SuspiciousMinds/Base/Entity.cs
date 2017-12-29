using System;
using System.Collections.Generic;

namespace SuspiciousMinds.Base
{
    public class Entity
    {
        public Dictionary<Type, List<object>> Components { get; set; } = new Dictionary<Type, List<object>>();

        public void AddComponent<T>(T component)
        {
            var list = Components.ContainsKey(typeof(T)) 
                ? Components[typeof(T)] ?? new List<object>() 
                : new List<object>();

            list.Add(component);
            Components[typeof(T)] = list;
        }

        public List<T> GetComponents<T>() where T : class
        {
            var type = typeof(T);
            var result = new List<T>();

            if (Components.ContainsKey(type))
                Components[type].ForEach(x => result.Add(x as T));

            return result;
        }
    }
}
