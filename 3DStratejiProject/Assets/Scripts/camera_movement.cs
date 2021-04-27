using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    
   
        
   
public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
     void FixedUpdate() {
       
          
                if (Input.touchCount == 1) 
                {
                     Vector2 desiredMove = new Vector2();
           
                    Touch currentTouch = Input.GetTouch(0);
                    
        
                    if (currentTouch.phase==TouchPhase.Moved)
                    {
                 
                     desiredMove=currentTouch.deltaPosition;
                     transform.Translate(-desiredMove.x*speed,0,-desiredMove.y*speed);
                     transform.position=new Vector3(
                        Mathf.Clamp(transform.position.x,minX,maxX),
                        7.23f,
                        Mathf.Clamp(transform.position.z,minY,maxY)


                     );
                    }
                }  
      
    }
     void Awake() {
         
         
    }
}
