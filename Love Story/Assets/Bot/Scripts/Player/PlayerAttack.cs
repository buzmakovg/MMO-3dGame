using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public float _damage = 20;
    public GameObject _player;
    public float attackTimer = 10;
    private float _attackTimer;
    public float attackDistance = 4;
    private int pwrlvl = 0;

    void Start () {
        _attackTimer = 0;
	}
	
	void Update () {
        
        GameObject[] _bot = GameObject.FindGameObjectsWithTag("Bot");
        for(int i=0; i<_bot.Length; i++) {  
            Vector3 pos = _bot[i].transform.position;
        pos.y = transform.position.y;

            if (Vector3.Distance(_bot[i].transform.position, _player.transform.position) < attackDistance)
            {
                if (_attackTimer == 0)
                {
                    if (Input.GetMouseButton(0))
                    {
                        transform.LookAt(pos);
                        _bot[i].SendMessage("ApplyDamageBot", _damage+pwrlvl*5);
                        _bot[i].SendMessage("BotHp", _damage + pwrlvl * 5);
                        _attackTimer = attackTimer;

                    }
                }
                else _attackTimer--;
            }
        }
       
    }

    void PowerAttack(int i)
    {
        pwrlvl = i-1; 
    }
}
