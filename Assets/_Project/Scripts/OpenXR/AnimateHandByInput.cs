using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandByInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty GripAnimationAction;

    private Animator animator;

    float triggerValue;
    float gripValue;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        triggerValue = pinchAnimationAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);

        //Debug.Log(triggerValue);


        gripValue = GripAnimationAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);
    }
}
