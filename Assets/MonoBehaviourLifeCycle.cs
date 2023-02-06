using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourLifeCycle : MonoBehaviour
{
    
    private void Awake()
    {
        print("Awake");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    public int count = 0;

    // Update is called once per frame
    void Update()
    {
        count++;
        // if (count % 500 == 0)
            print("Update");
    }
    
    private void FixedUpdate()
    {
        // if (count % 500 == 0)
        print("FixedUpdate");
    }
    
    private void LateUpdate()
    {
        // if (count % 500 == 0)
        print("LateUpdate");
    }


    private void OnEnable()
    {
        print("OnEnable");
    }
    
    private void OnDisable()
    {
        print("OnDisable");
    }

    private void OnDestroy()
    {
        print("OnDestroy");
    }

    private void OnValidate()
    {
        print("OnValidate");
    }

    private void Reset()
    {
        print("Reset");
    }

    
    
}