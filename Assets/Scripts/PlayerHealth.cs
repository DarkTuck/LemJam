using NaughtyAttributes;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] [Foldout("Events")] private HealthArmorScriptableObject playerHealth;
    [SerializeField] private int health;
    [SerializeField][Foldout("Maxes")] int maxHealth = 100;
    private Actions actions;
    void Awake()
    {
        actions = new Actions();
    }

    private void OnEnable()
    {
        actions.Enable();
    }
    void OnDisable()
    {
        actions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.IntValue=health;
        playerHealth.max=maxHealth;
        
    }

    public void Damage(int damage)
    { 
        playerHealth.IntValue -=damage;
        if (playerHealth.IntValue <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Debug.Log("Player is dead");
    }
}
