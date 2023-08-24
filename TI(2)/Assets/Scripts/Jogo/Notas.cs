using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    
    public GameObject nota;
    public Transform[] noteSpawnPoints;
    private float noteSpawnInterval = 3.0f;
    float noteIntervalMin = 1.0f;
    float noteIntervalInicial = 3.0f;

    public float altura = 10;

    private float noteSpeed = 15;
    public float velocidadeInicial = 15f;
    public float aumentoSpeed = 0.009f;
    private float distanciaPercorrida = 0; 
    public float noteLifetime = 4;

    

    private Transform playerTransform;
    private float nextNoteSpawnTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextNoteSpawnTime = Time.time + noteSpawnInterval;
        InvokeRepeating("ConfiguracaoNotas", 0.1f, 0.001f);
    }

    // Update is called once per frame
    private void ConfiguracaoNotas()
    {
        if (Time.timeScale != 0)
        {
            distanciaPercorrida += aumentoSpeed ;

            noteSpeed = velocidadeInicial+ (aumentoSpeed * distanciaPercorrida);

            if (noteSpawnInterval > noteIntervalMin)
            {
                noteSpawnInterval = noteIntervalInicial - (aumentoSpeed * distanciaPercorrida);
            }

            if (Time.time >= nextNoteSpawnTime)
            {   
                CreateNote();
                nextNoteSpawnTime = Time.time + noteSpawnInterval;
            }

            MoveNotes();
        }
    }

    private void CreateNote()
    {
        int numeroAleatorio = Random.Range(1,4);

        int spawnIndex = numeroAleatorio - 1;
        Vector3 spawnPosition = noteSpawnPoints[spawnIndex].position;
        spawnPosition.y = altura;
        GameObject newNote = Instantiate(nota, spawnPosition, Quaternion.identity);
        Destroy(newNote, noteLifetime);
    } 

    private void MoveNotes()
    {
        GameObject[] nota = GameObject.FindGameObjectsWithTag("Note");
        foreach (var note in nota)
        {
            note.transform.Translate(Vector3.forward * -noteSpeed * Time.deltaTime);
        }

    }
}






