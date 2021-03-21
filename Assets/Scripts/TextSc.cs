using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager kullanmak icin
using TMPro; // text mesh pro kullanmak icin

public class TextSc : MonoBehaviour
{
    public TextMeshProUGUI yazi;//textmeshpro kullanimi
    private enum Bolumler {orman, yol_1, yol_2, yol_3, aslan, yilan, nehir, bahce}; //bolumleri belirliyor
    private Bolumler aktifBolum; //aktif olan bolumu tanimliyor

    void Start()
    {
        aktifBolum = Bolumler.orman; //baslangicta orman bolumunden basliyor
    }

    void Update()
    {
        if (aktifBolum==Bolumler.orman) //eger orman bolumu aktif ise bolum_orman methodunu cagiriyor
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
        yazi.text = "Gözlerini karanlýk ve ýssýz bir ormanda açtýn. \nOrmandan çýkmak için önünde 3 yol var:\nBirinci yol için 1'e, ikinci yol için 2'ye, üçüncü yol için 3'e bas!";
        if (Input.GetKeyDown(KeyCode.Alpha1)) // eger 1'e basarsan yol_1 bolumunu cagiriyor
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
        yazi.text = "Birinci yola saptýn ve uzun bir yürüyüþün ardýndan karþýna bir yol ayrýmý çýktý. "+
            "Ilk yolun baþýnda bir aslanýn beklediðini gördün. Ikinci yolun baþýnda ise bir yýlan beklemekte. Ne yapacaksýn?"+
            "\nAslanlý yol için A'ya, yýlanlý yol için Y'ye, geri dönmek için G'ye bas.";
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
        yazi.text = "Bu yolu büyükçe bir kaya kapatmýþ. Geri dönmek için G'ye bas.";
        if (Input.GetKeyDown(KeyCode.G))
        {
            aktifBolum = Bolumler.orman;
        }

    }
    void bolum_yol_3()
    {
        yazi.text = "Karþýna bir yol ayrýmý çýktý. Hem açsýn hem de susuz. Nehre inmek için N'ye, bahçeye týrmanmak için B'ye bas." +
            "Geri dönmek için G'ye bas.";
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
        yazi.text = "Aslana kafa tutacak kadar aptal olduðunu bilmiyordum. Aslan seni bir lokmada yuttu.";
        StartCoroutine(GeciktirKaybet()); 
    }
    void bolum_yilan()
    {
        yazi.text = "Yýlanýn yanýndan geçmeye çalýþýrken yýlan seni farketti ve saldýrýp seni soktu."+
            "Önce felç geçirdin ve acý içinde son nefesini verdin!";
        StartCoroutine(GeciktirKaybet());
    }
    void bolum_nehir()
    {
        yazi.text = "Nehirden kana kana su içtin ve yola devam edecek gücü kendinde buldun. Karanlýk ormandan kurtuldun.";
        StartCoroutine(GeciktirKazan());
    }
    void bolum_bahce()
    {
        yazi.text = "Açlýða dayanýrsýn ama susuzluða o kadar deðil. Karnýný doyurdun ama ormandan çýkamadan susuzluða yenildin.";
        StartCoroutine(GeciktirKaybet());
    }
    IEnumerator GeciktirKaybet() //bolum bitiminde 3 saniye bekleyip kaybetme sahnesini cagiriyor
    {
        yield return new WaitForSeconds(3); //3 sn bekletiyor
        SceneManager.LoadScene("Lose"); //sahne yoneticisi Lose sahnesini yukluyor
    }
    IEnumerator GeciktirKazan()//bolum bitiminde 3 saniye bekleyip kazanma sahnesini cagiriyor
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Win");
    }

}
