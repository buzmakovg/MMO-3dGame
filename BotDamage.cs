using UnityEngine;
using System.Collections;

public class BotDamage : MonoBehaviour
{
    public GameObject bot;
    public float hp = 100;
    public float guisize = 1;
    public GUIStyle myStyle;
    private bool _target;
    public float gold = 100;
    private PlayerAttack _pa;

    void Target(bool target)
    {
        _target = target;
    }
    void GuiSize(float number)
    {
        guisize = number;
    }
    void ApplyDamageBot(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("GoldUp", gold);
          Destroy(bot);
        }
    }

    
    void OnGUI()
    {
        if(_target)
        GUI.Label(new Rect(1, 10+10*guisize, 100, 10), "Bot HP:" + hp, myStyle);

    }
}