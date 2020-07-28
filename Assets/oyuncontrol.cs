using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncontrol : MonoBehaviour
{
    public GameObject gokyuzubir;
    public GameObject gokyuzuiki ;
    public float arkaPlanHiz = 1.5f;
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    float uzunluk = 0;
    public GameObject engel;
    public int kacAdetEngel;
    GameObject []engeller;
    int sayac=0;
    bool oyunsonu = true;

    float engelzaman = 0;
    void Start()
    {
        fizik1 = gokyuzubir.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzuiki.GetComponent<Rigidbody2D>();

        fizik1.velocity = new Vector2(-arkaPlanHiz,0);
        fizik2.velocity = new Vector2(-arkaPlanHiz, 0);
        uzunluk = gokyuzubir.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[kacAdetEngel];
        for(int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
           Rigidbody2D fizikengeller= engeller[i].AddComponent<Rigidbody2D>();
            fizikengeller.gravityScale = 0;
            fizikengeller.velocity = new Vector2(-arkaPlanHiz,0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunsonu)
        {
            if (gokyuzubir.transform.position.x <= -uzunluk)
            {
                gokyuzubir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzuiki.transform.position.x <= -uzunluk)
            {
                gokyuzuiki.transform.position += new Vector3(uzunluk * 2, 0);
            }
            //******************
            engelzaman += Time.deltaTime;
            if (engelzaman > 2f)
            {
                engelzaman = 0;
                float yeksenim = Random.Range(-0.50f, 1.12f);
                engeller[sayac].transform.position = new Vector3(18, yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }
        }
        else
        {
            
        }
      
    }
   public void oyunbitti()
    {
        for(int i=0;i< engeller.Length; i++)
        {

            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
        oyunsonu = false;
    }
}
