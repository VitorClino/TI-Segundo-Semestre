using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;
public class MovimentoPlayer : MonoBehaviour
{
    [Header("movimento")]
    private Transform[] paths ;
    public int currentPathIndex = 1;
    public Vector2 startPos, direction;
    public float distanciaMin=15;
    public float moveSpeed = 90f;
    private Vector3 targetPosition;

    
    void OnEnable()
    {
        RouteManager routeManager = FindObjectOfType<RouteManager>();
        if (routeManager != null) paths = routeManager.rotas;
        targetPosition.y = -3.17f;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                break;

                case TouchPhase.Ended: direction = touch.position - startPos;
                
                   if (direction.x > distanciaMin)
                        ChangeLane(1);
                   else if (direction.x < -distanciaMin)
                        ChangeLane(-1);
                break;
            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
    public void ChangeLane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;
        if (newPathIndex >= 0 && newPathIndex < paths.Length)
        {
            currentPathIndex = newPathIndex;
            targetPosition = new Vector3(paths[currentPathIndex].position.x, transform.position.y, 0);
        }
    }

}

