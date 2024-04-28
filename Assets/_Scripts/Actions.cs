using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Actions : MonoBehaviour
{
    public TMP_Text text_choques;
    public GameObject gameObject_trailRenderer;
    // public GameObject gameObject_entrada;
    // public GameObject gameObject_salida;
    public Controller controller;
    public GameObject CanvasMensajes;
    public Animator AnimatorCanvasMesajes;
    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip audioClipError;
    public AudioClip audioClipBeginGame;
    public AudioClip audioClipEndGame;
    public AudioClip audioClipErrorPassPared;

    private TrailRenderer trailRenderer;

    int count = 0;
    [SerializeField] private bool VerficarColiderEntrada = false;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>

    private Vector3 positionInitial;
    private Vector3 positionNext;
    private bool boolFirstCollision = false;

    private void Start()
    {
        trailRenderer = this.gameObject.transform.GetChild(0).GetComponentInChildren<TrailRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "pared" && VerficarColiderEntrada == true)
        {
            count++;
            text_choques.text = count.ToString();
            audioSource.PlayOneShot(audioClipError);

            if (boolFirstCollision == false)
            {
                positionInitial = transform.position;
                boolFirstCollision = true;
            }


        }
        if (other.name == "Colliders_entrada" && VerficarColiderEntrada == false)
        {
            trailRenderer.time = 999;
            audioSource.PlayOneShot(audioClipBeginGame);
            VerficarColiderEntrada = true;
            controller.InciarTimer();
            gameObject_trailRenderer.SetActive(true);
            text_choques.gameObject.SetActive(true);
            // gameObject_entrada.gameObject.SetActive(false);
            text_choques.text = "0";
            controller.timer.text = "0";
            count = 0;
            Debug.Log("entrada");

        }
        if (other.name == "Colliders_salida" && VerficarColiderEntrada == true)
        {
            audioSource.PlayOneShot(audioClipEndGame);
            VerficarColiderEntrada = false;
            CanvasMensajes.SetActive(true);
            AnimatorCanvasMesajes.Play("openWindows");

            gameObject_trailRenderer.SetActive(false);

            // gameObject_salida.gameObject.SetActive(true);
            // gameObject_entrada.gameObject.SetActive(true);

            controller.tiempoTotal = 0;
            count = 0;
            // text_choques.text = "0";
            // controller.timer.text = "0";
            controller.ResetBoolTimer(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "pared" && VerficarColiderEntrada == true)
        {
            if (boolFirstCollision == true)
            {
                positionNext = transform.position;
                Debug.Log(Vector3.Distance(positionInitial, positionNext));
                if (Vector3.Distance(positionInitial, positionNext) < 0.01938382f)
                {

                    Debug.Log("pared chocada");
                }
                else
                {
                    audioSource.PlayOneShot(audioClipErrorPassPared);

                    Debug.Log("pared atravesada");
                    Sum20Pounts();

                }
            }
            boolFirstCollision = false;
        }

        if (other.name == "Collider CampoJuego" && VerficarColiderEntrada == true)
        {
            trailRenderer.Clear();
            gameObject_trailRenderer.SetActive(false);

            VerficarColiderEntrada = false;

            controller.tiempoTotal = 0;
            count = 0;
            text_choques.text = "0";
            controller.timer.text = "0";
            controller.ResetBoolTimer(false);
        }
        if (other.name == "Colliders_salida" && VerficarColiderEntrada == true)
        {
            trailRenderer.Clear();
            VerficarColiderEntrada = false;

            text_choques.text = "0";
            controller.timer.text = "0";

            count = 0;
        }
    }

    int contadorSUmaColiionPared = 0;
    public GameObject mensajeReiniciar_Nivel;

    public void Sum20Pounts()
    {

        if (contadorSUmaColiionPared >= 1)
        {
            mensajeReiniciar_Nivel.SetActive(true);
        }
        contadorSUmaColiionPared++;
    }
    public void ui_reloadLEvel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
