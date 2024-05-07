using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Ui_system : MonoBehaviour
{
    public void ui_closeGame()
    {
        Application.Quit();
    }
    public void ui_LoadLevelGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
