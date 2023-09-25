using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    
    public GameObject nota;
    public Transform[] noteSpawnPoints;
    
    [Header("Configuracoes de velocidade")]
    private float noteIntervalMin = 0.1f, noteIntervalMin2 = 0.25f, noteIntervalMax2 =55;
    public float intervaloNotas = 0.15f,intervaloNotas2 = 0.5f, noteVelocidade=35;
    private float aumentoSpeed = 5e-06f, aumentoSpeed2 =5e-06f , aumentoSpeed3 = 5e-05f;
    public bool gerar = true;

    int rdm;

    [Header("Spawn de Buffs")]
    public GameObject recurperarVida;
    private GameObject newBuff;
    int randomLaneBUff;
    bool  CriarBuff =true;
     
    void Start()
    {
        InvokeRepeating("ConfiguracaoNotas", 1f, 0.01f);
        InvokeRepeating("ConfiguracaoBUFFs", 1f, 5.0f);
    }
    void Update()
    {
        if(nota.gameObject!=null)MoveNotes();
    }
    
    
    private void ConfiguracaoNotas()
    {
        if (Time.timeScale != 0 )
        {
            int random = Random.Range(7,9);

            rdm = Random.Range(0, 3);
            int auxRandomBuff = Random.Range(0,3);
            if(auxRandomBuff == rdm)CriarBuff = false;
            else {randomLaneBUff = auxRandomBuff;
                                CriarBuff = true;}
            int i =0;

            if(intervaloNotas > noteIntervalMin) intervaloNotas -= aumentoSpeed;

            if(intervaloNotas2 > noteIntervalMin2) intervaloNotas2 -= aumentoSpeed2;
            
            if (gerar)CreateNote(random, rdm, i);
        }
    }

    private void CreateNote(int random, int numeroAleatorio, int i)
    {
        gerar = false;
        Vector3 spawnPosition = noteSpawnPoints[numeroAleatorio].position;

        GameObject newNote = Instantiate(nota, spawnPosition, Quaternion.identity);
        
        if( i< random)StartCoroutine(EsperarAlgunsSegundos( intervaloNotas, random, numeroAleatorio, i));
        
        else if (i== random)  StartCoroutine(EsperarAlgunsSegundos(intervaloNotas2, random, numeroAleatorio, i));
        
    } 
    
    private IEnumerator EsperarAlgunsSegundos(float segundos, int random, int numeroAleatorio, int i)
    {
        yield return new WaitForSeconds(segundos);

        if (i == random)
        {
            ConfiguracaoNotas();
            gerar = true;
        }
        else  CreateNote(random, numeroAleatorio, ++i);
    }

    private void MoveNotes()
    {
        if (noteVelocidade < noteIntervalMax2) noteVelocidade += aumentoSpeed3;

        GameObject[] nota = GameObject.FindGameObjectsWithTag("Note");
        foreach (var note in nota)
        {
            note.transform.Translate(Vector3.forward * -noteVelocidade * Time.deltaTime);
        }
    }
    //*******************************BUFFS*********************************
    private void ConfiguracaoBUFFs()
    {
        if (CriarBuff == true) CreateBuff(randomLaneBUff);
        
        else Debug.Log("ai papai");
    }

    private void CreateBuff(int random)
    {
        Vector3 spawnPosition = noteSpawnPoints[random].position;
        newBuff=Instantiate(recurperarVida, spawnPosition ,transform.rotation);
        newBuff.GetComponent<Rigidbody>().velocity = transform.forward * -noteVelocidade;
        
        //EsperarBuff(5.0f);
    }
    /*private IEnumerator EsperarBuff(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        buffON = true;
        ConfiguracaoBUFFs();
    }*/
}






