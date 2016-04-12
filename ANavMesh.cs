using UnityEngine;
using System.Collections;

public class ANavMesh : MonoBehaviour
{
    private Transform _target;
    NavMeshAgent _agent;
    private Animation anim;
    public AnimationClip animAttack;
    public AnimationClip animRun;
	public AnimationClip animIdle;
    public float speedRun = 3;
	public float _damage;
	public float attackTimer;
	private float _attackTimer;
    public float attackDistance = 4;
    public float viewDistance = 15;
    private int k;
    private GameObject homePoint;
    private GameObject player;  

    void Start()
    {
		_attackTimer = 0;
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim[animAttack.name].layer = 1;
        anim[animAttack.name].wrapMode = WrapMode.Once;
        _agent = (NavMeshAgent)this.GetComponent("NavMeshAgent"); 
		anim.CrossFade(animIdle.name);
    }

    void Update()
    {   
        //GameObject[] _home = GameObject.FindGameObjectsWithTag("HomePointBot");
       player = GameObject.FindGameObjectWithTag("Player");
 
        Vector3 pos = player.transform.position;
        pos.y = transform.position.y;

        if(player)
        if (Vector3.Distance(_agent.transform.position, player.transform.position) < viewDistance)
        {
            _target = player.transform;
            _agent.SendMessage("Target", true);
            transform.LookAt(pos);
			anim.CrossFade(animRun.name);
			_agent.SetDestination(_target.position); 
        }
        else
        {
                //for (int i=0; i < _home.Length; i++)
                // {
                //   float _homemin = Vector3.Distance(_agent.transform.position, _home[0].transform.position);
                // k = 0;
                //if(Vector3.Distance(_agent.transform.position, _home[i].transform.position) < _homemin)
                // {
                //   _homemin = Vector3.Distance(_agent.transform.position, _home[i].transform.position);
                //  k = i;
                //}
                //}
            _agent.SendMessage("Target", false);
            _target = homePoint.transform;
			if (Vector3.Distance (_agent.transform.position, _target.position) <= 0.005) 
				anim.CrossFade (animIdle.name);
			else {
				anim.CrossFade (animRun.name);
				_agent.SetDestination (_target.position);
			}

        }

        if (Vector3.Distance(_agent.transform.position, player.transform.position) < attackDistance)
        {
            anim.CrossFade(animAttack.name);
            _agent.speed = 0;
        }
        else _agent.speed = speedRun;

        if (anim.IsPlaying(animAttack.name))
        {
			if (_attackTimer > 0) {
				_attackTimer--;
			} else {
				player.SendMessage ("ApplyDamage", _damage);
				_attackTimer = attackTimer;
			}
        }
    }
    void Awake() {
    }

    void BotHomePoint(GameObject _homePoint)
    {
        homePoint = _homePoint;
    }
}