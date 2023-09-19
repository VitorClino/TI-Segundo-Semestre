using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarPlayer : MonoBehaviour
{
    private static string qualPlayer = GameController.QualPlayer;

    public GameObject[] player;
    public Vector3 spawn;
    private void OnEnable()
    {
       
        for (int i=0; i < player.Length; i++)if (player[i]!=null) Destroy(player[i].gameObject);

        Time.timeScale = 1;

        if (qualPlayer == "PlayerAmarelo") Instantiate(player[1], spawn, transform.rotation);
        if ((qualPlayer == "PlayerVermelho")||(qualPlayer == null)) Instantiate(player[0], spawn, transform.rotation);
    }

    
}
