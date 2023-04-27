using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VexxedLib.Core
{
    public class SoundManager : MonobehaviorSingleton<SoundManager>
    {
        #region Variables
        // Variables.

        #endregion

        #region Unity Methods
        private void Reset()
        {
            int numSources = GetComponents<AudioSource>().Length;
            for (int i = numSources; i < 2; i++)
            {
                gameObject.AddComponent<AudioSource>();
            }
        }
        void Start()
        {

        }

        void Update()
        {

        }

        #endregion

        #region Private Methods
        // Private Methods.

        #endregion

        #region Public Methods
        // Public Methods.

        #endregion
    }
}
