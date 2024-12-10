using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Actions actions;
    [SerializeField]float speed;
    InputAction movement;
    Transform player;

    [SerializeField] private Transform visualsTransform;

    private Vector2 inputVector;

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
        inputVector = movement.ReadValue<Vector2>();

		player.transform.Translate(new Vector3(inputVector.x * speed, 0, 0));

        if (inputVector.x > 0f)
        {
            visualsTransform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (inputVector.x < 0f)
        {
			visualsTransform.localScale = new Vector3(-1f, 1f, 1f);

		}
	}

    public Vector2 InputVector
    {
        get
        {
            return inputVector;
        }
    }
}
