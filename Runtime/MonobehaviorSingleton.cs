using UnityEngine;

namespace VexxedLib.Core
{
    public class MonobehaviorSingleton<T> : MonoBehaviour
        where T : Component
    {
        #region Variables

        // Variables.
        public static T Instance { get; private set; }

        #endregion Variables

        #region Unity Methods

        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else Destroy(gameObject);
        }

        #endregion Unity Methods
    }
}