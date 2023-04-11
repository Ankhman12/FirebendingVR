using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Firebend : MonoBehaviour
{

    public InputActionProperty TriggerInput;
    public Transform FireSpawnPoint;
    public GameObject FireProjectile;
    public GameObject Head;
    public XRBaseController xr;

    float breathMeter = 0f;
    float maxBreath = 6f;
    bool canFirebend;

    float fireTimer = .1f;
    float fireTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float triggerValue = TriggerInput.action.ReadValue<float>();
        if (triggerValue > 0.9f && breathMeter < maxBreath)
        {
            if (!canFirebend) 
            { 
                breathMeter += Time.deltaTime * 2;

                if (breathMeter % .5f < 0.1f)
                {
                    //Play Rumble
                    xr.SendHapticImpulse(0.5f, .1f);
                }
            }

        }
        else {
            breathMeter = 0f;
        }

        //Check if CanFirebend
        float dist = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Head.transform.position.x, Head.transform.position.z));
        if (dist > .6f)
        {
            canFirebend = true;
        }
        else
        { 
            canFirebend= false;
        }

        //If you have breath and can firebend, shoot fire!
        fireTimer -= Time.deltaTime;
        if (breathMeter > .5f && canFirebend && fireTimer < 0f)
        {
            //Reset Timer
            fireTimer = fireTime;

            //Shoot Fireball
            GameObject fireball = Instantiate(FireProjectile, FireSpawnPoint.position, FireSpawnPoint.rotation);
            fireball.GetComponent<Rigidbody>().velocity = FireSpawnPoint.forward * 10; 

            //decrement breath
            breathMeter -= .5f;
        }


        if (breathMeter > 0)
        {
            //Debug.Log(breathMeter);
        }
    }
}
