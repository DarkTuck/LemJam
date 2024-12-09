using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Actions actions;
    [SerializeField]float speed;
    InputAction movement;
    Transform player;

    void Awake()
    {
        actions = new Actions();
    }

    void OnEnable()
    {
        actions.Enable();
        movement = actions.Player.Move;
        player = transform;
    }

    void OnDisable()
    {
        actions.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.transform.Translate(new Vector3(movement.ReadValue<Vector2>().x * speed,0, 0));
    }
}
