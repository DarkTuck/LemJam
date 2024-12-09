using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector]public int damage;
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IDamagable>().Damage(damage);
        Destroy(this.gameObject);
    }
}
