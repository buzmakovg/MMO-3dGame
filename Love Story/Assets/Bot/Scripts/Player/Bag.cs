using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {

    public GameObject player;
    private GameObject server;
    private float heartone;
    private float hearttwo;
    private float heartthree;
    private bool bagOn;
    private int hearts = 0;
    private bool menu;
    public GUIStyle BagStyle;

    void Start () {
        menu = false;
        server = GameObject.FindGameObjectWithTag("Server");
        server.SendMessage("ToBag", player.name);
	}
	
    void ToBag1(float first)
    {
        heartone = first;
    }
    void ToBag2(float second)
    {
        hearttwo = second;
    }
    void ToBag3(float third)
    {
        heartthree = third;
    }

    void Update () {
	
	}

    void MenuOn(bool vkl)
    {
        menu = vkl;
    }
    void OnGUI()
    {
        //TODO: кнопки инвентаря и их расположение 
        if (GUI.Button(new Rect(
            Screen.width / 16*15+40,
            Screen.height / 32 * 31,
            //Screen.width / 20,
            //Screen.height / 20
            20,20
            ), "^"))
        {
            SendMessage("MenuOn", true);
        }
        if (menu)
        {
            GUI.Box(new Rect(
                Screen.width / 16 * 15-5,
                Screen.height / 32 * 31-105,
                70, 130),"");
            if (GUI.Button(new Rect(
              Screen.width / 16*15,
              Screen.height / 32 * 31-20,
              //Screen.width / 40,
              //Screen.height / 40
              40,40
              ), "3"))
            {

            }
            if (GUI.Button(new Rect(
            Screen.width / 16 * 15,
            Screen.height / 32 * 31 - 60,
            //Screen.width / 40,
            //Screen.height / 40
            40,40
            ), "2"))
            {

            }
            if (GUI.Button(new Rect(
            Screen.width / 16 * 15,
            Screen.height / 32 * 31 - 100,
            //Screen.width / 40,
            //Screen.height / 40
            40, 40
            ), "1"))
            {

            }
            if (GUI.Button(new Rect(
            Screen.width / 16 * 15+40,
            Screen.height / 32 * 31 - 100,
            //Screen.width / 40,
            //Screen.height / 40
            20, 20
            ), "X"))
            {
                SendMessage("MenuOn", false);
            }
        }
    }
}
