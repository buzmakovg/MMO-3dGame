using UnityEngine;
using System.Collections;

public class BotDamage : MonoBehaviour
{
    public GameObject bot;
    public float hp = 100;
    public GUIStyle myStyle;
    private GameObject _bot;

    void ApplyDamageBot(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(bot);
    }
    void OnGUI()
    {
       GUI.Label(new Rect(1, 100, 150, 20), "Bot HP:" +hp, myStyle);
    }
}