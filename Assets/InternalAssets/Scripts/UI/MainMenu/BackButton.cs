using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    [RequireComponent(typeof(SelectableButton))]
    public class BackButton : MonoBehaviour
    {
        private Button _button;
        private void Start()
        {
            _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                _button.onClick?.Invoke();
            }
        }
    }
}