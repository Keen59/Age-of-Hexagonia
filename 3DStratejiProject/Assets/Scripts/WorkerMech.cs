using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerMech : MonoBehaviour
{
    public GameObject WorkerCanvas;
    public GameObject Building;
    public GameObject marker;
    bool MovementControl;
    public bool Moving;
    bool working;
    public GameObject[] ArayuzElements;
  public List<GameObject> Gens = new List<GameObject>(6);
public GameObject whichON;
    List<GameObject> Markers = new List<GameObject>(6);

    public bool WorkerBuilded;
     WorkerStats stats;
       /// <summary>
  /// 5 farklı tier olucak yeşilden kırmızıya 
  ///doğru her seferinde sayı ve gücü artıcak birliklerin
  /// </summary>
    void Start()
    {
        stats=GetComponent<WorkerStats>();
    
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(4).GetComponent<Text>().text="Man power : "+stats.stats.Manpower;
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text="Movement Speed : "+stats.stats.MoveSpeed;
        transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text="Work : "+stats.stats.WorkSpeed;
         /*if (whichON==null)
                {
                    transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
                }   */
    }
    
    void OnMouseDown() {
        WorkerCanvas.SetActive(true);
    }
    public Text ButtonTXT;
    public void Close_canvas()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        ArayuzElements[2].SetActive(false);
          Moving=false;
          for (var i = 0; i < Markers.Count; i++)
           {
             if (Markers[i]!=null)
                 {
                     Destroy(Markers[i].gameObject);
                 }
           }
        ArayuzElements[1].transform.GetComponentInChildren<Text>().text="Choose Work";
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
       if (other.tag!="Worker"&&other.tag!="Base"&&other.tag!="Warrior"&&other.tag!="Mountain"&&other.tag!="lake"&&other.tag!="Marker"&&other.tag!="Carpenter"&&other.tag!="Stone Mine"&&other.tag!="Gold Mine"&&other.tag!="Farm")
        {
          if (other.gameObject.layer==8)
          {
   
                    Gens.Add(other.gameObject);

          }  
           
        }
    }
    
    private void OnTriggerExit(Collider other) {
        Gens.Remove(other.gameObject);
    }
   
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
    
    public void Workin()
    {
        if (ButtonTXT.text!="Moving")
        {
            if (whichON!=null)
            {
                
                if (ArayuzElements[1].transform.GetComponentInChildren<Text>().text!="Cancel Work")
                {
                    ArayuzElements[2].SetActive(true);
                    ArayuzElements[1].transform.GetComponentInChildren<Text>().text="Cancel Work";

                    
                    if (whichON.tag=="Forest")
                    { 
                        transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
                        for (var i = 0; i < 3; i++)
                        {
                            transform.GetChild(1).GetChild(1).GetChild(i).gameObject.SetActive(true);
                        }
                        transform.GetChild(1).GetChild(1).GetChild(3).gameObject.SetActive(false);
                    }
                    else if(whichON.tag=="Gold")
                    {
                        transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
                        for (var i = 0; i < 3; i++)
                        {
                            transform.GetChild(1).GetChild(2).GetChild(i).gameObject.SetActive(false);
                        }
                        transform.GetChild(1).GetChild(2).GetChild(3).gameObject.SetActive(true);
                    }
                    else
                    {
                        transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
                    }
            
                }
                else
                {
                ArayuzElements[2].gameObject.SetActive(false);
                ArayuzElements[1].transform.GetComponentInChildren<Text>().text="Choose Work";
                
                }
            }
              
        }
    }
    GameObject BuildinOBJ;
    public void WorkinOn(Text whichWork_txt)
    {
        if (!whichON.GetComponent<AIObjects>().builded)
        {
             ArayuzElements[1].transform.GetComponentInChildren<Text>().text="Choose Work";
            BuildinOBJ=Instantiate(Building,whichON.transform);
            Building.transform.localScale=new Vector3(0.194603f,0.194603f,0.194603f);
            Building.transform.localPosition=new Vector3(whichON.transform.GetChild(0).transform.localPosition.x,0.203f,whichON.transform.GetChild(0).transform.localPosition.z);
            Destroy(whichON.transform.GetChild(0).gameObject);
            BuildinOBJ.GetComponent<Building>().WorkSpeed=stats.stats.WorkSpeed;
            BuildinOBJ.name=whichWork_txt.text;
            ArayuzElements[2].gameObject.SetActive(false);
            working=true;
            whichON.GetComponent<AIObjects>().builded=true;
        }
       
    }
   public Vector3 MovingTo;
   GameObject MovingObj;
    void MoveTo()
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
                    
                         transform.position=Vector3.MoveTowards(transform.position,MovingTo,0.5f*Time.deltaTime);
                       
                    }
                    else
                    {
                        
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
    // Update is called once per frame
    
    void Update()
    {
        ClickToMove();
        if (working)
        {
            if (BuildinOBJ!=null)
            {
                    if (BuildinOBJ.GetComponent<Building>().beklemeSure<100)
                    {                     
                        ArayuzElements[3].transform.GetChild(0).GetComponent<Image>().fillAmount=BuildinOBJ.GetComponent<Building>().beklemeSure/100;
                        ArayuzElements[3].transform.GetChild(2).GetComponent<Text>().text=BuildinOBJ.name+" Being built:"+System.Convert.ToInt32(BuildinOBJ.GetComponent<Building>().beklemeSure).ToString()+"%";
                        ArayuzElements[3].SetActive(true);
                        ArayuzElements[1].SetActive(false);
                        ArayuzElements[0].SetActive(false);
                    }
            }
            else
            {
                ArayuzElements[3].SetActive(false);
                ArayuzElements[1].SetActive(true);
                ArayuzElements[0].SetActive(true); 
                working=false;
            }
        }  
        MoveTo();
    }
}
