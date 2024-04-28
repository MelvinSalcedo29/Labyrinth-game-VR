using System;
using UnityEngine;

public class RaycastAndFollow : MonoBehaviour
{
    public Transform objetoEspecifico;
    public Transform objetoQueSigue;
    public float velocidadSeguimiento = 5f;
    private bool haImpactado = false;
    private Vector3 posicionImpacto;
    public LayerMask capaObjetivo;
    public LayerMask CapaParedes = 1 << 7;

   
    private Actions action;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        action = GameObject.Find("SphereFollower").GetComponent<Actions>();
    }
    void FixedUpdate()
    {

        // Lanzar un rayo desde la cámara hacia adelante
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayo, out hitInfo, Mathf.Infinity, CapaParedes))
        {


            // Debug.Log("paredes " + CapaParedes.value);
            haImpactado = true;
            posicionImpacto = hitInfo.point;

            objetoQueSigue.position = Vector3.Lerp(objetoQueSigue.position, posicionImpacto, 0.5f * Time.deltaTime);
        }


        else if (Physics.Raycast(rayo, out hitInfo, Mathf.Infinity, capaObjetivo))
        {
           

            haImpactado = true;
            posicionImpacto = hitInfo.point;

            objetoQueSigue.position = Vector3.Lerp(objetoQueSigue.position, posicionImpacto, velocidadSeguimiento * Time.deltaTime);
        }

    }
}
