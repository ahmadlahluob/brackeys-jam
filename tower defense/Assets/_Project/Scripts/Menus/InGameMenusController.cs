using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenusController : MonoBehaviour
{
    public static InGameMenusController Instance;
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    public void HideAllMenus()
    {
        
    }
}
