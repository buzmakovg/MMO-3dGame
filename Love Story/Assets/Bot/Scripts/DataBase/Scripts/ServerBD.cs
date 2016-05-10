using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class ServerBD : MonoBehaviour
{
    private string id;
    private string login;
    private string password;
    private string type = "1";
    private string x = "0";
    private string y = "0";
    private string z = "0";
    private string lvl = "1";
    private string exp = "0";
    private string hp = "100";
    private string gold = "1000";
    private string heartone = "0";
    private string hearttwo = "0";
    private string heartthree = "0";
    private string dataBaseName;
    SqliteConnection cnn;

    void Start()
    {
        dataBaseName = @"C:\Users\Володя\Documents\GitHub\MMO-3dGame\Love Story\Assets\Bot\Scripts\DataBase\db\usersDatabase.db";
        cnn = new SqliteConnection(string.Format("Data Source = {0}", dataBaseName));
    }

    void LoginUp(string _login)
    {
        login = "'" + _login + "'";
    }

    void PasswordUp(string _password)
    {
        password = "'" + _password + "'";
    }

    void TypeUp(float _type)
    {
        type = _type.ToString();
    }

    void XUp(float _x)
    {
        x = _x.ToString();
    }

    void YUp(float _y)
    {
        y = _y.ToString();
    }

    void ZUp(float _z)
    {
        z = _z.ToString();
    }

    void LvlUp(float _lvl)
    {
        lvl = _lvl.ToString();
    }

    void ExpUp(float _exp)
    {
        exp = _exp.ToString();
    }

    void HPUp(float _hp)
    {
        hp = _hp.ToString();
    }

    void GoldsUp(float _gold)
    {
        gold = _gold.ToString();
    }

    void Heart1Up(float _heartone)
    {
        heartone = _heartone.ToString(); 
    }

    void Heart2Up(float _hearttwo)
    {
        hearttwo = _hearttwo.ToString();
    }

    void Heart3Up(float _heartthree)
    {
        heartthree = _heartthree.ToString();
    }

    void IdUp(int _id)
    {
        id = _id.ToString();
    }

    private bool saveOk;

    void SignUp()
    {
        bool exist = false;
            cnn.Open();
        SqliteCommand cmd = new SqliteCommand(cnn);
        cmd.CommandText = string.Format("SELECT id FROM 'users' WHERE login = {0}", login);
        SqliteDataReader reader = cmd.ExecuteReader();
            foreach (IDataRecord record in reader)
            {
            exist = true;
            }
        if (!exist)
        {
            SqliteCommand cmd1 = new SqliteCommand(cnn);
            cmd1.CommandText = string.Format("INSERT INTO 'users' ('login','password','type','x','y','z','hp','lvl','exp','gold','heartone','hearttwo','heartthree') VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});", login, password, type, x, y, z, hp, lvl, exp, gold, heartone, hearttwo, heartthree);
            cmd1.ExecuteNonQuery();
            saveOk = true;
        }
        else
        {
            error = true;
            errorText = "Error!!! Этот логин занят!";
        }
            cnn.Close();
    }

    void SignIn()
    {
        bool exist = false;
        string account = "login =" + login + " AND password =" + password;
        cnn.Open();
        SqliteCommand cmd = new SqliteCommand(cnn);
        cmd.CommandText = string.Format("Select id FROM 'users' WHERE {0}", account);
        SqliteDataReader reader = cmd.ExecuteReader();
            foreach(IDataRecord record in reader)
            {
                id = record["id"].ToString();
                exist = true;
            }
        if(exist) Application.LoadLevel(1);
        //    GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        //if (exist) { 
        //    for (int i=0; i < player.Length; i++)
        //    {
        //        if(player[i].name == login)
        //        {
        //            player[i].SendMessage("EnterGame", id);
        //        }
        //    }
        //}
        else
        {
            error = true;
            errorText = "Error!!! Комбинация логина и пароля не найдена!";
        }
        cnn.Close();
    }

    void SaveUp()
    {
        cnn.Open();
        SqliteCommand cmd = new SqliteCommand(cnn);
        cmd.CommandText = string.Format("UPDATE users SET x = {0}, y = {1}, z = {2}, hp = {3}, lvl = {4}, exp = {5}, gold = {6}, heartone = {7}, hearttwo = {8}, heartthree = {9} WHERE id = {10};",x,y,z,hp,lvl,exp,gold,heartone,hearttwo,heartthree,id);
        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    void ToBag(string _playerName)
    {
        string first;
        string second;
        string third;
        string playerName = "'" + _playerName + "'";
        float one;
        float two;
        float three;
        cnn.Open();
        SqliteCommand cmd = new SqliteCommand(cnn);
        cmd.CommandText = string.Format("SELECT * FROM 'users' WHERE login = {0};", playerName);
        SqliteDataReader reader = cmd.ExecuteReader();
        foreach (IDataRecord record in reader)
        {
            first = record["heartone"].ToString();
            second = record["hearttwo"].ToString();
            third = record["heartthree"].ToString();
            float.TryParse(third, out one);
            float.TryParse(third, out two);
            float.TryParse(third, out three);
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i].name == _playerName)
                {
                    player[i].SendMessage("ToBag1", one);
                    player[i].SendMessage("ToBag2", two);
                    player[i].SendMessage("ToBag3", three);
                }
            }
        }
        cnn.Close();
    }

    private bool error;
    private string errorText;
    private string _login = "";
    private string _password = "";
    public GUIStyle ChooseStyle;
    private float _type;
    private bool enter;
    private bool enter1 = true;
    public GUIStyle SignStyle;

    void OnGUI()
    {
        
        _login = GUI.TextField(new Rect(Screen.width / 8 * 3, Screen.height / 4, Screen.width / 4, 20), _login);
        _password = GUI.TextField(new Rect(Screen.width / 8 * 3, Screen.height / 4 + 30, Screen.width / 4, 20), _password);

        if (GUI.Button(new Rect(
                Screen.width / 8 * 3,
                Screen.height / 4 + 55,
                Screen.width / 8,
                30),
                "Sign In"))
        {
            SendMessage("LoginUp", _login);
            SendMessage("PasswordUp", _password);
            SendMessage("SignIn");
        }

        if (GUI.Button(new Rect(
                Screen.width / 2,
                Screen.height / 4 + 55,
                Screen.width / 8,
                30),
                "Sign Up"))
        {
            enter1 = false;
        }
        if (!enter1)
        {
            if (GUI.Button(new Rect(Screen.width / 64 * 19,
                Screen.height / 2,
                Screen.width / 32 * 3, 30), "Cat 1"))
            {
                _type = 1;
                enter1 = true;
                enter = true;
            }
            if (GUI.Button(new Rect(Screen.width / 64 * 29 + 5,
                Screen.height / 2,
                Screen.width / 32 * 3, 30), "Cat 2"))
            {
                _type = 2;
                enter1 = true;
                enter = true;
            }
            if (GUI.Button(new Rect(Screen.width / 64 * 40 - 5,
                Screen.height / 2,
                Screen.width / 32 * 3, 30), "Cat 3"))
            {
                _type = 3;
                enter1 = true;
                enter = true;
            }
        }
            if (enter)
            {
                if (GUI.Button(new Rect(Screen.width / 16*7,
                Screen.height / 2,
                Screen.width/8, 40 ), "Sign Up"))
                {
                    SendMessage("LoginUp", _login);
                    SendMessage("PasswordUp", _password);
                    SendMessage("TypeUp", _type);
                    SendMessage("SignUp");
                    enter = false;
                }
            }
        
        if (error)
        {
            GUI.Label(new Rect(Screen.width / 4,
                Screen.height / 8,
                Screen.width / 2,
                20), errorText, SignStyle);
        }
        if (saveOk)
        {
            _login = "";
            _password = "";

            error = false;
            GUI.Label(new Rect(Screen.width / 4,
                Screen.height / 8,
                Screen.width / 2,
                20), "Поздравляем! Регистрация прошла успешно!", SignStyle );
            saveOk = false;
        }
    }

}
