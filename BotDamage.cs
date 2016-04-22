using UnityEngine;
using System.Collections;

public class BotDamage : MonoBehaviour
{
    public GameObject bot;
    public float hp = 100;
    public float gold = 100;
    public float exp = 11;

    void ApplyDamageBot(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("GoldUp", gold);
            player.SendMessage("ExpUp", exp);
            Destroy(bot);
        }
    }
}