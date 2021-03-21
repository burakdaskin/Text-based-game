using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolumYoneticisi : MonoBehaviour
{
    public void BolumAc(string BolumIsmi) //buton komponentine OnClick icinde atanan script 
    {
        SceneManager.LoadScene(BolumIsmi);
    }
    public void Cikis() //cikis tiklayinca oyundan cikiyor
    {
        Application.Quit();
    }
}
