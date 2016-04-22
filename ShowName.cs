using UnityEngine;

public class ShowName : MonoBehaviour
{
    public string text;
    public float objectSize = 2;
    public GUIStyle messageStyle;
    private bool _showName;
    private Vector2 _position;

    public void Update()
    {
        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(transform.position);
        
        if (cameraRelative.z > 0)
        {
                RaycastHit hit;
                Vector3 direction = transform.position - Camera.main.transform.position;
                Ray ray = new Ray(Camera.main.transform.position, direction);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.distance >= (direction.magnitude - objectSize))
                    {
                        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
                        _position = new Vector2(screenPosition.x - 60f, Screen.height - screenPosition.y - 200f);
                    }
                }
        }
    }

    void Name(string _text)
    {
        text = _text;
        if (text == "") _showName = false;
        else _showName = true;
    }

    public void OnGUI()
    { 
        if (_showName)
        {
            GUI.Box(new Rect(_position.x + 50f - 3f * text.Length, _position.y, 30f + 10f * text.Length, 80f), "  " + text, messageStyle);
        }
    }


}
