using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Bullets", menuName = "Bullets/Bullet")]
public class Bullets : ScriptableObject
{
    [ShowAssetPreview]public Sprite bulletSprite;
    public int bulletDamage;
    public float bulletSpeed;
    
}
