
using UnityEngine;
using UnityEngine.UI;

public class Pontos : MonoBehaviour
{
    public Text scoreText;
    int score;
    void Start()
    {
        score = 0;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Note"))
        {
            score = score + 10;
            scoreText.text = $"pontuacao: {score.ToString()}";
            Destroy(collider.gameObject);
        }
    }
    
}
