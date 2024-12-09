using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton _instance;

    public static Transform _player
    {
        get { return _instance.transform; }
        private set { }
    }

    private IDamagable _playerDamage;
    public static IDamagable _damageable
    {
        get { return _instance._playerDamage; }
        private set { }
    }
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _player = gameObject.transform;
            _playerDamage = gameObject.GetComponent<IDamagable>();
        }
    }
}
