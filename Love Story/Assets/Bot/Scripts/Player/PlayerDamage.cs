using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public float maxHp = 100;
    public GameObject player;
    public float gold = 5;
    private float exp = 0;
    private float maxExp = 10;
    private float hp;
    private float _hp;
    private float _exp;
    private int lvl = 1;
    public string to = "";
    public string text = "";
    public GUIStyle kotikStyle;
    public GUIStyle barStyle;
    public GUIStyle expStyle;
    public GUIStyle lvlStyle;
    private string message;
    private string message1;
    private string message2;
    private string message3;
    private string message4;
    private string message5;
    private bool chat;
    private GameObject server;

    void ApplyDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(player);
    }

    void ApplyHealth(float health)
    {
        hp += health;
    }

    void GoldUp(float _gold)
    {
        gold += _gold;
    }

    void ExpUp(float _exp)
    {
        exp += _exp;
    }
    void Start()
    {
        server = GameObject.FindGameObjectWithTag("Server");
        hp = maxHp;
        player.name = "Grisha";

    }
    void Update()
    {
        if (exp >= maxExp)
        {
            exp = exp - maxExp;
            lvl++;
            player.SendMessage("PowerAttack", lvl);
            maxHp = maxHp + 10 * lvl;
            hp = maxHp;
            maxExp = maxExp + 20 * lvl;
            hp = maxHp;
        }
        _exp = exp / maxExp;
        _hp = hp / maxHp;
    }
    void FromServer(string _text) {
        message5 = message4;
        message4 = message3;
        message3 = message2;
        message2 = message1;
        message1 = message;
        message = _text;
        chat = true;

    }

    void OnGUI()
    {

        GUI.Box(new Rect(10f, 10f, 130f, 130f), "", kotikStyle);
        GUI.Box(new Rect(18f, 69f, 114f * _hp, 8f), "", barStyle);
        GUI.Box(new Rect(18f, 84f, 114f * _exp, 4f), "", expStyle);
        GUI.Label(new Rect(60f, 40f, 20f, 20f), lvl + " lvl", lvlStyle);

        to = GUI.TextField(new Rect(Screen.width / 64, Screen.height / 16 * 15, Screen.width / 64 * 3, Screen.height / 16 - 5), to);
        text = GUI.TextField(new Rect(Screen.width / 16, Screen.height / 16 * 15, Screen.width / 4, Screen.height / 16 - 5), text);

        if (GUI.Button(new Rect(Screen.width / 16 * 5, Screen.height / 16 * 15, 25, Screen.height / 16 - 5), ">>"))
        {
            server.SendMessage("InServer", player.name + ": " + text);

            if (to == "0")
            {
                player.SendMessage("Name", text);
            }
            else {
                server.SendMessage("ToClient", to);
                 }
        }
    

        if (chat == true) {
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (14), Screen.width / 4, Screen.height / 16), message);
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (13), Screen.width / 4, Screen.height / 16), message1);
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (12), Screen.width / 4, Screen.height / 16), message2);
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (11), Screen.width / 4, Screen.height / 16), message3);
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (10), Screen.width / 4, Screen.height / 16), message4);
            GUI.Label(new Rect(Screen.width / 64, Screen.height / 16 * (9), Screen.width / 4, Screen.height / 16), message5);
         }
    }

} 
