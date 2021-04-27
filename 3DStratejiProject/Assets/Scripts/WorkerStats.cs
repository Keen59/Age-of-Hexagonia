using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorkerStats : MonoBehaviour
{
    [Serializable]
   public class WorkerStat
   {
          public float WorkSpeed;
            public float MoveSpeed;
            public float Manpower;
            
   }
   public WorkerStat stats=new WorkerStat();
   public void Start() {
      
       stats.Manpower=1;
       stats.MoveSpeed=1;
       stats.WorkSpeed=1+stats.Manpower;
   }
}
