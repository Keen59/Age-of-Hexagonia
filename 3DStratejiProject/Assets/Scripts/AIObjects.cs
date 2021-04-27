using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIObjects : MonoBehaviour
{
  /*5 farklı tier olucak yeşilden kırmızıya 
  doğru her seferinde sayı ve gücü artıcak birliklerin*/
   public List<Sprite> TierImages = new List<Sprite>(6);
  public Image Tier_img;
  public int Tier=1;
  public bool builded=false;

    public bool SomeoneOn=false;

   
        private void MapTiers(string obj_tag)
        {
         if (obj_tag=="Forest")
            {
                    
                     Tier=Random.Range(1,4);

            }
            else 
            {
                   
                    Tier=Random.Range(2,5);

            } 
        }
     void Start() {
         MapTiers(gameObject.tag);
       
    }
    
}
