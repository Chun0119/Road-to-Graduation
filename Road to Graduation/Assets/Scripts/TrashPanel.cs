using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashPanel : MonoBehaviour, IDropHandler
{
    private Inventory inv;

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        inv.items[droppedItem.slotID] = new Item();

        droppedItem.slotID = -1;
    }

    void Start()
    {
        inv = GameObject.Find("Inventory System").GetComponent<Inventory>();
    }

    void Update()
    {
        
    }
}
