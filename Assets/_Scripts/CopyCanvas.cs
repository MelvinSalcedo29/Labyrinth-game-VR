using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CopyCanvas : MonoBehaviour
{
    public TMP_Text parentTime;
    public TMP_Text pcopyParentTIme;
    public TMP_Text ParentColisiones;
    public TMP_Text pcopyCOlisiones;

    public List<GameObject> Laberintos;

    private int t = 0;

    private void OnEnable()
    {
        print("hola");
        if (pcopyParentTIme != null)
        {
            pcopyParentTIme.text = parentTime.text;
            pcopyCOlisiones.text = ParentColisiones.text;
        }
    }

    public void ui_ChangeNextLevelLaberint(string levelName)
    {
        // t++;
        // if (t > Laberintos.Count - 1)
        //     return;

        // Laberintos[t - 1].SetActive(false);
        // Laberintos[t].SetActive(true);
        SceneManager.LoadScene(levelName);
    }

    public void event_DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }

    public void ui_selectAnyLevels(int positionTemporal)
    {
        SceneManager.LoadScene(positionTemporal.ToString());
    }
}
