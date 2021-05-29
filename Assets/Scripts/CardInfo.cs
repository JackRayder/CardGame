using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Dynamic;

namespace Arkham
{
    public class CardInfo : MonoBehaviour
    {
        public Cards SelfCard;
        public ScriptableObject AllInfo;
        public Image Logo;
        public Sprite Img;
        public Sprite AnotherSideImg;
        public string Type;
        public int Cost;
        public int StrengthIcon;
        public int AgilityIcon;
        public int WillIcon;
        public int KnowledgeIcon;
        public int UltimateIcon;
        public string Tag1;
        public string Tag2;
        public string Tag3;
        public string Tag4;
        public int Healht;
        public int Sanity;
        public int Clues;
        public int Shroud;
        public int Damage;
        public int SanityDmg;
        public int Strength;
        public int Agility;
        public int Resourse;


        public void ShowCardInfo(Cards card)
        {
            SelfCard = card;
            AllInfo = card.AllInfo;
            Img = card.AllInfo.Img;
            AnotherSideImg = card.AllInfo.AnotherSideImg;
            Type = card.AllInfo.Type;
            Cost = card.AllInfo.Cost;
            StrengthIcon = card.AllInfo.StrengthIcon;
            AgilityIcon = card.AllInfo.AgilityIcon;
            WillIcon = card.AllInfo.WillIcon;
            KnowledgeIcon = card.AllInfo.KnowledgeIcon;
            UltimateIcon = card.AllInfo.UltimateIcon;
            Tag1 = card.AllInfo.Tag1;
            Tag2 = card.AllInfo.Tag2;
            Tag3 = card.AllInfo.Tag3;
            Tag4 = card.AllInfo.Tag4;
            Healht = card.AllInfo.Healht;
            Sanity = card.AllInfo.Sanity;
            Clues = card.AllInfo.Clues;
            Shroud = card.AllInfo.Shroud;
            Damage = card.AllInfo.Damage;
            SanityDmg = card.AllInfo.SanityDmg;
            Strength = card.AllInfo.Strength;
            Agility = card.AllInfo.Agility;
            Resourse = card.AllInfo.Resourse;
            Logo.sprite = Img;
        }
    }
}