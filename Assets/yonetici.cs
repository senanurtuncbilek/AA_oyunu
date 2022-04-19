using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class yonetici : MonoBehaviour
{
    public GameObject topPrefab;
    int toplamTopSayisi;
    List<Rigidbody2D> tumToplar = new List<Rigidbody2D>();

    float hiz = 20f;

    float ilkTopunYPozisyonu = -3f;

    [SerializeField]
    TextMeshProUGUI level_txt;

    int level;


    ui ui;

    void Start()
    {

        ui = GameObject.FindObjectOfType<ui>();

        levelKontrol();

        ilkToplariEkle();



    }


    void levelKontrol()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }

        level_txt.text = level.ToString();
    }


    void ilkToplariEkle()
    {
        toplamTopSayisi = level * 3;

        for (int i = 0; i < toplamTopSayisi; i++)
        {

            GameObject yeniTop = Instantiate(topPrefab);

            if (i == 0)
            {
                yeniTop.transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                yeniTop.transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }

            yeniTop.GetComponentInChildren<TextMeshProUGUI>().text = (toplamTopSayisi - i).ToString();
            tumToplar.Add(yeniTop.GetComponent<Rigidbody2D>());

        }

    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) && tumToplar.Count > 0)
        {
            tumToplar[0].velocity = Vector2.up * hiz;
            tumToplar.RemoveAt(0);
           
        }else if (tumToplar.Count <= 0)
        {
            Kazandin();
        }
    }


    public void ToplarinPozisyonlariniGuncelle()
    {
        for(int i = 0; i < tumToplar.Count; i++)
        {
            if (i == 0)
            {
                tumToplar[i].transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                tumToplar[i].transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }
        }
    }

    void Kazandin()
    {
        ui.KazandinPNL_goster();

        this.enabled = false;
    }

public void Kaybettin()
    {
        ui.KaybettinPNL_goster();

        this.enabled = false;
    }

}
