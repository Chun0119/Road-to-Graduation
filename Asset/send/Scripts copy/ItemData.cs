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
            this.transform.position = new Vector3(eventData.position.x / 50 - 7 - 3.2f, eventData.position.y / 50 + 0.3f - 5f, 0f);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(eventData.position);
            this.transform.position = new Vector3(eventData.position.x / 50 - 7 - 3.2f, eventData.position.y / 50 + 0.3f - 5f, 0f);
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

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = GameObject.Find("Inventory").GetComponent<Tooltip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
