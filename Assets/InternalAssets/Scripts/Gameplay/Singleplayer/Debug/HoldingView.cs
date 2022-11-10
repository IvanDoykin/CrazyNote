using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class HoldingView : MonoBehaviour
    {
        [SerializeField] private Transform _holdingView;

        private void OnEnable()
        {
            _holdingView.transform.localScale = new Vector3(0.523f, 1f, 6.255f * Mover.Speed * InputHolder.startHoldingTime);
            _holdingView.transform.localPosition = new Vector3(0f, 0f, -_holdingView.transform.localScale.z / 2);
        }
    }
}