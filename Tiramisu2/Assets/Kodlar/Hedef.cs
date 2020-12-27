using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedef : MonoBehaviour
{
    public float can;
    public bool yerde;
    public GameObject canbar;
    void Start()
    {
        
    }

    
    void Update()
    {
        canbar.transform.localScale = new Vector3(1, can/100, 1);

        if(can <= 0 && yerde == false)
        {
            yerde = true;
            can = 0;
            GetComponent<Animation>().Play("DusmanYerde");
        }
        if(yerde)
        {
            if(Input.GetKey(KeyCode.T))
            {
                yerde = false;
                GetComponent<Animation>().Play("DusmanAyakta");
                can = 100;
                Debug.Log("Hedefin Canı Doldu");
            }
            if (can == 0)
            {
                Debug.Log("Hedef Öldü");
            }

        }
        
    }
}
