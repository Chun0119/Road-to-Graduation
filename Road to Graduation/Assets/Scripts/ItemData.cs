using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int amount;
    public int slotID;

    private Inventory inv;
    private Tooltip tooltip;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = new Vector3(eventData.position.x / 27.5f - 8.8f, eventData.position.y / 27.5f -5.1f, 0f);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(eventData.position);
            this.transform.position = new Vector3(eventData.position.x / 27.5f - 8.8f, eventData.position.y / 27.5f -5.1f, 0f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (slotID != -1)
        {
            this.transform.SetParent(inv.slots[slotID].transform);
            this.transform.position = inv.slots[slotID].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    void Start()
    {
        inv = GameObject.Find("Inventory System").GetComponent<Inventory>();
        tooltip = GameObject.Find("Inventory System").GetComponent<Tooltip>();
    }
}
