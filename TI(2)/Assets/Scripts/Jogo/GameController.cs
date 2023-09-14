using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] player;
    private GameObject auxPlayer;

    public static GameController instance;

    public Vector3 spawn;

    public int escolha = 0;
    void Start()
    {
        instance = this;
        Time.timeScale = 1;

        auxPlayer = Instantiate(player[escolha], spawn, transform.rotation);

        DontDestroyOnLoad(this.gameObject);
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
        if (auxPlayer.tag == "PlayerVermelho") escolha = 0;

        if (auxPlayer.tag == "PlayerAmarelo" ) escolha = 1;


        Debug.Log(escolha);
    }
    

}
