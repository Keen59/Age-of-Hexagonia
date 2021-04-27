using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WarriorStats : MonoBehaviour
{
     [System.Serializable]
   public class WorkerStat
   {
          public float Strenght;
            public float MoveSpeed;
            public float Manpower;
            public float DefensePower;
            public float luck;
            public int Tier;
   }
   
   public WorkerStat stats=new WorkerStat();
   public void Start() {
      
       stats.Manpower=1+stats.Tier*2;
       stats.MoveSpeed=1;
       stats.DefensePower=1*stats.Tier+1;
       stats.Strenght=1+stats.Manpower+Random.Range(0,2);
   }
}
