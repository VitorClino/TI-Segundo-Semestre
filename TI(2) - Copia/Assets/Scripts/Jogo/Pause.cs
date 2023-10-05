using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    private bool pausado = false;
    
    private void start()
    {
        panel.SetActive(false);
    }

    public void TogglePause()
    {
        pausado = !pausado;

        if( pausado)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        else{
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }
}

