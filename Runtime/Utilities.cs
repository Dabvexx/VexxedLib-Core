using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VexxLib.Utils
{
    public static class Utilities
    {
        #region Variables
        // Variables.

        #endregion

        #region Public Methods
        // Public Methods.
        public static Vector3 MouseToWorldPoint2D()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
        /// <summary>
        /// Probably shoulden't use this becuase it tries to find so many things
        /// </summary>
        /// <returns></returns>
        /// 

        public static Dictionary<GameObject, float> GetObjDistances(List<GameObject> objList, Transform target)
        {
            var dict = new Dictionary<GameObject, float>();

            foreach (var item in objList)
            {
                 dict.Add(item, Vector3.Distance(target.position, item.transform.position));
            }

            return dict;
        }

        // These 2 methods are the same except one calls GetObjDistances first.
        public static Dictionary<GameObject, float> SortListByDistance(List<GameObject> objList)
        {
            // put into list as a gameobject to distance pair, the user can just save 1


            return null;
        }

        public static Dictionary<GameObject, float> SortDictByDistance(Dictionary<GameObject, float> dict)
        {
            // put into list as a gameobject to distance pair, the user can just save 1
            // dict.OrderByDecending

            return null;
        }

        public static GameObject FindClosestGameObject()
        {
            return null;
        }

        public static GameObject FindClosestGameObjectInList()
        {
            return null;
        }

        public static GameObject FindClosestGameObjectByTag()
        {
            return null;
        }

        public static GameObject FindClosestGameObjectOfType()
        {
            return null;
        }

        public static GameObject FindFurthestGameObject()
        {
            return null;
        }

        public static GameObject FindFurthestGameObjectInList()
        {
            return null;
        }

        public static GameObject FindFurthestGameObjectByTag()
        {
            return null;
        }
        #endregion
    }
}
