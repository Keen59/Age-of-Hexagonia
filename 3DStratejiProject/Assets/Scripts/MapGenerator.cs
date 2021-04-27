using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //map objeleri
    public GameObject[] Mapobjects;
    public GameObject Sea;
    public GameObject seaTrans;
    //mapte var olan nesneler
    public GameObject[] InmapObjects;
    public int[,] ObjSayisi=new int[3,3];
    public float tileX=1f;
    public float tileZ=0.86f;
    public int height=10;

    public int width=5;
    
    void Start()
    {
        ObjSayisi[0,0]=0;
        ObjSayisi[0,1]=0;
        ObjSayisi[0,2]=0;
        MapGen();
      
    }

    public void MapGen()
    {
            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {


                    //4,4 ve 20,20 arası land dışı su
                    if (i>=5&&j<=25&&i<=25&&j>=5)
                    {
                        
                        tekrar:

                        int randsay=Random.Range(0,4);
                        if (Mapobjects[randsay].name=="Mountain"&&ObjSayisi[0,0]<20||ObjSayisi[0,1]<10&&Mapobjects[randsay].name=="Lake Variant")
                        {
                            
                               if (j==Random.Range(0,width))
                               {
                                   if (Mapobjects[randsay].name=="Mountain")
                                {
                                    ObjSayisi[0,0]++;
                                }
                                else if(Mapobjects[randsay].name=="Lake Variant")
                                {
                                    ObjSayisi[0,1]++;
                                }

                                GameObject CreatedObject=Instantiate(Mapobjects[randsay]);
                            
                                if (j%2==0)
                                {
                                    CreatedObject.transform.position=new Vector3(i*tileX,0,j*tileZ);
                                }
                                else
                                {
                                    CreatedObject.transform.position=new Vector3(i*tileX+tileX/2,0,j*tileZ);
                                }

                                setinfo(CreatedObject,i,j,"");

                               }
                               else
                               {
                                   goto tekrar;
                               }
                                 

                                
                        }
                        else if(Mapobjects[randsay].name!="Mountain"||Mapobjects[randsay].name!="Lake Variant")
                        {   
                            if (Mapobjects[randsay].name=="Gold"&&ObjSayisi[0,2]<20)
                            {
                                if (j==Random.Range(0,width))
                               {
                                    GameObject CreatedObject=Instantiate(Mapobjects[randsay]);
                                    ObjSayisi[0,2]++;
                                    if (j%2==0)
                                    {
                                        CreatedObject.transform.position=new Vector3(i*tileX,0,j*tileZ);
                                    }
                                    else
                                    {
                                        CreatedObject.transform.position=new Vector3(i*tileX+tileX/2,0,j*tileZ);
                                    }

                                    setinfo(CreatedObject,i,j,"");
                               }
                               else
                               {
                                   goto tekrar;
                               }
                            }
                            else 
                            {
                                GameObject CreatedObject=Instantiate(Mapobjects[1]);
                            
                                if (j%2==0)
                                {
                                    CreatedObject.transform.position=new Vector3(i*tileX,0,j*tileZ);
                                }
                                else
                                {
                                    CreatedObject.transform.position=new Vector3(i*tileX+tileX/2,0,j*tileZ);
                                }

                                setinfo(CreatedObject,i,j,"");
                            }
                               
                        }
                        else if (Mapobjects[randsay].name=="Mountain"&&ObjSayisi[0,0]>=20||ObjSayisi[0,1]>=5&&Mapobjects[randsay].name=="Lake Variant")
                        {
                            goto tekrar;
                        }
                           /*tekrar:
                        int randsay=Random.Range(0,4);
                        if (ObjSayisi[0,0]<=20||ObjSayisi[0,1]<=5||Mapobjects[randsay].name!="Lake Variant"&&Mapobjects[randsay].name!="Mountain")
                        {

                              if (Mapobjects[randsay].name=="Mountain")
                                {
                                    ObjSayisi[0,0]++;
                                }
                                else if(Mapobjects[randsay].name=="Lake Variant")
                                {
                                    ObjSayisi[0,1]++;
                                }

                            GameObject CreatedObject=Instantiate(Mapobjects[randsay]);
                        
                            if (j%2==0)
                            {
                                CreatedObject.transform.position=new Vector3(i*tileX,0,j*tileZ);
                            }
                            else
                            {
                                CreatedObject.transform.position=new Vector3(i*tileX+tileX/2,0,j*tileZ);
                            }

                            setinfo(CreatedObject,i,j,"");

                        }
                        else if (Mapobjects[randsay].name=="Mountain"&&ObjSayisi[0,0]>=20||ObjSayisi[0,1]>=5&&Mapobjects[randsay].name=="Lake Variant")
                        {
                                
                            goto tekrar;
                        }*/
                    }
                    else 
                    {
                        GameObject CreatedObject=Instantiate(Sea);
                        if (j%2==0)
                        {
                            CreatedObject.transform.position=new Vector3(i*tileX,0,j*tileZ);
                        }
                        else
                        {
                        CreatedObject.transform.position=new Vector3(i*tileX+tileX/2,0,j*tileZ);

                        }
                        setinfo(CreatedObject,i,j,"su");
                    }
                }
            }
    }
   
    void setinfo(GameObject obj,int i,int j,string ad)
    {
        obj.transform.parent=transform;
        obj.name=i.ToString()+","+j.ToString()+ad;
    }
   
    void Update()
    {
        
    }
}
