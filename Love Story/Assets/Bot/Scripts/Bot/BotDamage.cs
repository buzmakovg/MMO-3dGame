using UnityEngine;
using System.Collections;

public class BotDamage : MonoBehaviour
{
    public GameObject bot;
    public float hp = 100;
    public float gold = 100;
    public float exp = 11;
    public bool died;
    private Animation anim;
    public AnimationClip animDeath;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim[animDeath.name].layer = 1;
        anim[animDeath.name].wrapMode = WrapMode.Once;
    }
    void ApplyDamageBot(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("GoldUp", gold);
            player.SendMessage("ExpUp", exp);
            died = true;
            bot.SendMessage("DiedBot", died);
            anim.CrossFade(animDeath.name);
            Destroy(bot);
        }
    }
}