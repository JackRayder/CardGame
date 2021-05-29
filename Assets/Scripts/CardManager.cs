using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Arkham
{
    public struct Cards
    {
        public int Id;
        public CardSO AllInfo;

        public Cards(int id, string logoPath)
        {
            Id = id;
            AllInfo = Resources.Load<CardSO>(logoPath);

        }
    }

    public static class CardRenderer
    {
        public static Dictionary<int, Cards> AllCards = new Dictionary<int, Cards>();
    }

    public class CardManager : MonoBehaviour
    {
        public void Awake()
        {
            for (int i = 1; i < 183; i++)
                CardRenderer.AllCards.Add(i, new Cards(i, "CardsSO/20"));
        }
    }
}