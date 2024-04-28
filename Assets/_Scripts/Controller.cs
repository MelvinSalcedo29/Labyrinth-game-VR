using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public TMP_Text timer;
    public float tiempoTotal = 0; // Tiempo total en segundos
    public GameObject gameObject_Entrada; // Tiempo total en segundos
    public bool bool_iniciarTimer = false;

    void Start()
    {
        // Iniciar el temporizador

        StartCoroutine(intermitente());
    }

    public void InciarTimer()
    {
        bool_iniciarTimer = true;
        StartCoroutine(ContadorRegresivo());
    }

    public void ResetBoolTimer(bool b)
    {
        bool_iniciarTimer = b;
    }


    IEnumerator ContadorRegresivo()
    {

        while (bool_iniciarTimer == true)
        {
            tiempoTotal++;
            timer.text = tiempoTotal.ToString();
            // Esperar un frame
            yield return new WaitForSeconds(1f);

        }

        // Hacer algo cuando el tiempo haya transcurrido
        Debug.Log("¡Tiempo agotado!");
    }

    IEnumerator intermitente()
    {
        while (true)
        {
            gameObject_Entrada.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(.51f);
            gameObject_Entrada.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(.51f);

        }
    }

}
