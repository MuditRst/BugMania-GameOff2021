using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashParticles : MonoBehaviour
{
    public GameObject dash;

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().isdashing)
        {
            Instantiate(dash, transform.position, Quaternion.identity);
        }
    }

}
