using System;
using Singleton;
using TMPro;
using UnityEngine;

namespace Observer
{
    public class UiManager : Observer
    {
        [SerializeField] public TMP_Text totalChickenText;
        [SerializeField] public TMP_Text totalProfitText;

        private void Update()
        {
            totalProfitText.text = "Total Profit: " + GameManager.Instance.totalProfit;
        }

        public override void Notify(Subject subject)
        {
            totalChickenText.text = "Total Chickens: " + GameManager.Instance.totalChickens;
        }
    }
}
