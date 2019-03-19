using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    GameObject dialogue, dialogueObj, textObj, nameObj, personObj, backgroundObj;
    public string[] name;
    public string[] text;
    public string[] person;
    int currentIndex;

    void Start()
    {
        dialogue = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Dialogue.prefab", typeof(GameObject));
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" && !GameObject.Find("/Dialogue"))
        {
            Debug.Log("dialogue");
            GameObject.Find("Inventory System").GetComponent<Inventory>().AddItem(1);
            GameObject.Find("Inventory System").GetComponent<Inventory>().AddItem(2);
            dialogueObj = Instantiate(dialogue, transform.position, Quaternion.identity);
            dialogueObj.name = "Dialogue";
            backgroundObj = GameObject.Find("/Dialogue/Background");
            backgroundObj.GetComponent<Image>().sprite = GameObject.Find("/Background").GetComponent<SpriteRenderer>().sprite;
            currentIndex = 0;
            updateDialogue(currentIndex);
        };
    }

    void Update()
    {
        if (GameObject.Find("/Dialogue"))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                backward();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                forward();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                closeDialogue();
            }
        }
    }

    public void forward()
    {
        if (currentIndex < text.Length - 1)
        {
            currentIndex++;
            updateDialogue(currentIndex);
        }
        else
        {
            closeDialogue();
        }
    }

    public void backward()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            updateDialogue(currentIndex);
        }
    }

    private void updateDialogue(int index)
    {
        textObj = GameObject.Find("/Dialogue/Dialogue Box/Lines");
        textObj.GetComponent<Text>().text = text[index];
        nameObj = GameObject.Find("/Dialogue/Name Box/Name");
        nameObj.GetComponent<Text>().text = name[index];
        personObj = GameObject.Find("/Dialogue/Character");
        personObj.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Assets/Dialogue/Character/Engine.png", typeof(Sprite));
    }

    public void closeDialogue()
    {
        dialogueObj = GameObject.Find("/Dialogue");
        Destroy(dialogueObj);
    }
}
