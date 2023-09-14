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

    


    private float nextNoteSpawnTime;

    void Start()
    {
      
        nextNoteSpawnTime = Time.time + noteSpawnInterval;
        InvokeRepeating("ConfiguracaoNotas", 0.1f, 0.001f);
    }

    // Update is called once per frame
    private void ConfiguracaoNotas()
    {
        if (Time.timeScale != 0)
        {
            int random = Random.Range(7,9);
            int numeroAleatorio = Random.Range(0, 3);
            int i = 0;

            distanciaPercorrida += aumentoSpeed ;

            noteSpeed = velocidadeInicial+ (aumentoSpeed * distanciaPercorrida);

            if (noteSpawnInterval > noteIntervalMin)
            {
                noteSpawnInterval = noteIntervalInicial - (aumentoSpeed * distanciaPercorrida);
            }

            if (Time.time >= nextNoteSpawnTime)
            {   
                CreateNote(random, numeroAleatorio, i);
                nextNoteSpawnTime = Time.time + noteSpawnInterval;
            }

            MoveNotes();
            
        }
    }

    private void CreateNote(int random, int numeroAleatorio, int i)
    {
        
        i++;
        Vector3 spawnPosition = noteSpawnPoints[numeroAleatorio].position;

        GameObject newNote = Instantiate(nota, spawnPosition, Quaternion.identity);
        Destroy(newNote, noteLifetime);
        if( i< random)
        {
            StartCoroutine(EsperarAlgunsSegundos(0.15f, random, numeroAleatorio, i));
        }
    } 
    private IEnumerator EsperarAlgunsSegundos(float segundos, int random, int numeroAleatorio, int i)
    {
        yield return new WaitForSeconds(segundos);

        CreateNote(random, numeroAleatorio, i);
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






