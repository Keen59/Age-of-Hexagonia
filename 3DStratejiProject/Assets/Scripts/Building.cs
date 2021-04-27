using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{    
    public GameObject[] WorkerOBJ=new GameObject[4];
    public float WorkSpeed;
    public float beklemeSure;
    void Start()
    {
        beklemeSure=0;
    }

    
    void Update()
    {
        beklemeSure+=Time.deltaTime*WorkSpeed;
        if (beklemeSure>=100)
        {
            for (var i = 0; i < WorkerOBJ.Length; i++)
            {
              if (WorkerOBJ[i].name==gameObject.name)
                  {
                    if (WorkerOBJ[i].name=="Stone Mine")
                    {
                      for (var j = 0; j <= 1; j++)
                      {
                        if (transform.parent.GetChild(j).name=="Forest2")
                        {
                          Debug.Log(j);
                          GameObject a= Instantiate(WorkerOBJ[3],transform.parent.transform);
                          a.name="ForestCutDown";
                          a.transform.position=transform.parent.GetChild(j).position;
                          a.transform.localScale=transform.parent.GetChild(j).localScale;
                          Destroy(transform.parent.GetChild(j).gameObject);
                        }
                      }     
                            GameObject Workerobj= Instantiate(WorkerOBJ[i],transform.parent.transform);
                            Workerobj.name=gameObject.name;
                            Workerobj.transform.localScale=new Vector3(0.4f,0.4f,0.4f);
                            Workerobj.transform.localPosition=new Vector3(0.176f,0.631f,-0.176f);
                            Destroy(gameObject);
                    }
                    else  if (WorkerOBJ[i].name=="Farm")
                    {
                      for (var j = 0; j <= 1; j++)
                      {
                          Destroy(transform.parent.GetChild(j).gameObject);
                      }     
                            GameObject Workerobj= Instantiate(WorkerOBJ[i],transform.parent.transform);
                            Workerobj.name=gameObject.name;
                            
                            Workerobj.transform.localPosition=new Vector3(0,0.201f,0);
                            Destroy(gameObject);
                    }
                    else
                    {
                       GameObject Workerobj= Instantiate(WorkerOBJ[i],transform.parent.transform);
                            Workerobj.name=gameObject.name;
                            
                            Workerobj.transform.localPosition=new Vector3(transform.localPosition.x,0.265f,transform.localPosition.z);
                            Destroy(gameObject);
                    }
                  }
            }
        }    
    }
}
