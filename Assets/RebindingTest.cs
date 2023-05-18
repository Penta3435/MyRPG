using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingTest : MonoBehaviour
{
    public PlayerInput playerInput;

    private InputActionAsset inputActionAsset;

    void Awake()
    {
        inputActionAsset = playerInput.actions;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("rebinding...");
            RemapButtonClicked(inputActionAsset.FindActionMap("PlayerController").FindAction("Movement"));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            inputActionAsset.FindActionMap("PlayerController").FindAction("Movement").Enable();
        }
    }
    void RemapButtonClicked(InputAction actionToRebind)
    {
        actionToRebind.Disable();
        var rebindOperation = actionToRebind.PerformInteractiveRebinding().Start();
    }
    public void Pressed()
    {
        print("pressed");
    }
}
