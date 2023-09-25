
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VIda : MonoBehaviour
{
    public int vida =10;
    public bool IMORTAL = false;
    public GameObject panel;
    public Text m_Vida;

    void OnEnable(){
        InvokeRepeating("Derrota", 0.1f, 0.1f);
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Note" && IMORTAL == false){
        vida--;
        
        TrocaCorDano trocaCorDano = FindObjectOfType<TrocaCorDano>();
        trocaCorDano.TakeDamage();
        }
        
        Destroy(other.gameObject);
    }
    void Derrota(){
        m_Vida.text = $"Vida: {vida}";
        if(vida <= 0){
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void RecuperarVida(){vida=16;}
}
