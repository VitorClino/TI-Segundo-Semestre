using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Transform[] paths;

    public float speed = 5f, laneChangeSpeed = 5f;

    public int currentPathIndex = 1;

    public void SetMovimentoDir(InputAction.CallbackContext value)
    {
    ChangeLane(-1);
    
    }

    public void SetMovimentoEsq(InputAction.CallbackContext value)
    {
    ChangeLane(1);
    }

    void ChangeLane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;
        if (newPathIndex >= 0 && newPathIndex < paths.Length)
        {
            currentPathIndex = newPathIndex;
        }

        Vector2 targetPosition = new Vector2(paths[currentPathIndex].position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }
}