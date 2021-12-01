using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    [SerializeField] private Light2D l;
    public float innerRadius,Outerradius;
    void Start()
    {
        l = GetComponentInChildren<Light2D>();
        innerRadius = l.pointLightInnerRadius;
        Outerradius = l.pointLightOuterRadius;
    }

    void Update()
    {
        StartCoroutine(CoolDown());
    }


    IEnumerator CoolDown()
    {
        if(l.pointLightInnerRadius <= 0.66f){
            l.pointLightInnerRadius += 0.1f; 
        }
        if(l.pointLightOuterRadius<= 2.2f){
            l.pointLightOuterRadius += 0.1f; 
        }

        yield return new WaitForSeconds(3f);

        if(l.pointLightInnerRadius >= innerRadius){
            l.pointLightInnerRadius -= 0.1f; 
        }
        if(l.pointLightOuterRadius >= Outerradius){
            l.pointLightOuterRadius -= 0.1f; 
        }
    }
}
