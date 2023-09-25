using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCorDano : MonoBehaviour
{
    
    [Header("Pisca quando toma dano")]
    public Material materialOriginal;
    public Material materialDano;
    private Renderer playerRenderer;
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material = materialOriginal;
    }
    
    public void TakeDamage(){
        StartCoroutine(FlashWhite());
    }
    private IEnumerator FlashWhite()
    {
        playerRenderer.material = materialDano;
        yield return new WaitForSeconds(0.2f);
        playerRenderer.material = materialOriginal;
    }
}
