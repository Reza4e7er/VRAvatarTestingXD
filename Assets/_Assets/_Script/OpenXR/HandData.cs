using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum HandModelType 
    {
        Left,
        Right
    }
    public HandModelType handType;

    public Transform root;
    public Animator animator;
    public List<Transform> fingerBones = new List<Transform>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        root = GetComponent<Transform>();
    }
}
