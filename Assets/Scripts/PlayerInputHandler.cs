using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction; 
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput; 
    private NewPlayerInput mover;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        mover = GetComponent<NewPlayerInput>(); 
    }

    public static void OnMove(CallbackContext context)
    {
       
    }


} 





