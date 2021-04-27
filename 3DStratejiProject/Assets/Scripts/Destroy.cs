using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        


    }
    public void Close()
    {
        transform.parent.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Worker"&&other.tag!="Warrior"&&other.tag!="Selection"&&other.tag!="Base")
        {
       
         Destroy(other.gameObject);    
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
