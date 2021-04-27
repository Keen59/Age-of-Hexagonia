
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Envantory : MonoBehaviour
{
    [System.Serializable]
   public struct EnvantoryStats
   {
       public int food;
       public int wood;
       public int rock;
       public int gold;
       public int workerMAX;
       public int warriorMAX;
           public int worker;
       public int warrior;
       public int warriorTier;
       
   }
  public EnvantoryStats envantory=new EnvantoryStats();
   private void Start() {
       envantory.food=200;
       envantory.wood=150;
       envantory.rock=50;
       envantory.gold=0;
       envantory.warriorMAX=2;
       envantory.workerMAX=1;
       envantory.warriorTier=1;

   }
   public Text[] EnvantoryUI;
   private void LateUpdate() {
       EnvantoryUI[0].text=envantory.food.ToString();
       EnvantoryUI[1].text=envantory.wood.ToString();
       EnvantoryUI[2].text=envantory.rock.ToString();
       EnvantoryUI[3].text=envantory.gold.ToString();
       EnvantoryUI[4].text=envantory.worker.ToString()+"/"+envantory.workerMAX.ToString();
       EnvantoryUI[5].text=envantory.warrior.ToString()+"/"+envantory.warriorMAX.ToString();
       
   }
}
