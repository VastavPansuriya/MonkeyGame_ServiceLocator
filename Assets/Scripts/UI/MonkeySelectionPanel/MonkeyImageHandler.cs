using PlasticGui.EventTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler 
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private LayoutElement layoutElement;

        private Vector3 startRectpos;
        private Vector3 startpos;

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            layoutElement = GetComponent<LayoutElement>();
            rectTransform = GetComponent<RectTransform>();

            monkeyImage.sprite = spriteToSet;
            startRectpos = rectTransform.position;
            startpos = transform.position;
        }

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            owner.MonkeyDroppedAt(eventData.position);
            ResetMonkeyImage();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, .6f);
        }

        private void ResetMonkeyImage()
        {
            monkeyImage.color = new Color(1, 1, 1, 1);
            rectTransform.position = startRectpos;
            transform.position = startpos;
            ResetLayoutElement();
        }

        private void ResetLayoutElement()
        {
            layoutElement.enabled = false;
            layoutElement.enabled = true;
        }
       
    }
}