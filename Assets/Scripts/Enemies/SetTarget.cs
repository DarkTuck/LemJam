using UnityEngine;
using DG.Tweening;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotate to look at the player
        transform.LookAt(PlayerSingleton._player.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
		
		
        //move towards the player
        if (Vector3.Distance(transform.position, PlayerSingleton._player.position) > 1f)
        {
            //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
