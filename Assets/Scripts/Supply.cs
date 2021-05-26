using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham
{
    public class Supply : MonoBehaviour
    {
        public int SupplyNow;

        public void Start()
        {
            ShowSupply();
        }

        public void TakeSupply()
        {
            Text CurrentSupply = GetComponentInChildren<Text>();
            int.TryParse(CurrentSupply.text, out SupplyNow);
            SupplyNow++;
            ShowSupply();
        }
        public void ReduceSupply(int cost)
        {
            SupplyNow -= cost;
            ShowSupply();
        }

        public void ShowSupply()
        {
            Text CurrentSupply = GetComponentInChildren<Text>();
            CurrentSupply.text = SupplyNow.ToString();
        }
    }
}