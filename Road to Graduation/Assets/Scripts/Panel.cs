using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Panel : MonoBehaviour {

    GameObject canvas, panel, panelObj;

    void Start ()
    {
        canvas = GameObject.Find("On Screen");
        panel = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Expand Panel.prefab", typeof(GameObject));
    }

    public void expandPanel()
    {
        if (!GameObject.Find("/On Screen/Expand Panel"))
        {
            panelObj = Instantiate(panel, gameObject.transform.position, Quaternion.identity);
            panelObj.name = "Expand Panel";
            panelObj.transform.SetParent(canvas.transform);
        }
    }

    public void closePanel()
    {
        panelObj = GameObject.Find("/On Screen/Expand Panel");
        Destroy(panelObj);
    }

    public void openBag()
    {
        Debug.Log("openBag");
        //TODO openBag
    }

    public void closeBag()
    {
        Debug.Log("closeBag");
        //TODO closeBag
    }

    public void openEquipment()
    {
        Debug.Log("openEquipment");
        //TODO openEquipment
    }

    public void closeEquipment()
    {
        Debug.Log("closeEquipment");
        //TODO closeEquipment
    }

    public void openSkill()
    {
        Debug.Log("openSkill");
        //TODO openSkill
    }

    public void closeSkill()
    {
        Debug.Log("closeSkill");
        //TODO closeSkill
    }

    public void openAbility()
    {
        Debug.Log("openAbility");
        //TODO openAbility
    }

    public void closeAbility()
    {
        Debug.Log("closeAbility");
        //TODO closeAbility
    }

    public void exitGame()
    {
        Debug.Log("exitGame");
        //TODO exitGame
    }
}
