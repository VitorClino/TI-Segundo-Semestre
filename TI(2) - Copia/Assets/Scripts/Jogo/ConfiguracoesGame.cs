using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguracoesGame : MonoBehaviour
{
    public GameObject casa; 
    public Transform spawn;
    public float speed = 5.0f, destroyTime= 5.0f;
    public float casasIntervalo = 0.5f;

    [Header("Destruicao do player")]
    public GameObject[] players;
    void Start()
    {
        InvokeRepeating("InvocarCasas", 0.1f, casasIntervalo);
    }

    public void InvocarCasas()
    {
        Vector3 spawnCasa = spawn.position;
        GameObject newCasa = Instantiate(casa, spawnCasa, Quaternion.identity);
        newCasa.GetComponent<Rigidbody>().velocity = transform.forward * -speed;
        Destroy (newCasa, destroyTime);
    }
    
}
