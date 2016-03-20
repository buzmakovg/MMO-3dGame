using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public float hp = 100;
    public GUIStyle myStyle;
    public GameObject player;
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

    void OnGUI() 
    {

        GUI.Label(new Rect(1, 1, 150, 50), "HP: " + hp, myStyle);  

    }

} 
