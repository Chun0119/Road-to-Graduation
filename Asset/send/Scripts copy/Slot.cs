using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory inv;

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slotID] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slotID = id;
        }
        else if (droppedItem.slotID != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotID = droppedItem.slotID;
            item.transform.SetParent(inv.slots[droppedItem.slotID].transform);
            item.transform.position = inv.slots[droppedItem.slotID].transform.position;

            droppedItem.slotID = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slotID] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
