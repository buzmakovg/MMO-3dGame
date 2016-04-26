using UnityEngine;

public class HpBot: MonoBehaviour
{
    public float objectSize = 2;
    public float hpmax = 100;
    private float hp;
    private float _hp;
    public GUIStyle bar;
    public GUIStyle fon;
    private bool _showName;
    private Vector2 _position;
    public float barview = 20f;
    public float barheigth = 25f;

 void Start()
    {
        hp = hpmax;
    }

    public void Update()
    {
        _hp = hp / hpmax;
        _showName = false;
        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(transform.position);
        if (cameraRelative.z > 0)
        {
                RaycastHit hit;
                Vector3 direction = transform.position - Camera.main.transform.position;
                Ray ray = new Ray(Camera.main.transform.position, direction);
                if (Physics.Raycast(ray, out hit, barview))
                {
                    if (hit.distance >= (direction.magnitude - objectSize))
                    {
                        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
                        _position = new Vector2(screenPosition.x - 26f, Screen.height - screenPosition.y - barheigth);
                        _showName = true;
                    }
                }
            }
    }

    void BotHp(float _hp)
    {
        hp -= _hp;

    }
    public void OnGUI()
    {
        if (_showName)
        {
            GUI.Box(new Rect(_position.x, _position.y, 60f * _hp, 10f), "", bar);
            GUI.Box(new Rect(_position.x, _position.y, 60f, 10f), "", fon );
        }
    }


}

