using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class DifficultyMenu : MonoBehaviour
    {
        [SerializeField] private OneSideStretcher _background;

        public void Open()
        {
            gameObject.SetActive(true);
            _background.Stretch();
        }
    }
}