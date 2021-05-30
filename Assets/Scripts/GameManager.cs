using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Arkham
{
    public class Game
    {
        public List<Cards> TreacheryDeck, PlayerDeck, PlayerHand, Inventory, Discard;

        public Game()
        {
            PlayerDeck = GiveDeckCard();
            TreacheryDeck = TreacheryDeckCard();

            PlayerHand = new List<Cards>();
            Inventory = new List<Cards>();

        }

        List<Cards> GiveDeckCard()
        {
            List<Cards> list = new List<Cards>();
            list.Add(CardRenderer.AllCards[20]);
            list.Add(CardRenderer.AllCards[88]);
            list.Add(CardRenderer.AllCards[31]);
            list.Add(CardRenderer.AllCards[37]);
            list.Add(CardRenderer.AllCards[25]);
            list.Add(CardRenderer.AllCards[88]);
            list.Add(CardRenderer.AllCards[87]);
            list.Add(CardRenderer.AllCards[36]);
            list.Add(CardRenderer.AllCards[92]);
            list.Add(CardRenderer.AllCards[89]);
            list.Add(CardRenderer.AllCards[24]);
            list.Add(CardRenderer.AllCards[6]);
            list.Add(CardRenderer.AllCards[16]);
            list.Add(CardRenderer.AllCards[18]);
            list.Add(CardRenderer.AllCards[39]);
            list.Add(CardRenderer.AllCards[89]);
            list.Add(CardRenderer.AllCards[87]);
            list.Add(CardRenderer.AllCards[35]);
            list.Add(CardRenderer.AllCards[21]);
            list.Add(CardRenderer.AllCards[34]);
            list.Add(CardRenderer.AllCards[38]);
            list.Add(CardRenderer.AllCards[7]);
            list.Add(CardRenderer.AllCards[30]);
            list.Add(CardRenderer.AllCards[22]);
            list.Add(CardRenderer.AllCards[19]);
            list.Add(CardRenderer.AllCards[32]);
            list.Add(CardRenderer.AllCards[23]);
            list.Add(CardRenderer.AllCards[92]);
            list.Add(CardRenderer.AllCards[86]);
            list.Add(CardRenderer.AllCards[86]);
            list.Add(CardRenderer.AllCards[33]);
            list.Add(CardRenderer.AllCards[17]);
            return list;
        }
        List<Cards> TreacheryDeckCard()
        {
            List<Cards> list = new List<Cards>();
            list.Add(CardRenderer.AllCards[29]);
            list.Add(CardRenderer.AllCards[30]);
            list.Add(CardRenderer.AllCards[31]);
            list.Add(CardRenderer.AllCards[32]);
            list.Add(CardRenderer.AllCards[33]);
            list.Add(CardRenderer.AllCards[34]);
            list.Add(CardRenderer.AllCards[35]);
            list.Add(CardRenderer.AllCards[36]);
            list.Add(CardRenderer.AllCards[37]);
            list.Add(CardRenderer.AllCards[38]);
            list.Add(CardRenderer.AllCards[39]);
            list.Add(CardRenderer.AllCards[40]);
            return list;
        }
    }
    public class GameManager : MonoBehaviour
    {
        public Game CurrentGame;
        public Transform PlayerField;
        public Transform PlayerDeck;
        public Transform TreacheryDeck;
        public Transform TreacheryField;
        public DropPlace _dropplace;
        public GameObject CardPref;
        public Supply _supply;

        private void Start()
        {
            CurrentGame = new Game();
            GiveHandCards(CurrentGame.PlayerDeck, PlayerDeck, PlayerField);
        }

        public void EndTurn()
        {
            GiveCardToHand(CurrentGame.TreacheryDeck, TreacheryDeck, TreacheryField);
        }

        public void DrawCard()
        {
            GiveCardToHand(CurrentGame.PlayerDeck, PlayerDeck, PlayerField);
        }

        private void GiveHandCards(List<Cards> deck, Transform spawn, Transform field)
        {
            int i = 0;
            while (i++ < 5) GiveCardToHand(deck, spawn, field);
        }

        private void GiveCardToHand(List<Cards> deck, Transform spawn, Transform field)
        {
            if (deck.Count == 0) {
                deck = _dropplace.Discard;
                print("Колода перемешана");
                if (_dropplace.Discard.Count == 0) return;
            }
            int randomcard = Random.Range(0, deck.Count);
            Cards card = deck[randomcard];

            GameObject cardGo = Instantiate(CardPref, spawn, false);
            cardGo.GetComponent<CardInfo>().ShowCardInfo(card);
            cardGo.GetComponent<Card>().MoveToField(field);
            cardGo.transform.SetParent(field);
            

            deck.RemoveAt(randomcard);
        }
    }
}