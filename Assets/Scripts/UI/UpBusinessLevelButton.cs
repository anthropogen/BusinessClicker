using Clicker.Events;
using UnityEngine;
using TMPro;

namespace Clicker.UI
{
    public class UpBusinessLevelButton : ECSEventButton<UpBusinessLevelEvent>
    {
        [SerializeField] private TMP_Text priceText;

        public void SetPrice(int price)
            => priceText.text = $"{price}$";
    }
}