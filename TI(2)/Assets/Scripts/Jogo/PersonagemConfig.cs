using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemConfig : MonoBehaviour
{
    private Transform[] rotas;
    public float speed = 5.0f;
    private int currentRouteIndex = 0;
    public VIda vIda;
    private bool moving = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BuffRecuperarVida"))
        { 
            vIda.RecuperarVida(true);
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
            Transform currentRoute = rotas[currentRouteIndex];
            
            
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentRoute.position, step);
            if (Vector3.Distance(transform.position, currentRoute.position)<0)
            { 
                currentRouteIndex = (currentRouteIndex + 1) % rotas.Length;
                moving = false;
            }
        }
    }
}
