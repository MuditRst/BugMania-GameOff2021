using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchLightScript : MonoBehaviour
{
    [SerializeField] private Light2D l;
    public float innerRadius,Outerradius,intensity;
    void Start()
    {
        l = GetComponentInChildren<Light2D>();
        innerRadius = l.pointLightInnerRadius;
        Outerradius = l.pointLightOuterRadius;
        intensity = l.intensity;
    }

    
    void Update()
    {
        StartCoroutine(CoolDown());
    }


    IEnumerator CoolDown()
    {
        if(l.pointLightInnerRadius <= 1.5f){
            l.pointLightInnerRadius += 0.01f; 
        }
        if(l.pointLightOuterRadius<= 5f){
            l.pointLightOuterRadius += 0.01f; 
        }

        if(l.intensity <= 1f){
            l.intensity += 0.01f; 
        }

        yield return new WaitForSeconds(5f);

        if(l.pointLightInnerRadius >= innerRadius){
            l.pointLightInnerRadius -= 0.01f; 
        }
        if(l.pointLightOuterRadius >= Outerradius){
            l.pointLightOuterRadius -= 0.01f; 
        }

        if(l.intensity >= intensity){
            l.intensity -= 0.01f; 
        }
    }
}
