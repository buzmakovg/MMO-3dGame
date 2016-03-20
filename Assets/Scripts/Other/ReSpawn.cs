using UnityEngine;
using System.Collections;

public class ReSpawn : MonoBehaviour {
    public GameObject player;
    private GameObject _player;
    private PlayerDamage _pd;
    private GameObject _bot;
    private GameObject _bot1;
    private GameObject _bot2;
    private BotDamage _bd;
    public GameObject[] bot;
    public GameObject playerHomePoint;

    void Update() { 
        if (_player == null) ReSpawnPlayer();
        if (_bot == null) ReSpawnBot();
    }

    void ReSpawnPlayer()
    {
        _player = Instantiate(player, playerHomePoint.transform.position, Quaternion.identity) as GameObject;
    }

    void ReSpawnBot()
    {
        _bot = Instantiate(bot[0], new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
    }
}
