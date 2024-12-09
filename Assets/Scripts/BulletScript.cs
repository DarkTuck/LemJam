using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]public int damage;
    void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
