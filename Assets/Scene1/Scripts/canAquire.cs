using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canAquire : MonoBehaviour
{
    [SerializeField] bool isMantis,isBeetle;

    void Start(){
        if(this.gameObject.name == "MantisAcquired"){
            isMantis = true;
        }else if(this.gameObject.name == "BeetleAcquired"){
            isBeetle = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            if(isMantis){
                PlayerPrefs.SetInt("Mantis",1);
            }else if(isBeetle){
                PlayerPrefs.SetInt("Beetle",1);
            }
            Destroy(this.gameObject);
        }
    }

}
