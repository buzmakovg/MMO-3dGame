using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public float _damage = 20;
    public GameObject _player;
    public float attackTimer = 10;
    private float _attackTimer;
    public float attackDistance = 4;

    private Animation anim;
    public AnimationClip playerAttack;

    void Start () {
        _attackTimer = 0;
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim[playerAttack.name].layer = 1;
        anim[playerAttack.name].wrapMode = WrapMode.Once;
	}
	
	void Update () {
        
        GameObject[] _bot = GameObject.FindGameObjectsWithTag("Bot");
        GameObject[] _medicine = GameObject.FindGameObjectsWithTag("Medicine");
        for(int i=0; i<_bot.Length; i++) {  
            Vector3 pos = _bot[i].transform.position;
        pos.y = transform.position.y;

            if (Vector3.Distance(pos, _player.transform.position) < attackDistance)
            {
                if (_attackTimer == 0)
                {
                    if (Input.GetMouseButton(0))
                    {
                        transform.LookAt(pos);
                        anim.CrossFade(playerAttack.name);
                        _bot[i].SendMessage("ApplyDamageBot", _damage);
                        _attackTimer = attackTimer;

                    }
                }
                else _attackTimer--;
            }
          }

        for (int i = 0; i < _medicine.Length; i++)
        {
            if (Vector3.Distance(_medicine[i].transform.position, _player.transform.position) < attackDistance)
            {
                anim.CrossFade(playerAttack.name);
                _medicine[i].SendMessage("DestroyHealther", _player);
                
            }
        }
       
    }
}
