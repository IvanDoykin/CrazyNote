using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class MultiplayerBox : MonoBehaviour
    {
        [SerializeField] private Image _boxView;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private List<Sprite> _bonusSprites; 

        public void SetMultiplayer(int multiplayer, bool isBonus)
        {
            if (isBonus)
            {
                _boxView.sprite = _bonusSprites[(int)Mathf.Log(multiplayer, 2)];
            }
            else
            {
                _boxView.sprite = _sprites[multiplayer - 1];
            }
        }
    }
}