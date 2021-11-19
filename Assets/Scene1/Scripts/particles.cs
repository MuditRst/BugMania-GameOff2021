using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    void Update(){
        this.GetComponent<ParticleSystem>().Play();
    }
}
