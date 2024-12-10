using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyMelee, enemyGun;
    private List<GameObject> enemies;
    [SerializeField]SceneLoader sceneLoader;
    public void SpawnEnemies(int meleesToSpawn, int guns)
    {
        for (int i = 0; i < meleesToSpawn; i++)
        {
            GameObject enemie = Instantiate(enemyMelee);
            enemies.Add(enemie);
        }

        for (int i = 0; i < guns; i++)
        {
            GameObject enemie = Instantiate(enemyGun);
            enemies.Add(enemie);
        }
    }

    public void EnemiesKilled(GameObject enemie)
    {
        enemies.Remove(enemie);
        if (enemies.Count == 0)
        {
            sceneLoader.LoadScene();
        }
    }
}
