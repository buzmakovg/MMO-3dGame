using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(
                Screen.width/4,
                Screen.height/4,
                Screen.width/2,
                Screen.height/2),
                "Choose to Player"))
        {

            Application.LoadLevel(1);
        }
    }
}
