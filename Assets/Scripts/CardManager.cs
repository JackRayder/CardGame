using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Arkham
{
    public struct Cards
    {
        public int Id;
        public CardSO AllInfo;

        public Cards(int id, string InfoPath)
        {
            Id = id;
            AllInfo = Resources.Load<CardSO>(InfoPath);

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
            for (int i = 0; i < 182; i++)
                CardRenderer.AllCards.Add(i, new Cards(i, "CardsSO/" + i));
        }
    }
}