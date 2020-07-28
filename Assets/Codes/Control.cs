using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Sprite []Bird;
    SpriteRenderer spriteRenderer;
    bool ilerigeriKontrol = true;
    int Sayac = 0;
    float AnimasyonHiz = 0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puantext;

    bool oyunbitti = true;

    oyuncontrol oyuncontrol ;
    AudioSource[] sesler;
    int EnYuksekPuan = 0;
    int reklamsayaci = 0;
   
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyuncontrol = GameObject.FindGameObjectWithTag("oyuncontrol").GetComponent<oyuncontrol>() ;
        sesler = GetComponents<AudioSource>();
        EnYuksekPuan = PlayerPrefs.GetInt("EnYuksekPuan");

        //reklamlar
        reklamsayaci = PlayerPrefs.GetInt("reklamSayaci");
        reklamsayaci++;
        PlayerPrefs.SetInt("reklamSayaci", reklamsayaci);
        Debug.Log(reklamsayaci);
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&oyunbitti)
        {
            fizik.velocity = new Vector2(0,0);
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
            
        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0,0,45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animasyon();
    }
    void Animasyon()
    {
        AnimasyonHiz += Time.deltaTime;
        if (AnimasyonHiz > 0.1f)
        {
            AnimasyonHiz = 0;
            if (ilerigeriKontrol)
            {
                spriteRenderer.sprite = Bird[Sayac];
                Sayac++;
                if (Sayac == Bird.Length)
                {
                    Sayac--;
                    ilerigeriKontrol = false;
                }
            }
            else
            {
                Sayac--;
                spriteRenderer.sprite = Bird[Sayac];

                if (Sayac == 0)
                {
                    Sayac++;
                    ilerigeriKontrol = true;
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puan")
        {
            puan++;
            puantext.text = "puan = " + puan;
            sesler[1].Play();

        }
        if (collision.gameObject.tag == "engel")
        {
            oyunbitti = false;
            sesler[2].Play();
            oyuncontrol.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;
        
        if (puan > EnYuksekPuan)
        {
            EnYuksekPuan = puan;
            PlayerPrefs.SetInt("EnYuksekPuan", EnYuksekPuan);
        }
            Invoke("anaMenuyeDon", 2);
        }
    
    }
    void anaMenuyeDon()
    {
      PlayerPrefs.SetInt("puanKayit", puan);
        SceneManager.LoadScene("anamenu");
        
    }
    
}
