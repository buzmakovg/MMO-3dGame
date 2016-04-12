using UnityEngine;
using System.Collections;

public class Choose : MonoBehaviour
{
    private ReSpawn _rs;
    public GUIStyle styleChoose;
    public GameObject[] playerType;
    private string[] playerTypeName = { "Player 1", "Player 2", "Player 3", "Back" };
    private int TypesName;
    private int Parts;

    void Start()
    {
        TypesName = playerTypeName.Length;
        Parts = ((TypesName + 1) * 3);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Label(new Rect(
            Screen.width / 4,
            Screen.height / Parts,
            Screen.width / 2,
            Screen.height * 2 / Parts),
            "Choose to Player", styleChoose);

        for (int i = 0; i < TypesName; i++) {
            if (GUI.Button(new Rect(
                Screen.width / 4,
                Screen.height * (i + 1) * 3 / Parts,
                Screen.width / 2,
                Screen.height * 2 / Parts),
                playerTypeName[i]))
            {
                if (i == 3)
                {
                    Application.LoadLevel(0);

                }
                else ChoosePlayer(i);
            }
    }
   } 
    private void ChoosePlayer(int i)
    {
        //_rs.player = playerType;
        Application.LoadLevel(2);
        _rs.player = playerType[i];
    }

}