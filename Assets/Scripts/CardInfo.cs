using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Arkham
{
    public class CardInfo : MonoBehaviour
    {
        public Cards SelfCard;
        public Image Logo;
        public int Id, Cost;


        public void ShowCardInfo(Cards card)
        {
            SelfCard = card;
            Logo.sprite = card.Logo;
            Id = card.Id;
            Cost = card.Cost;
            Logo.preserveAspect = true;
        }
    }
}