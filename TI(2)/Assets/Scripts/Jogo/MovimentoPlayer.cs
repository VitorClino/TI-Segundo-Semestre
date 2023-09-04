using UnityEngine;
using System.Collections;
using UnityEngine.iOS;
public class PlayerController : MonoBehaviour
{

    public Transform[] paths;

    public float speed = 5f, laneChangeSpeed = 5f;
    public int currentPathIndex = 1;

   private Vector3 position;
    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {

        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

    
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    ChangeLane(-1);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    ChangeLane(1);
                }
            }
        }
    }

        
    public void ChangeLane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;

        if ((newPathIndex >= 0) && (newPathIndex < paths.Length))
        {
            currentPathIndex = newPathIndex;
        }

        transform.position = new Vector3(paths[currentPathIndex].position.x, transform.position.y, 0);
    }
}

