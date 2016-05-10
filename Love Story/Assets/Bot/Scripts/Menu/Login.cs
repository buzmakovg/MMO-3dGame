using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    public string login = "";
    public string password = "";
    private GameObject _camera;
    private bool signin;
    private bool exist;
    public string id; 
    
    // Use this for initialization
    void Start() {
        _camera = GameObject.FindGameObjectWithTag("Main Camera");

    }

    void Update()
    {
        
    }

    void EnterGame(string key)
    {
        if (key == "")
        {
            exist = false;
        } else
        {
            id = key;
            Application.LoadLevel(2);
        }
    }

    void OnGUI()
    {
            login = GUI.TextField(new Rect(Screen.width / 8 * 3, Screen.height / 4, Screen.width / 4, 20), login);
            password = GUI.TextField(new Rect(Screen.width / 8 * 3, Screen.height / 4 + 30, Screen.width / 4, 20), password);

            if (GUI.Button(new Rect(
                    Screen.width / 8 * 3,
                    Screen.height / 4 + 55,
                    Screen.width / 8,
                    20),
                    "Sign In"))
            {
                _camera.SendMessage("LoginUp", login);
                _camera.SendMessage("PasswordUp", password);
                _camera.SendMessage("SignIn");
            }

            if (GUI.Button(new Rect(
                    Screen.width / 4,
                    Screen.height / 4 + 55,
                    Screen.width / 8,
                    20),
                    "Sign Up"))
            {
            _camera.SendMessage("LoginUp", login);
            _camera.SendMessage("PassordUp", password);
            _camera.SendMessage("SignUp");
            }
        if (!exist)
        {
            GUI.Label(new Rect(Screen.width / 4,
                Screen.height / 2,
                Screen.width / 2,
                20), "Error!!! Комбинация логина и пароля не найдена!");
        }
        }
    
}
