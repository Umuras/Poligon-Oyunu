using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahDegistirme : MonoBehaviour
{
    public string[] silahEnv;
    public GameObject[] silahListe;
    public int suankiSilah;
    public bool Silah1, Silah2;
    void Start()
    {
        suankiSilah = 0;
        SilahDegistir(silahEnv[suankiSilah]);
        Debug.Log("AK47 Secildi");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && suankiSilah != 0 && silahEnv[0] != string.Empty)
        {
            SilahDegistir(silahEnv[0]);
            suankiSilah = 0;
            Debug.Log("AK47 Secildi");
            
        }

        else if (Input.GetKeyDown(KeyCode.Space) && suankiSilah != 1 && silahEnv[1] != string.Empty)
        {
            SilahDegistir(silahEnv[1]);
            suankiSilah = 1;
            Debug.Log("Desert Eagle Secildi");
             
        }
       
       
    }

    public void SilahDegistir(string silahismi)
    {
        for(int i = 0; i < silahListe.Length; i++)
        {
            if(silahListe[i].name == silahismi)
            {
                silahListe[i].gameObject.SetActive(true);
            }
            else
            {
                silahListe[i].gameObject.SetActive(false);
            }
        }
    }
}
