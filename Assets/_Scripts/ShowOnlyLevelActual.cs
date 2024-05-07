using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowOnlyLevelActual : MonoBehaviour
{
    public int levelActual = 0;
    public Color color;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        ColorBlock colors = GetComponent<Button>().colors;
        colors.normalColor = color;
        if (SceneManager.GetActiveScene().name == levelActual.ToString())
        {
            Debug.Log(SceneManager.GetActiveScene().name);

            GetComponent<Button>().colors = colors;
        }
    }

    public void LoadSCene(){
        SceneManager.LoadScene(levelActual);
    }
}
