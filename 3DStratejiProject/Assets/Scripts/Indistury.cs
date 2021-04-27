using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indistury : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

     envantory=GameObject.Find("Base").GetComponent<Envantory>();
    }
    
    Envantory envantory;
 
    public int urettigiSay;
    public float beklemeZamanı;
    // Update is called once per frame
    void Update()
    {
        beklemeZamanı+=Time.deltaTime*3;
        if (beklemeZamanı>=100)
        {
            beklemeZamanı=0;
            urettigiSay++;
        }
        if (urettigiSay>=10)
        {
           if (gameObject.tag=="Carpenter")
               envantory.envantory.wood+=urettigiSay;
           else if (gameObject.tag=="Farm")
           envantory.envantory.food+=urettigiSay;
           else if (gameObject.tag=="Stone Mine")
           envantory.envantory.rock+=urettigiSay;
           else if (gameObject.tag=="Gold Mine")
           envantory.envantory.gold+=urettigiSay;

            urettigiSay-=urettigiSay;
        }
    }
}
