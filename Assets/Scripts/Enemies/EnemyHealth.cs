using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{   
    [SerializeField] int health = 100;

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
