using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimAction;
    public InputActionProperty gripAnimAction;
    public Animator handAnimator;

    void Update()
    {
        float triggerValue = pinchAnimAction.action.ReadValue<float>();
        //Debug.Log("ANIM:" + triggerValue);
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimAction.action.ReadValue<float>(); ;
        handAnimator.SetFloat("Grip", gripValue);

    }
}
