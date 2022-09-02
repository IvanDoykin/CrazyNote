using UnityEngine;

namespace InternalAssets.Scripts
{
    public class GuitarAnimator : MonoBehaviour
    {
        private const float movementSpeed = 0.45f;
        private const string textureProperty = "_MainTex";
        [SerializeField] private Renderer _renderer;

        private void Start()
        {
            _renderer.material.SetTextureOffset(textureProperty, new Vector2(0f, -0.5f));
        }

        private void Update()
        {
            _renderer.material.SetTextureOffset(textureProperty,_renderer.material.GetTextureOffset(textureProperty) + new Vector2(0f, movementSpeed * Time.deltaTime));
        }
    }
}