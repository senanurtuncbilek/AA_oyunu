using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{

    [SerializeField]
    GameObject kazandinPNL, kaybettinPNL;



    public void KazandinPNL_goster()
    {
        kazandinPNL.SetActive(true);
    }


    public void KaybettinPNL_goster()
    {
        kaybettinPNL.SetActive(true);
    }


    public void DevamEtBTN()
    {
        int simdikilvl = PlayerPrefs.GetInt("level");

        simdikilvl++;

        PlayerPrefs.SetInt("level", simdikilvl);

        SceneManager.LoadScene(0);
    }

    public void TekrarEtBTN()
    {

        SceneManager.LoadScene(0);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
