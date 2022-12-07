using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GuitarAnimator : MonoBehaviour
    {
        private float movementSpeed = 0.45f * GriefSettings.Speed;
        private const string textureProperty = "_MainTex";

        [SerializeField] private Renderer _renderer;
        private bool _active = true;

        private void Start()
        {
            _renderer.material.SetTextureOffset(textureProperty, new Vector2(0f, -0.5f));
        }

        public void SetActive()
        {
            _active = true;
        }

        public void SetInactive()
        {
            _active = false;
        }

        private void Update()
        {
            if (_active)
            {
                _renderer.material.SetTextureOffset(textureProperty, _renderer.material.GetTextureOffset(textureProperty) + new Vector2(0f, movementSpeed * Time.deltaTime));
            }
        }
    }
}