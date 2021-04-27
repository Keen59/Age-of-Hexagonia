using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorMech : MonoBehaviour
{
    public GameObject[] ArayuzElements;
   public List<GameObject> Gens = new List<GameObject>(6);
    public GameObject whichON;
    List<GameObject> Markers = new List<GameObject>(6);
    public GameObject marker;
    bool Moving;
    public bool fighting;
    public string birlikno;
    
  WarriorStats stats;
  
      void Start()
    {
        stats=GetComponent<WarriorStats>();
    
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(4).GetComponent<Text>().text="Man power : "+stats.stats.Manpower;
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text="Movement Speed : "+stats.stats.MoveSpeed;
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text="Strength Speed : "+stats.stats.Strenght;
       
    }
    
    void OnMouseDown() {
        Warrior_War WarScript=GetComponent<Warrior_War>();
        transform.GetChild(1).gameObject.SetActive(true);
        if (fighting)
        {
             WarScript.EnemyClass.mainSound.clip=WarScript.EnemyClass.sounds[1];

                 WarScript.EnemyClass.mainMusicmainSound.clip=WarScript.EnemyClass.sounds[3];
        WarScript.EnemyClass.mainMusicmainSound.Play();
        WarScript.EnemyClass.mainMusicmainSound.loop=false;
        }
        else
        {
             WarScript.EnemyClass.mainSound.clip=WarScript.EnemyClass.sounds[2];
            
        }
       
         WarScript.EnemyClass.mainSound.Play();
    }
    public Text ButtonTXT;
    public void Close_canvas()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        //ArayuzElements[2].SetActive(false);
          Moving=false;
          for (var i = 0; i < Markers.Count; i++)
           {
             if (Markers[i]!=null)
                 {
                     Destroy(Markers[i].gameObject);
                 }
           }
       // ArayuzElements[1].transform.GetComponentInChildren<Text>().text="Choose Work";
        GetComponent<Warrior_War>().EnemyClass.mainSound.clip=null;
          GetComponent<Warrior_War>().EnemyClass.mainMusicmainSound.clip=GetComponent<Warrior_War>().EnemyClass.sounds[5];
    }
    public void movement()
    {
       if (ButtonTXT.text!="Moving")
       {
             if(!Moving)
                {
                    Moving=true;
                    ButtonTXT.text="Cancel";
                    for (var i = 0; i < Gens.Count; i++)
                    {
                        if (Gens[i]!=null)
                        {
                            if (Gens[i].transform.position!=gameObject.transform.position)
                            {
                                if (Gens[i].transform.Find("Marker")==null&&Gens[i].gameObject.GetComponent<AIObjects>().SomeoneOn==false)
                                {
                                      GameObject markerHold= Instantiate(marker,Gens[i].transform);
                                        markerHold.name="Marker";
                                        Markers.Add(markerHold);
                                }
                            }
                        }
                    }
                }
                 else
                {
                    ButtonTXT.text="Move";
                    Moving=false;
                    for (var i = 0; i < Markers.Count; i++)
                    {
                        if (Markers[i]!=null)
                                {
                                    Destroy(Markers[i].gameObject);
                                    Markers[i]=null;
                                }
                    }
                }
       }
        
      
    }
    
     void OnTriggerEnter(Collider other) {
       if (other.tag!="Worker"&&other.tag!="Base"&&other.tag!="Warrior"&&other.tag!="Mountain"&&other.tag!="lake"&&other.tag!="Marker")
        {
        
              
            Gens.Add(other.gameObject);
              
         
           
        }
    }
    
    private void OnTriggerExit(Collider other) {
        Gens.Remove(other.gameObject);
    }
   public Vector3 MovingTo;
   public GameObject MovingObj;
    void ClickToMove()
    {
        if (Moving)
        {
            foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay (touch.position);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast (ray,out hit,1000.0f))
                        {
                            if(hit.collider.tag == "Marker")
                            {       
                                     transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text="Move";
                                      MovingTo=hit.transform.parent.position;
                      
                                  
                                    if (MovingObj!=null)
                                    {
                                     MovingObj.GetComponent<AIObjects>().SomeoneOn=false;
                                        
                                    }
                                    MovingObj=hit.transform.parent.gameObject;
                                    
                                    Moving=false;
                                    for (var i = 0; i < Markers.Count; i++)
                                    {
                                        if (Markers[i]!=null)
                                                {
                                                    Destroy(Markers[i].gameObject);
                                                }
                                    }
                            }
                        }
                    }
                }
        }             
    }
    
   public void MoveTo()
    {
        if (MovingTo!=new Vector3(0,0,0))
        {
            
            ButtonTXT.text="Moving";
            var lookPos = MovingTo - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

          
                 MovingObj.GetComponent<AIObjects>().SomeoneOn=true;
            if (transform.rotation == Quaternion.Slerp(transform.rotation, rotation,stats.stats.MoveSpeed*Time.deltaTime))
                {
                    if (Vector3.Distance(transform.position,MovingTo)>0)
                    {            
                         transform.position=Vector3.MoveTowards(transform.position,MovingTo,stats.stats.MoveSpeed*Time.deltaTime);
                    }
                    else
                    {
                        AttackMove=false;
                        ButtonTXT.text="Move";
                        MovingTo=new Vector3(0,0,0);
                        Moving=false;
                        for (var i = 0; i < Gens.Count; i++)
                        {                  
                            if (Vector3.Distance(Gens[i].transform.position,transform.GetChild(0).position)<1f)
                                {
                                    whichON=Gens[i];
                                    transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
                                }
                        }   
                        for (var i = 0; i < Markers.Count; i++)
                        {
                            if (Markers[i]!=null)
                                    {
                                        Destroy(Markers[i].gameObject);
                                    }
                        }
                    }
            
                 }
                 else
                 {              
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);  
                 }
        }
    }
    public bool AttackMove;
    // Update is called once per frame
    void Update()
    {
      if (MovingObj!=null)
      {
        if (MovingObj.layer==8)
        {
         MoveTo();
         
        }
        else if(AttackMove)
        {
               Vector3 targetDirection = MovingObj.transform.position - transform.position;
        float singleStep = stats.stats.MoveSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        
        }
      }
        ClickToMove();
    }
}
