using UnityEngine;
using System.Collections;

public class ChatServer : MonoBehaviour {
    private string text;
    public PlayerDamage _pd;
        
    void InServer(string _text)
    {
        text = _text;
    }

    void ToClient(string _name)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++)
        {
            if (_name == "1")
            {
                player[i].SendMessage("FromServer", text);
            }
            else {
                if (player[i].name == _name)
                {
                    player[i].SendMessage("FromServer", text);
                }
            }
        }
    }
}
