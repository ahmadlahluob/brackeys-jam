using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor;

    public Texture2D cursorClicked;
    
    private CursorControls cursorControls;
    private Camera mainCamera;

    private void Awake()
    {
        cursorControls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        cursorControls.Enable();
    }

    private void OnDisable()
    {
        cursorControls.Disable();
    }
    void Start()
    {
        cursorControls.Mouse.Click.started+= _ => StartedClick();
        cursorControls.Mouse.Click.performed += _ => EndedClick();
    }
    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    // Start is called before the first frame update
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(cursorControls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name + " : " + hit.collider.tag);
                if (hit.collider.tag == "Platform")
                {
                    hit.collider.gameObject.GetComponent<Platform>().clicked();
                }
            }
        }
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
        
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }

}
