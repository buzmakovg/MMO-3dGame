using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public float hp = 100;
    public GUIStyle hpStyle;
    public GUIStyle goldStyle;
    public GameObject player;
    public float gold = 5;
    //private GameObject _player;

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
    void OnGUI() 
    {

        GUI.Label(new Rect(1, 1, 150, 50), "HP: " + hp, hpStyle);
        GUI.Label(new Rect(150, 1, 150, 50), "Gold: " + gold, goldStyle);
    }

} 
