using UnityEngine;

namespace InternalAssets.Scripts
{
    public abstract class GameInput : MonoBehaviour
    {
        public abstract RawInput GetRawInput();
        public abstract ServiceInput GetServiceInput();
    }
}