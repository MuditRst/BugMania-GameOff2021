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
                col.gameObject.GetComponent<Movement>().gotMantis = true;
            }else if(isBeetle){
                col.gameObject.GetComponent<Movement>().gotBeetle = true;
            }
            Destroy(this.gameObject);
        }
    }

}
