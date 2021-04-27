using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Warrior_War : MonoBehaviour
{
    [System.Serializable]
   public class enemy
   {
       public GameObject Samurai;
      /* public TMPro.TextMeshProUGUI[] StatTexts;*/
      public GameObject[] StatTexts;
      public AudioClip[] sounds;
      public AudioSource mainSound;
      public AudioSource mainMusicmainSound;
     public List<float> Stats=new List<float>();
      
       public void EnemyObject(WarriorStats warriorStats,float DefPow,int Manpower,int tier,GameObject MovinTo,float luck)
       {
         
           StatTexts[0].transform.parent.gameObject.SetActive(true);
         
           
           Stats.Add(tier);
           Stats.Add(Manpower);
           Stats.Add(DefPow);
          
         Stats.Add(warriorStats.stats.Tier);
            Stats.Add(warriorStats.stats.Manpower);
            Stats.Add(warriorStats.stats.DefensePower);
            Stats.Add(luck);
            Stats.Add(warriorStats.stats.luck);
          
                for (int j = 0; j < 3; j++)
                {
                    StatTexts[0].transform.GetChild(j).GetComponent<TMPro.TextMeshProUGUI>().text=StatTexts[0].transform.GetChild(j).name+":"+Stats[j].ToString();
               
                }
                for (int i = 0; i < 3; i++)
                {
                    StatTexts[1].transform.GetChild(i).GetComponent<TMPro.TextMeshProUGUI>().text=StatTexts[1].transform.GetChild(i).name+":"+Stats[i+3].ToString();

                }
           
       }
       
 

      public void EnemyObjectSpawn(GameObject MovinTo,GameObject thisobject)
       {
           
          GameObject gameObjectTut=  Instantiate(Samurai,MovinTo.transform);
            gameObjectTut.name="EnemySamurai";
          gameObjectTut.transform.localPosition=new Vector3(0,0.6f,0);
        Vector3 targetDirection = gameObjectTut.transform.position - thisobject.transform.position;
        float singleStep = 1 * Time.deltaTime;
         Vector3 newDirection = Vector3.RotateTowards(gameObjectTut.transform.forward, targetDirection, singleStep, 0.0f);
       gameObjectTut.transform.rotation = Quaternion.LookRotation(newDirection);
       gameObjectTut.GetComponent<Animator>().Play("SamuraiAttack");
        
      
       mainSound.clip=sounds[1];
        mainSound.Play();
       }
   
   }

   [System.Serializable]
       public class Figting
       {

           public Image EnemyAndUs;
           public float fightingTime;
           public string winlose;
           public GameObject[] StatTexts;
           public List<float> enemyarmy=new List<float>();
             public List<float> ourarmy=new List<float>();
            
           public void FightingManpower()
           {
               float armyHold=enemyarmy[1]+ourarmy[1];
               float tut=(100*enemyarmy[1])/armyHold;
               EnemyAndUs.fillAmount=System.Convert.ToInt32(tut)/100;
           }
           public bool fightingS;
            public void fightStart(List<float> Stats)
            {
                fightingS=true;
                for (var i = 1; i < 3; i++)
                {
                    enemyarmy.Add(Stats[i]);
                    ourarmy.Add(Stats[i+3]);
                }
                enemyarmy.Add(Stats[6]);
                ourarmy.Add(Stats[7]);
            }
           public void fightMech()
           {
           
     
         
      
             float ourzar=0,enemyzar=0;
                
                        for (int j = 0; j < ourarmy[0]; j++)
                        { 
                             ourzar+=Random.Range(1,7)+ourarmy[1];
                        }                                      
                        for (int i = 0; i < enemyarmy[0]; i++)
                        {                
                              enemyzar+=Random.Range(1,7)+enemyarmy[1];                            
                        }

                          if (ourzar>enemyzar)
                          {
                              enemyarmy[0]--;
                          }
                          else if (ourzar<enemyzar)
                          {
                                 ourarmy[0]--;
                          }
                          else
                          {
                              enemyarmy[0]--;
                          }
                    if (ourarmy[0]==0)
                    {
                        fightingS=false;
                        winlose="lose";
                    }
                    else if(enemyarmy[0]==0)
                    {
                            fightingS=false;
                        winlose="win";
                    }
           }
       }
   public void closeWar()
   {
       transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        EnemyClass.mainSound.clip=null;
        EnemyClass.mainSound.Play();
             EnemyClass.mainMusicmainSound.clip=EnemyClass.sounds[5];
            EnemyClass.mainMusicmainSound.loop=true;
            EnemyClass.mainMusicmainSound.Play();
            MovingTo=null;
            gameObject.GetComponent<WarriorMech>().MovingObj=null;
            EnemyClass.Stats.Clear();
            FightClass.enemyarmy.Clear();
            FightClass.ourarmy.Clear();
   }
   
   public enemy EnemyClass;
  public Figting FightClass;
   TierStatGenerator enemyObjectStat;
  GameObject MovingTo;
  public void Destroygmobj()
  {
      if (FightClass.winlose=="lose")
      {
        Destroy(gameObject);   
        Destroy(MovingTo.transform.Find("EnemySamurai").gameObject);      
      }
      else if(FightClass.winlose=="win")
      {
                Destroy(MovingTo.transform.Find("EnemySamurai").gameObject);
                  MovingTo.layer=8;
                for (int i = 0; i < MovingTo.transform.childCount; i++)
                {
                    MovingTo.transform.GetChild(i).gameObject.layer=8;
                }
              
                GetComponent<WarriorMech>().ArayuzElements[0].SetActive(true);
                GetComponent<WarriorMech>().ArayuzElements[1].SetActive(false);
                GetComponent<WarriorMech>().ArayuzElements[2].SetActive(true);
                GetComponent<WarriorMech>().ArayuzElements[3].SetActive(true);
                  gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("idle");
      }

  }
  WarriorMech warriorMech=new WarriorMech();
    void Start()
    {
        
        warriorMech=GetComponent<WarriorMech>();
EnemyClass.mainSound=GameObject.FindGameObjectWithTag("SourceSound").GetComponent<AudioSource>();
       EnemyClass.mainMusicmainSound=GameObject.FindGameObjectWithTag("SourceMusic").GetComponent<AudioSource>();
    }
     public void Attackbtn()
       {
        EnemyClass.StatTexts[0].transform.parent.gameObject.SetActive(false);
        EnemyClass.EnemyObjectSpawn(MovingTo,gameObject);
        warriorMech.AttackMove=true;
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("Warrior");
        gameObject.GetComponent<WarriorMech>().fighting=true;
        FightClass.fightStart(EnemyClass.Stats);
        EnemyClass.mainMusicmainSound.clip=EnemyClass.sounds[3];
        EnemyClass.mainMusicmainSound.Play();
        EnemyClass.mainMusicmainSound.loop=false;
         GetComponent<WarriorMech>().ArayuzElements[0].SetActive(false);
                GetComponent<WarriorMech>().ArayuzElements[1].SetActive(true);
                GetComponent<WarriorMech>().ArayuzElements[2].SetActive(false);
                GetComponent<WarriorMech>().ArayuzElements[3].SetActive(false);
                 for (int i = 0; i < 3; i++)
                    {
                         FightClass.StatTexts[1].transform.GetChild(i).GetComponent<TMPro.TextMeshProUGUI>().text= FightClass.StatTexts[1].transform.GetChild(i).name+":"+FightClass.ourarmy[i].ToString();
                        FightClass.StatTexts[0].transform.GetChild(i).GetComponent<TMPro.TextMeshProUGUI>().text=FightClass.StatTexts[0].transform.GetChild(i).name+":"+FightClass.enemyarmy[i].ToString();
                    }
       }
   
    void Update()
    {
        if (EnemyClass.mainMusicmainSound.clip==EnemyClass.sounds[3]&&!EnemyClass.mainMusicmainSound.isPlaying&&EnemyClass.mainMusicmainSound.clip!=EnemyClass.sounds[4])
        {
            EnemyClass.mainMusicmainSound.clip=EnemyClass.sounds[4];
            EnemyClass.mainMusicmainSound.loop=true;
            EnemyClass.mainMusicmainSound.Play();
        }
        if (FightClass.fightingS)
        {

            FightClass.fightingTime+=Time.deltaTime;
            if (FightClass.fightingTime>40)
            {
                
                    FightClass.fightMech();
                    FightClass.fightingTime=0;
                     Destroygmobj();
                    for (int i = 0; i < 3; i++)
                    {
                         FightClass.StatTexts[1].transform.GetChild(i).GetComponent<TMPro.TextMeshProUGUI>().text= FightClass.StatTexts[1].transform.GetChild(i).name+":"+FightClass.ourarmy[i].ToString();
                        FightClass.StatTexts[0].transform.GetChild(i).GetComponent<TMPro.TextMeshProUGUI>().text=FightClass.StatTexts[0].transform.GetChild(i).name+":"+FightClass.enemyarmy[i].ToString();
                    }
               
            }
        }

        if (gameObject.GetComponent<WarriorMech>().MovingObj!=null&&MovingTo!=gameObject.GetComponent<WarriorMech>().MovingObj)
        {
             MovingTo= gameObject.GetComponent<WarriorMech>().MovingObj;
            if(MovingTo.layer!=8)
            { 
                enemyObjectStat=gameObject.GetComponent<WarriorMech>().MovingObj.GetComponent<TierStatGenerator>();
                EnemyClass.EnemyObject(gameObject.GetComponent<WarriorStats>(),enemyObjectStat.tieras.DefPow,enemyObjectStat.tieras.Manpower,enemyObjectStat.tieras.Tier,MovingTo,enemyObjectStat.tieras.luck);
                EnemyClass.mainSound.clip=EnemyClass.sounds[0];
                EnemyClass.mainSound.Play();
            }
          
        }
        
    }
}
