using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukTop : MonoBehaviour
{

    LineRenderer cizgi;

    bool durduMu = false;

    Rigidbody2D rigi;

    Transform anaDaire;

    yonetici yonetici;


    private void Start()
    {
        cizgi = GetComponent<LineRenderer>();
        rigi = GetComponent<Rigidbody2D>();

        anaDaire = GameObject.Find("anadaire").transform;

        yonetici = GameObject.FindObjectOfType<yonetici>();
    }


    private void Update()
    {
        if (durduMu == true)
        {
            cizgi.SetPosition(0, anaDaire.position);
            cizgi.SetPosition(1, transform.position);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == anaDaire.name)
        {
            rigi.velocity = Vector2.zero;

            Vector2 yeniPos = transform.position;

            yeniPos.y = (anaDaire.transform.position.y - anaDaire.GetComponent<CircleCollider2D>().bounds.size.y) * 1.5f;
            transform.position = yeniPos;
            transform.SetParent(anaDaire.transform);
            durduMu = true;
            yonetici.ToplarinPozisyonlariniGuncelle();
        }
        else if(collision.gameObject.tag=="kucukTop")
        {
            yonetici.Kaybettin();
        }
    }


}
