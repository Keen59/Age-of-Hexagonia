using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TierStatGenerator : MonoBehaviour
{
    [Serializable]
    public class Tiers
    {
        public int Manpower=1;
        public float DefPow=1;
        public float luck=1;
        public int Tier=1;
        
    }
    public Tiers tieras;
    
    void TierAssignment(int tier)
    {
        
            tieras.Manpower=5*tier;
            tieras.luck=1*tier;
            tieras.DefPow=3*tieras.luck;
             
            tieras.Tier=tier;
        
    }
     void Start() {
        AIObjects thisGameobj =gameObject.GetComponent<AIObjects>();
        TierAssignment(thisGameobj.Tier);
    }
}
