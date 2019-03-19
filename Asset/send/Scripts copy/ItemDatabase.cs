using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();

    void Start()
    {
        ConstructItemDatabase();
        Debug.Log(FetchItemByID(0).Title);
    }

    void ConstructItemDatabase()
    {
        database.Add(new Item(0, "Ramen", 0, 0, 100, 50, 50, "ramen", true));
        database.Add(new Item(1, "Red Potion", 0, 0, 200, 0, 0, "red_potion", true));
        database.Add(new Item(2, "Blue Potion", 0, 0, 0, 200, 0, "blue_potion", true));
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

}

public class Item
{
    public int ID;
    public string Title;
    public int Power;
    public int Defence;
    public int HP;
    public int MP;
    public int EXP;
    public string Slug;
    public bool Stackable;
    public Sprite Sprite;

    public Item(int id, string title, int power, int defence, int hp, int mp, int exp, string slug, bool stackable)
    {
        this.ID = id;
        this.Title = title;
        this.Power = power;
        this.Defence = defence;
        this.HP = hp;
        this.MP = mp;
        this.EXP = exp;
        this.Slug = slug;
        this.Stackable = stackable;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}