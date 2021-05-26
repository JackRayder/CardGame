using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Arkham
{
    public struct Cards
    {
        public enum CardType
        {
            Location,
            TreacheryEvent,
            Enemy,
            Agenda,
            Act,
            Detective,
            Asset,
            Event,
            Skill
        }
        public int Id;
        public Sprite Logo;
        public int Cost;

        public Cards(int id, string logoPath, int cost)
        {
            Id = id;
            Logo = Resources.Load<Sprite>(logoPath);
            Cost = cost;

        }
    }

    public static class CardRenderer
    {
        public static List<Cards> AllCards = new List<Cards>();
    }

    public class CardManager : MonoBehaviour
    {
        public void Awake()
        {
            for (int i = 1; i < 183; i++)
                CardRenderer.AllCards.Add(new Cards(i, "CardImg/"+ i, 3));
        }
    }
}