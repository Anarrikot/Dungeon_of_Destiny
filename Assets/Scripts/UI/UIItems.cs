using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItems : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private CanvasGroup m_CanvasGroup;
    private Canvas MainCanvas;
    private RectTransform m_RectTransform;
    public string name;
    public int id;
    public int stack;
    public int quantity;
    void Start()
    {
        MainCanvas = GetComponentInParent<Canvas>();
        m_RectTransform = GetComponent<RectTransform>();
        m_CanvasGroup = GetComponentInParent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = m_RectTransform.parent;
        slotTransform.SetAsLastSibling();
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta/MainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        m_CanvasGroup.blocksRaycasts = true;
    }



}
