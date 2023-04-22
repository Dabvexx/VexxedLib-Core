using UnityEngine;

namespace VexxedLib.Core
{
    public class MonobehaviorSingletonPersistant<T> : MonoBehaviour
        where T : Component
    {
        #region Variables
        // Variables.
        public static T Instance { get; private set; }
        #endregion

        #region Unity Methods

        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else Destroy(gameObject);
        }

        #endregion
    }
}