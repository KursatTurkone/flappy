using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class anamenu : MonoBehaviour
{
    public Text yuksekpuantext;
    public Text sonpuan;
    void Start()
    {
        int enyuksekskor = PlayerPrefs.GetInt("EnYuksekPuan");
        int ensonpuan = PlayerPrefs.GetInt("puanKayit");
        int reklamsayaci = PlayerPrefs.GetInt("reklamSayaci");
     //  int enyuksekpuan = PlayerPrefs.GetInt("puanKayit");
        yuksekpuantext.text = "en yuksek puan : " + enyuksekskor;
        sonpuan.text = "En son puan: " + ensonpuan;
      
        if (reklamsayaci == 3)
        {
            GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGoster();
            PlayerPrefs.SetInt("reklamSayaci", 0);
        }
    }

   
    void Update()
    {
        
    }
   public void oyunagir()
    {
        SceneManager.LoadScene("oyun");
    }
   public void oyundancik()
    {
        Application.Quit();
    }
}
