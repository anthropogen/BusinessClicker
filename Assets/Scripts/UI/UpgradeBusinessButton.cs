using Clicker.Components;
using Clicker.Events;
using TMPro;
using UnityEngine;

namespace Clicker.UI
{
    public class UpgradeBusinessButton : ECSEventButton<UpgradeBusinessEvent>
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text incomeText;
        public UpgradeType UpgradeType => _upgradeType;

        protected override void ConstructEvent(ref UpgradeBusinessEvent @event)
            => @event.UpgradeType = _upgradeType;

        public void SetPrice(int price)
            => priceText.text = $"Цена: {price}$";

        public void SetMultiplier(float multiplier)
            => incomeText.text = $"Доход: +{multiplier}%";

        public void SetPurchased()
        {
            priceText.text = $"Куплено";
            incomeText.text = "";
        }
    }
}