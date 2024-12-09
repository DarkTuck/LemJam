using UnityEngine;
using DG.Tweening;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMove(PlayerSingleton._player.transform.position, speed);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
