using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class WeponScript : MonoBehaviour
{
    [SerializeField] Bullets[] bullets;
    Actions actions;
    public int currentBullet;

    void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        actions.Player.Attack.performed += Attack;
    }

    void OnDisable()
    {
        actions.Disable();
        actions.Player.Attack.performed -= Attack;
    }

    void Attack(InputAction.CallbackContext context)
    {
        GameObject bulletToSpawn = new GameObject();
        bulletToSpawn.transform.position = transform.position;
        bulletToSpawn.AddComponent<Rigidbody2D>().AddForce(new Vector2(bullets[currentBullet].bulletSpeed*100,0));
        bulletToSpawn.AddComponent<CircleCollider2D>().radius = 0.5f;
        bulletToSpawn.AddComponent<SpriteRenderer>().sprite = bullets[currentBullet].bulletSprite;
        bulletToSpawn.AddComponent<BulletScript>().damage=bullets[currentBullet].bulletDamage;
        Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), bulletToSpawn.GetComponent<CircleCollider2D>());
     }


}

