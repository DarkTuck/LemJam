using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]public int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
