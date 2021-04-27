using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
        
         private void OnTriggerStay(Collider other) {
            other.gameObject.layer=8;
            
            for (var i = 0; i < other.transform.childCount; i++)
            {
                other.transform.GetChild(i).gameObject.layer=8;
            }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
