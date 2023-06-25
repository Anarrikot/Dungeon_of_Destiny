using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var otherItemTransformInfo = otherItemTransform.GetComponent<UIItems>();
        if (GetComponentInChildren<UIItems>()!=null)
        {
            var thisItemTransform = GetComponentInChildren<UIItems>().transform;
            var thisItemTransformInfo = thisItemTransform.GetComponent<UIItems>();
            if (thisItemTransformInfo.name== otherItemTransformInfo.name && (otherItemTransformInfo.quantity + thisItemTransformInfo.quantity) <= thisItemTransform.GetComponent<UIItems>().stack)
            {
                otherItemTransformInfo.quantity += thisItemTransformInfo.quantity;
                if(otherItemTransformInfo.quantity- thisItemTransformInfo.quantity==1)
                {
                    otherItemTransform.transform.Find("Text").gameObject.SetActive(true);
                }
                otherItemTransform.transform.Find("Text").GetComponent<Text>().text= otherItemTransformInfo.quantity.ToString();
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
}
