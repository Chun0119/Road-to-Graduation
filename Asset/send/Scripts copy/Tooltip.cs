using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Item item;
    private string data;
    private GameObject tooltip;

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = item.Title;
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    // Start is called before the first frame update
    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = new Vector3(Input.mousePosition.x / 50 - 7 - 3.2f, Input.mousePosition.y / 50 + 0.3f - 5f, 0f);
        }
    }
}
