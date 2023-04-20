using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Credit to MonoFlauta for many of these extensions
/// https://monoflauta.com/2021/07/27/11-useful-unity-c-extension-methods/
/// </summary>
namespace VexxLibed.Extensions
{
    public static class ExtensionMethods
    {
        #region Public Methods
        // Public Methods.

        /// <summary>
        /// Get all children attached to GameObject.
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static List<GameObject> GetAllChildren(this Transform trans)
        {
            List<GameObject> children = new List<GameObject>();

            foreach (Transform child in trans)
            {
                children.Add(child.gameObject);
            }

            return children;
        }

        public static List<T> GetAllComponentInAllChildren<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            List<T> components = new List<T>();

            foreach (var child in gameObject.transform.GetAllChildren())
            {
                if (child.HasComponent<T>())
                {
                    components.Add(child.GetComponent<T>());
                }
            }

            return components;
        }

        /// <summary>
        /// Checks if the components is attached to gameobject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            return gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// Reset the transform.
        /// </summary>
        public static void Reset(this Transform trans)
        {
            trans.position = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        /// <summary>
        /// Vibrate a game object by randomly offsetting the position by an intensity and speed
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="intensity"></param>
        /// <param name="speed"></param>
        public static void Vibrate(this Transform trans, float intensity, float speed)
        {
            trans.localPosition = intensity * new Vector3(
                Mathf.PerlinNoise(speed * Time.time, 1),
                Mathf.PerlinNoise(speed * Time.time, 2),
                Mathf.PerlinNoise(speed * Time.time, 3));
        }

        #region Vector Extensions

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }

        public static Vector3 ResetX(this Vector3 vector)
        {
            return new Vector3(0, vector.y, vector.z);
        }

        public static Vector3 ResetY(this Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }

        public static Vector3 ResetZ(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static Vector2 SetX (this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }

        public static Vector2 SetY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }

        public static Vector2 AddX(this Vector2 vector, float x)
        {
            return new Vector2(vector.x + x, vector.y);
        }

        public static Vector2 AddY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, vector.y + y);
        }

        public static Vector2 ResetX(this Vector2 vector)
        {
            return new Vector2(0, vector.y);
        }

        public static Vector2 ResetY(this Vector2 vector)
        {
            return new Vector2(vector.x, 0);
        }

        #endregion

        /// <summary>
        /// Gets the component, or adds it if it does not exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) gameObject.AddComponent<T>();
            return component;
        }

        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                var value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }

        public static List<GameObject> SortListByDistance(this IList<GameObject> list)
        {
            return null;
        }

        /// <summary>
        /// Cleans the given list of null values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private static void CleanNullFromList<T>(List<T> list)
        {
            List<T> itemsToDelete = new List<T>();

            foreach (var item in list)
            {
                if (item == null)
                {
                    itemsToDelete.Add(item);
                }
            }

            foreach (var item in itemsToDelete)
            {
                list.Remove(item);
            }
        }

        private static void RegenerateNames(this List<GameObject> list, string name)
        {
            int i = 0;

            foreach (var item in list)
            {
                i++;
                item.name = $"{name} {i}";
            }
        }

        #endregion
    }
}
