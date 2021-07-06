using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace JasonStorey.UiTools
{
    public static class UiExtensions
    {
        public static T GetOrCreate<T>(this MonoBehaviour behaviour) where T : Component
        {
            var existing = behaviour.GetComponent<T>();
            if (existing != null) return existing;
            return behaviour.gameObject.AddComponent<T>();
        }

        public static void Add(this Button btn, UnityAction action) => btn.onClick.AddListener(action);
        public static void Remove(this Button btn, UnityAction action) => btn.onClick.RemoveListener(action);

        public static void Validate<T>(this T obj) where T : MonoBehaviour
        {
            var req = RequiredFields(obj);
            foreach (var rInfo in req)
            {
                var val = rInfo.GetValue(obj);
                if(val == null)
                    Debug.LogError($"Required <color=yellow>{rInfo.Name}</color> missing from {obj.name}", obj);
            }
        }

        public static T GetRandom<T>(this T[] items) => items[UnityEngine.Random.Range(0, items.Length)];
        
        static IEnumerable<FieldInfo> RequiredFields<T>(T obj) where T : MonoBehaviour =>
            obj.GetType().GetFields(
                    BindingFlags.FlattenHierarchy |
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static)
                .Where(x=>x.GetCustomAttributes().Any(y=>y is RequiredAttribute));
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredAttribute : Attribute
    {
    }
    
}