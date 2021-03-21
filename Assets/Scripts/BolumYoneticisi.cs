using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolumYoneticisi : MonoBehaviour
{
    public void BolumAc(string BolumIsmi)
    {
        SceneManager.LoadScene(BolumIsmi);
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
