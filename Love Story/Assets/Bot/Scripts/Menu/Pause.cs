using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private bool menu;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.M)) menu = true;
        if (Input.GetKey(KeyCode.N)) menu = false;
    }

    void OnGUI()
    {
        if (menu)
        {
            // if(GUI.Button(new Rect(
            //   Screen.width/16,
            //   Screen.height/16,
            //   Screen.width/16,
            //   Screen.height/16),
            //   "Resume"))
            //{
            //    menu = false;
            //}

            if (GUI.Button(new Rect(
                Screen.width / 16,
                Screen.height / 8,
                Screen.width / 16,
                Screen.height / 16),
                "Options"))
            {
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(
                Screen.width / 16,
                Screen.height / 16*3,
                Screen.width / 16,
                Screen.height / 16),
                "Save"))
            {
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(
                Screen.width / 16,
                Screen.height / 4,
                Screen.width / 16,
                Screen.height / 16),
                "Exit"))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
