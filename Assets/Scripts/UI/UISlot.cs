using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        if(GetComponentInChildren<UIItems>()!=null)
        {
            var thisItemTransform = GetComponentInChildren<UIItems>().transform;
            if(thisItemTransform.GetComponent<UIItems>().name== otherItemTransform.GetComponent<UIItems>().name && (otherItemTransform.GetComponent<UIItems>().quantity + thisItemTransform.GetComponent<UIItems>().quantity) <= thisItemTransform.GetComponent<UIItems>().stack)
            {
                otherItemTransform.GetComponent<UIItems>().quantity += thisItemTransform.GetComponent<UIItems>().quantity;
                if(otherItemTransform.GetComponent<UIItems>().quantity-thisItemTransform.GetComponent<UIItems>().quantity==1)
                {
                    otherItemTransform.transform.Find("Text").gameObject.SetActive(true);
                }
                otherItemTransform.transform.Find("Text").GetComponent<Text>().text= otherItemTransform.GetComponent<UIItems>().quantity.ToString();
                Destroy(thisItemTransform.gameObject);
            }
            else
            {
                thisItemTransform.SetParent(otherItemTransform.GetComponentInParent<UISlot>().transform);
                thisItemTransform.localPosition = Vector3.zero;
            }
            
            
        }
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
    //public void AddItem(Item item)
    //{
    //    GameObject.Instantiate(item);
    //}
    public void Update_quantity(int i)
    {

    }

}
