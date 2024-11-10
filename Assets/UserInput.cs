using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public Controls controls;

    private void Awake()
    {
    if (instance == null){
        instance = this;
        controls = new Controls();
    }
        else
        {
            Debug.LogWarning("Another instance of UserInput is being created. Singleton pattern violated.");
            Destroy(gameObject);  // Optionally, destroy the duplicate instance.
        }
        
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
