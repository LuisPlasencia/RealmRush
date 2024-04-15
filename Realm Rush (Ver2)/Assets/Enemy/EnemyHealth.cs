using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]     // attribute that ensures that the required component also gets attached to the game object when we attach the script
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();     
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
