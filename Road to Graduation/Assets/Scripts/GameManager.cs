using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public string faculty;
    GameObject player, canvas;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("On Screen");
        /**Sprite hotkey = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Assets/UI/Ability.png", typeof(Sprite));
        GameObject.Find("On Screen/Hotkey Bar/1").GetComponent<Image>().sprite = hotkey;
        Sprite body = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Assets/Body/Stand.png", typeof(Sprite));
        GameObject bodyObj = GameObject.Find("/Player/Body");
        bodyObj.GetComponent<SpriteRenderer>().sprite = body;**/
    }

    void Update () {
		
	}
}
