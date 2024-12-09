using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class InputActivationManager : MonoBehaviour
{
    Actions actions;
    [SerializeField] int cliksToUnlock;
    [SerializeField] GameObject player;
    [SerializeField][Foldout("jak coś podpięte to nie tykać")][Label("liczniczek")]IntEvent counter;
    [SerializeField][Foldout("jak coś podpięte to nie tykać")][Label("Zdrowe")]HealthArmorScriptableObject attachedIntEvent;
    bool canUnlockGranade = false;

    void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Attack.performed += ActivateAttack;
        counter.IntValue = cliksToUnlock;
        attachedIntEvent.RegisterDelegate(AttachedIntEventChanged);
    }

    void OnDisable()
    {
        actions.Disable();
        attachedIntEvent.UnregisterDelegate(AttachedIntEventChanged);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void ActivateAttack(InputAction.CallbackContext context)
    {
        counter.IntValue--;
        if (counter.IntValue == 0)
        {
            player.GetComponent<WeponScript>().enabled = true;
            actions.Player.Attack.performed -= ActivateAttack;
            actions.Player.Defend.performed += ActivadeDefend;
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
            }
        }
    }
}
