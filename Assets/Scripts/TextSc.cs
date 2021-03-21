using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextSc : MonoBehaviour
{
    public TextMeshProUGUI yazi;
    private enum Bolumler {orman, yol_1, yol_2, yol_3, aslan, yilan, nehir, bahce};
    private Bolumler aktifBolum;

    void Start()
    {
        aktifBolum = Bolumler.orman;
    }

    void Update()
    {
        if (aktifBolum==Bolumler.orman)
        {
            bolum_orman();
        }
        else if (aktifBolum == Bolumler.yol_1)
        {
            bolum_yol_1();
        }
        else if (aktifBolum == Bolumler.yol_2)
        {
            bolum_yol_2();
        }
        else if (aktifBolum == Bolumler.yol_3)
        {
            bolum_yol_3();
        }
        else if (aktifBolum == Bolumler.aslan)
        {
            bolum_aslan();
        }
        else if (aktifBolum == Bolumler.yilan)
        {
            bolum_yilan();
        }
        else if (aktifBolum == Bolumler.nehir)
        {
            bolum_nehir();
        }
        else if (aktifBolum == Bolumler.bahce)
        {
            bolum_bahce();
        }
    }

    void bolum_orman()
    {
        yazi.text = "G�zlerini karanl�k ve �ss�z bir ormanda a�t�n. \nOrmandan ��kmak i�in �n�nde 3 yol var:\nBirinci yol i�in 1'e, ikinci yol i�in 2'ye, ���nc� yol i�in 3'e bas!";
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            aktifBolum = Bolumler.yol_1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            aktifBolum = Bolumler.yol_2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            aktifBolum = Bolumler.yol_3;
        }
    }
    
    void bolum_yol_1()
    {
        yazi.text = "Birinci yola sapt�n ve uzun bir y�r�y���n ard�ndan kar��na bir yol ayr�m� ��kt�. "+
            "Ilk yolun ba��nda bir aslan�n bekledi�ini g�rd�n. Ikinci yolun ba��nda ise bir y�lan beklemekte. Ne yapacaks�n?"+
            "\nAslanl� yol i�in A'ya, y�lanl� yol i�in Y'ye, geri d�nmek i�in G'ye bas.";
        if (Input.GetKeyDown(KeyCode.A))
        {
            aktifBolum = Bolumler.aslan;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            aktifBolum = Bolumler.yilan;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            aktifBolum = Bolumler.orman;
        }

    }
    void bolum_yol_2()
    {
        yazi.text = "Bu yolu b�y�k�e bir kaya kapatm��. Geri d�nmek i�in G'ye bas.";
        if (Input.GetKeyDown(KeyCode.G))
        {
            aktifBolum = Bolumler.orman;
        }

    }
    void bolum_yol_3()
    {
        yazi.text = "Kar��na bir yol ayr�m� ��kt�. Hem a�s�n hem de susuz. Nehre inmek i�in N'ye, bah�eye t�rmanmak i�in B'ye bas." +
            "Geri d�nmek i�in G'ye bas.";
        if (Input.GetKeyDown(KeyCode.N))
        {
            aktifBolum = Bolumler.nehir;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            aktifBolum = Bolumler.bahce;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            aktifBolum = Bolumler.orman;
        }
    }
    void bolum_aslan()
    {
        yazi.text = "Aslana kafa tutacak kadar aptal oldu�unu bilmiyordum. Aslan seni bir lokmada yuttu.";
        StartCoroutine(GeciktirKaybet());
    }
    void bolum_yilan()
    {
        yazi.text = "Y�lan�n yan�ndan ge�meye �al���rken y�lan seni farketti ve sald�r�p seni soktu."+
            "�nce fel� ge�irdin ve ac� i�inde son nefesini verdin!";
        StartCoroutine(GeciktirKaybet());
    }
    void bolum_nehir()
    {
        yazi.text = "Nehirden kana kana su i�tin ve yola devam edecek g�c� kendinde buldun. Karanl�k ormandan kurtuldun.";
        StartCoroutine(GeciktirKazan());
    }
    void bolum_bahce()
    {
        yazi.text = "A�l��a dayan�rs�n ama susuzlu�a o kadar de�il. Karn�n� doyurdun ama ormandan ��kamadan susuzlu�a yenildin.";
        StartCoroutine(GeciktirKaybet());
    }
    IEnumerator GeciktirKaybet()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Lose");
    }
    IEnumerator GeciktirKazan()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Win");
    }

}
