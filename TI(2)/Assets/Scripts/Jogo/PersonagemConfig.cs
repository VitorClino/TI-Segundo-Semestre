using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemConfig : MonoBehaviour
{
    private static int vidaPersonagem = VIda.Vida;
    private Transform[] rotas;
    public float speed = 5.0f;
    private int currentRouteIndex = 0;

    private bool moving = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("BuffRecuperarVida"))
        { 
            vidaPersonagem =10;
            Destroy(collider.gameObject);
        }
    }
    private void Start()
    {
        RouteManager routeManager = FindObjectOfType<RouteManager>();
        if ( routeManager != null)rotas = routeManager.rotas;
        
        
    }
    
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                moving = true;
            }
        }
        if (moving)
        {
            // Movimente o personagem apenas enquanto o jogador está tocando na tela
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Limitar a posição do personagem para evitar sair da pista
            float xPos = Mathf.Clamp(transform.position.x, -2.0f, 2.0f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }
}
