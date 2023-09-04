using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] player;
    private GameObject auxPlayer;

    public Vector3 spawn;
    
    void Start()
    {
        Time.timeScale = 1;
        auxPlayer = Instantiate(player[0], spawn, transform.rotation);
    }

    public void CriarPlayer(int i)
    {
        int personagem = 0;
        int j =0;
        if (i==1)
        {
            personagem = j;
            j=i;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn , transform.rotation );
        }
        if (i==(-1))
        {
            personagem = j;
            j=0;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn , transform.rotation );
        }
        
    }
    

}
