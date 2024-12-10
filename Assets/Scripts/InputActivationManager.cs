using System;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class InputActivationManager : MonoBehaviour
{
    Actions actions;
    [SerializeField] int cliksToUnlock;
    [SerializeField] GameObject player;
    [SerializeField][Foldout("Teksty")] string unlockWeponText,unlockShieldText,unlockRocketText;
    [SerializeField][Foldout("jak coś podpięte to nie tykać")][Label("liczniczek")]IntEvent counter;
    [SerializeField][Foldout("jak coś podpięte to nie tykać")][Label("Zdrowe")]HealthArmorScriptableObject attachedIntEvent;
    [SerializeField][Foldout("jak coś podpięte to nie tykać")][Label("wypiszTextUI")]TextEvent textEvent;
    bool canUnlockGranade = false;

    void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Attack.performed += ActivateAttack;
        attachedIntEvent.RegisterDelegate(AttachedIntEventChanged);
        player.GetComponent<WeponScript>().enabled = false;
        player.GetComponent<Shield>().enabled = false;
    }

    void OnDisable()
    {
        actions.Disable();
        attachedIntEvent.UnregisterDelegate(AttachedIntEventChanged);
        actions.Player.Attack.performed -= ActivateAttack;
        actions.Player.Defend.performed -= ActivadeDefend;
    }

    private void Start()
    {
        counter.IntValue = cliksToUnlock;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void ActivateAttack(InputAction.CallbackContext context)
    {
        counter.IntValue--;
        if (counter.IntValue == 0)
        {
            Debug.Log("Zdrowe");
            player.GetComponent<WeponScript>().enabled = true;
            actions.Player.Attack.performed -= ActivateAttack;
            actions.Player.Defend.performed += ActivadeDefend;
            textEvent.TextValue = unlockWeponText;
            counter.IntValue = cliksToUnlock;
        }
    }

    void ActivadeDefend(InputAction.CallbackContext context)
    {
        counter.IntValue--;
        if (counter.IntValue == 0)
        {
            player.GetComponent<Shield>().enabled = true;
            actions.Player.Defend.performed -= ActivadeDefend;
            textEvent.TextValue = unlockShieldText;
            counter.IntValue=attachedIntEvent.max/2;
        }
    }
    private void AttachedIntEventChanged(bool isDebug)
    {
        if(canUnlockGranade)
        {
            counter.IntValue--;
            if (counter.IntValue == 0)
            {
                player.GetComponent<WeponScript>().currentBullet=1;
                textEvent.TextValue = unlockRocketText;
            }
        }
    }
}
