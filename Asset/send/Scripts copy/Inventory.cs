using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    ItemDatabase database;
    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject slot;
    public GameObject item;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    int slotAmount;

    // Start is called before the first frame update
    void Start()
    {
        database = GetComponent<ItemDatabase>();
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;
        slotAmount = 28;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
            //slots[i].transform.localScale = new Vector3(10, 10, 10);
        }
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(2);
        AddItem(2);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Debug.Log(data.amount);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(item);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slotID = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    //itemObj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    break;
                }
            }
        }
    }

    bool CheckIfItemIsInInventory(Item ite)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == ite.ID)
            {
                return true;
            }
        }
        return false;
    }

}
