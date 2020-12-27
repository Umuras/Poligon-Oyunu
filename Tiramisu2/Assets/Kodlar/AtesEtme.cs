using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtesEtme : MonoBehaviour
{
    public float mermi, sarjor, toplammermi, menzil, hasar1, siradakiates, ateszamani, sayi, zaman, maxzaman;
    public bool ates, reload;
    RaycastHit hit;
    public Text mermiyazi;
    

    AudioSource SesKaynak;
    public AudioClip FireSound;
    
    


    void Start()
    {
        zaman = maxzaman;
        SesKaynak = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        mermiyazi.text = "" + mermi + "/" + toplammermi;

        if(Input.GetKey(KeyCode.S) && mermi > 0 && Time.time > siradakiates && !reload)
        {
            ates = true;
            SesKaynak.Play();
            SesKaynak.clip = FireSound;
            GetComponent<Animation>().Play("ak_ates");
            siradakiates = Time.time + ateszamani;
            mermi--;
            Debug.Log("Ates Edildi");

           

        }
        



        if (Input.GetKeyDown(KeyCode.R) && mermi!=30 && !reload )
        {
            reload = true;
            Debug.Log("Şarjör Dolduruluyor");
        }

        if(reload)
        {
            zaman -= Time.deltaTime;
            if(zaman <= 0)
            {
                zaman = maxzaman;
                reload = false;
                sayi = sarjor - mermi;

                if (sayi >= toplammermi)
                {
                    mermi += toplammermi;
                    toplammermi = 0;
                }
                if (sayi < toplammermi)
                {
                    mermi += sayi;
                    toplammermi -= sayi;
                }
               
            }
        }

    }

     void FixedUpdate()
    {
        if(ates)
        {
            ates = false;
           if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit,menzil))
            {
                if(hit.transform.tag=="dusman")
                {
                    Debug.Log("Hedef isabet etti");
                    if(hit.transform.gameObject.GetComponent<Hedef>().yerde == false)
                    {
                        hit.transform.gameObject.GetComponent<Hedef>().can -= 5;
                    }
                    
                }
                if(hit.transform.tag!="dusman")
                {
                    Debug.Log("Hedefi vuramadın!");
                }
                
            }
        }
    }

    void SarjorBos()
    {
        if (mermi == 0)
        {
            Debug.Log("Şarjör Boş");
        }
    }

}
