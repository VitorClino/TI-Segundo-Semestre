using UnityEngine;
using System.Collections;
using UnityEngine.iOS;
using UnityEngine.UI;
using Unity.VisualScripting;
public class MovimentoPlayer : MonoBehaviour
{

    public Transform[] paths;

    public float speed = 5f, laneChangeSpeed = 5f;
    public int currentPathIndex = 1;
    public InputManager inputManager;
    public Vector2 startPos, direction;
    public Text m_Text; string message;

    [Header("Pisca quando toma dano")]
    public Material materialOriginal;
    public Material materialDano;
    private int life = 10;
    private int vidaAtual;
    private Renderer playerRenderer;
    void OnEnable()
    {
        vidaAtual = life;
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.material = materialOriginal;
        InvokeRepeating("TrocaCor", 0.1f, 0.5f);
    }
    /*void Update()
    {
        m_Text.text = $"Touch : {message} in direction {direction}";
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch( touch.phase)
            {
                case TouchPhase.Began: startPos = touch.position;
                            message = "Begun "; break;
                case TouchPhase.Moved: direction = touch.position - startPos;
                            message = "Moving "; break;
                case TouchPhase.Ended:
                            message = "Ending "; break;
            }
            Debug.Log(m_Text);

            /*if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

    
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    ChangeLane(-1);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    ChangeLane(1);
                }
            }
        }
    }*/
    public void ChangeLane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;

        if ((newPathIndex >= 0) && (newPathIndex < paths.Length))
        {
            currentPathIndex = newPathIndex;
        }
        transform.position = new Vector3(paths[currentPathIndex].position.x, transform.position.y, 0);
    }
    public void TrocaCor()
    {
        Debug.Log("vida " + life);
        if(vidaAtual>life)
        {
            TakeDamage();
            vidaAtual--;
        }
    }
    public void TakeDamage(){
        playerRenderer.material= materialDano;
        Esperar(0.2f); 
    }
    public void Heal(){
        playerRenderer.material= materialOriginal;
    }
    public IEnumerator Esperar(float time){
        yield return new WaitForSeconds(time);
        Heal();
    }
}

