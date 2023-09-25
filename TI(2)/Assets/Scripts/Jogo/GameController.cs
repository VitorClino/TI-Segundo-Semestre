using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] player;
    private GameObject auxPlayer;

    public Vector3 spawn;
    private static string qualPlayer;
    
    void Start()
    {
        Time.timeScale = 1;
        auxPlayer = Instantiate(player[0], spawn, transform.rotation);
        
    }
    public void CriarPlayer(int i)
    {
        int j =0;
        if (i==1)
        {
            j=i;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn , transform.rotation );
        }
        if (i==(-1))
        {
            j=0;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn , transform.rotation );
        }
        if(auxPlayer.tag == "PlayerAmarelo") qualPlayer="PlayerAmarelo";

        if (auxPlayer.tag == "PlayerVermelho") qualPlayer="PlayerVermelho";

        Debug.Log(qualPlayer);
    }
    public static string QualPlayer
    {
        get {return qualPlayer;}
        set {qualPlayer = value;}
    }
}
