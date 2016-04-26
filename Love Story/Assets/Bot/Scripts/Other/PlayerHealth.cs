using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 50;
    public float medTimer = 10;
    private float _medTimer;
    //public GameObject _camera;

	void Start () {
	
	}


    void Update() {
        GameObject[] _medicine = GameObject.FindGameObjectsWithTag("Medicine");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < _medicine.Length;i++) {
            if (Vector3.Distance(player.transform.position, _medicine[i].transform.position) < 2)
            {
                
                    player.SendMessage("ApplyHealth", health);
      //          _camera.SendMessage("ReMedicine", _medicine[i]);
                Destroy(_medicine[i]);
                }
            }
        }

    void TransferBot(int number) {
        //_camera.SendMessage("ReSpawnBot", number);
    }
    }

