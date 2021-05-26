using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham
{

    public enum FieldType
    {
        HAND,
        INVENTORY,
        DISCARD,
        TREACHERY
    }
    public class DropPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public FieldType Type;
        public Supply _supply;
        public GameObject DiscardCard;
        private GameObject TempCardGO;
        public List<Cards> Discard = new List<Cards>();

        private void Awake()
        {
            DiscardCard = GameObject.Find("DiscardCard");
            TempCardGO = GameObject.Find("TempCardGO");
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (Type == FieldType.TREACHERY) return;
            Card _card = eventData.pointerDrag.GetComponent<Card>();

            if (_card && Type == FieldType.INVENTORY && _card.GetComponent<CardInfo>().SelfCard.Cost <= _supply.SupplyNow)
            {
                _card.DefaultParent = transform;
                _supply.ReduceSupply(_card.GetComponent<CardInfo>().SelfCard.Cost);
            }

            if (_card && Type == FieldType.DISCARD)
            {
                var AllCardsNumber = _card.GetComponent<CardInfo>().SelfCard.Id - 1;
                Discard.Add(CardRenderer.AllCards[AllCardsNumber]);
                print("Карта " + _card.GetComponent<CardInfo>().SelfCard.Id + " добавлена");
                DiscardCard.GetComponent<Image>().sprite = _card.GetComponent<CardInfo>().SelfCard.Logo;
                TempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
                TempCardGO.transform.localPosition = new Vector3(-1440, 195);
                Destroy(_card.gameObject);
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null || Type == FieldType.TREACHERY) return;
            Card _card = eventData.pointerDrag.GetComponent<Card>();
            if (_card) _card.DefaultTempCardParent = transform;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;
            Card _card = eventData.pointerDrag.GetComponent<Card>();
            if (_card && _card.DefaultTempCardParent == transform) _card.DefaultTempCardParent = _card.DefaultParent;
        }
    }
}