using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 50;
    public GameObject medicine;

	void Start () {
	
	}


    void Update() {
        //GameObject _camera = GameObject.FindGameObjectWithTag("Main Camera");
        //GameObject[] _medicine = GameObject.FindGameObjectsWithTag("Medicine");
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //for (int i = 0; i < _medicine.Length;i++) {
          //  if (Vector3.Distance(player.transform.position, _medicine[i].transform.position) < 5)
            //{
               
                   // player.SendMessage("ApplyHealth", health);
                  //  _camera.SendMessage("MedicineUp", _medicine[i]);
                //    Destroy(_medicine[i]);
              // }
        }
    

    void DestroyHealther(GameObject player)
    {
        GameObject _camera = GameObject.FindGameObjectWithTag("MainCamera");
        player.SendMessage("ApplyHealth",health);
        _camera.SendMessage("MedicineUp", medicine);
        Destroy(medicine);
    }
}
