using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shield : MonoBehaviour
{
    Actions actions;
    [SerializeField] GameObject shield;
    private void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Defend.started += ActivateShield;
        actions.Player.Defend.canceled += DeactivateShield;
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Player.Defend.started -= ActivateShield;
        actions.Player.Defend.canceled -= DeactivateShield;
    }

    void ActivateShield(InputAction.CallbackContext context)
    {
        shield.SetActive(true);
    }

    void DeactivateShield(InputAction.CallbackContext context)
    {
        shield.SetActive(false);
    }
}
