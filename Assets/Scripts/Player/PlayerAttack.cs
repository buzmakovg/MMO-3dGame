using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public float _damage = 20;
    public GameObject _player;
    public float attackTimer = 10;
    private float _attackTimer;
    public float attackDistance = 4;

    void Start () {
        _attackTimer = 0;
	}
	
	void Update () {
        
        GameObject _bot = GameObject.FindGameObjectWithTag("Bot");
        Vector3 pos = _bot.transform.position;
        pos.y = transform.position.y;

        if (Vector3.Distance(_bot.transform.position, _player.transform.position) < attackDistance)
        {
            if (_attackTimer == 0)
            {
                if (Input.GetMouseButton(0))
                {
                    transform.LookAt(pos);
                    _bot.SendMessage("ApplyDamageBot", _damage);
                    _attackTimer = attackTimer;
                }
            }
            else _attackTimer--;
            
        }
       
    }
}
