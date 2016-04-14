using UnityEngine;
using System.Collections;

public class ReSpawn : MonoBehaviour {
    public GameObject player;
    private GameObject _player;
    private GameObject _bot;
    private GameObject _bot1;
    private GameObject _bot2;
    public GameObject[] bot;
    public GameObject[] botHomePoint;
    public GameObject playerHomePoint;
    public GameObject[] healther;
    public float timer = 100;
    public float _timer = 0;
    public float _timer1 = 0;
    public float _timer2 = 0;

    void Start()
    {
        ReSpawnPlayer();
        
    }
    void Update()
    {
        
            ReSpawnBot();
       
      ReSpawnBot1();
      ReSpawnBot2();
    }

    void ReSpawnPlayer()
    {
        _player = Instantiate(player, playerHomePoint.transform.position, Quaternion.identity) as GameObject;
    }

    void ReSpawnBot()
    {

        if (_bot == null)
        {
            if (_timer == 0)
            {
                _bot = Instantiate(bot[0], botHomePoint[0].transform.position, Quaternion.identity) as GameObject;
                _bot.SendMessage("BotHomePoint", botHomePoint[0]);
                _bot.SendMessage("GuiSize", 1);
                _timer = timer;
           }
            else _timer--;
        }
  
    }

    void ReSpawnBot1()
    {
        if (_bot1 == null)
        {
            if (_timer1 == 0)
            {
                _bot1 = Instantiate(bot[1], botHomePoint[1].transform.position, Quaternion.identity) as GameObject;
                _bot1.SendMessage("GuiSize", 2);
                _bot1.SendMessage("BotHomePoint", botHomePoint[1]);
                _timer1 = timer;
            }
            else _timer1--;
        }
    }

    void ReSpawnBot2()
    {
        if (_bot2 == null)
        {
            if (_timer2 == 0)
            {
                _bot2 = Instantiate(bot[2], botHomePoint[2].transform.position, Quaternion.identity) as GameObject;
                _bot2.SendMessage("GuiSize", 3);
                _bot2.SendMessage("BotHomePoint", botHomePoint[2]);
                _timer2 = timer;
            }
            else _timer2--;
        }
    }

    void MedicineUp(GameObject medicine)
    {
        Instantiate(medicine, new Vector3(Random.Range(-50.0F, 50.0F),10,Random.Range(-50.0F, 50.0F)), Quaternion.identity); 
    }

    void OnGUI()
    {
        if(_player == null)
        {
            if(GUI.Button(new Rect(
                Screen.width/16*7,
                Screen.height/4,
                Screen.width/8,
                Screen.height/8),
                "Try Again"))
            {
                ReSpawnPlayer();
            }
            if (GUI.Button(new Rect(
                Screen.width / 16*7,
                Screen.height / 2,
                Screen.width / 8,
                Screen.height / 8),
                "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
    } 
}
