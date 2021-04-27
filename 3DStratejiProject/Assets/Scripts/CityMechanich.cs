using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityMechanich : MonoBehaviour
{
    public GameObject CityArayuz;
    public float CreatingSpeed;
    public float WorkerSpeed;
    public float WorkSpeed;
    
    public float warriorStrength;
    
    public float WarriorMspeed;
    public GameObject WorkerObj;
    public GameObject WarriorObj;
    public Image loadingbar;
    public GameObject ArmyPart;
    public Text uretilen_txt;
    void Start()
    {
        CreatingSpeed=5;
    }
    bool CreatingControl;
    public Button cancelButton;
    public void Create(GameObject clickedButton)
    {
         if (gameObject.GetComponent<Envantory>().envantory.worker<gameObject.GetComponent<Envantory>().envantory.workerMAX&&clickedButton.name=="Worker"&&gameObject.GetComponent<Envantory>().envantory.food>=100||clickedButton.name=="Warrior"&&gameObject.GetComponent<Envantory>().envantory.food>=50&&gameObject.GetComponent<Envantory>().envantory.wood>=20&&gameObject.GetComponent<Envantory>().envantory.warrior<gameObject.GetComponent<Envantory>().envantory.warriorMAX)
        {
        CreatingControl=true;
        Name=clickedButton.name;

        }
        else
        {
     clickedButton.GetComponent<Animator>().SetTrigger("redac");
        }
    }
    public void armyPart()
    {
        if (ArmyPart.activeSelf)
        {
            ArmyPart.SetActive(false);
        }
        else
        {
            ArmyPart.SetActive(true);
        }
    }
    string Name;
    public float sure;
    public void Cancel_produce()
    {
        CreatingControl=false;
        sure=0;
        uretilen_txt.text=null;
        loadingbar.GetComponent<Image>().fillAmount=0;
        cancelButton.GetComponent<Button>().interactable=false;
    }
    
    public void Create_current(float Speed,string ObjectName)
    {
       
            
    
                sure+=Time.deltaTime*Speed;
                cancelButton.GetComponent<Button>().interactable=true;
                loadingbar.GetComponent<Image>().fillAmount=sure/100;
                uretilen_txt.text="Produce:"+ObjectName;
                if (sure>=100)
                {   
                    GameObject Objects;
                    if (ObjectName=="Worker")
                    {
                        Objects=Instantiate(WorkerObj);  
                        Objects.GetComponent<WorkerStats>().stats.WorkSpeed=WorkSpeed;
                        Objects.GetComponent<WorkerStats>().stats.WorkSpeed=WorkerSpeed;
                        gameObject.GetComponent<Envantory>().envantory.food-=100;
                                 gameObject.GetComponent<Envantory>().envantory.worker++;
                    }
                    else
                    {
                        Objects=Instantiate(WarriorObj);  
                        Objects.GetComponent<WarriorStats>().stats.Strenght=warriorStrength;
                        Objects.GetComponent<WarriorStats>().stats.MoveSpeed=WarriorMspeed;
                       
                        gameObject.GetComponent<Envantory>().envantory.wood-=20;
                        gameObject.GetComponent<Envantory>().envantory.warrior++;
                        gameObject.GetComponent<Envantory>().envantory.food-=50;
                    }                              
                        cancelButton.GetComponent<Button>().interactable=false;
                        Objects.gameObject.name=ObjectName;
                        Objects.transform.position=transform.position;     
                        sure=0;
                        CreatingControl=false;  
                        loadingbar.GetComponent<Image>().fillAmount=0;
                }
        
    }

    void OnMouseDown()
     {
        CityArayuz.SetActive(true);    
     }

    void Update()
    {
        if (CreatingControl)
        {
            Create_current(CreatingSpeed,Name);
        }
    }
}
