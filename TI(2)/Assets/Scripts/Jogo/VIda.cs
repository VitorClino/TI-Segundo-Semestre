using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class VIda : MonoBehaviour
{
    public static int vida = 10;
    public bool IMORTAL = false;
    public GameObject panel;
    
    void OnEnable()
    {
        vida = 10;
        InvokeRepeating("Derrota", 0.1f, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (IMORTAL == false)vida--;
        else vida = 10;
        Debug.Log($"vida = {vida}");
        Destroy(other.gameObject);

    }
    void Derrota()
    {
        if(vida <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public static int Vida
    {
        get {return vida;}
        set {vida = value;}
    }
}
