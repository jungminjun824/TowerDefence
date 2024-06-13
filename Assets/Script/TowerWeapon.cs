using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SerchTarget = 0, AttackToTarget }
public class TowerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float attackRange = 2.0f;

    private WeaponState weaponState = WeaponState.SerchTarget;
    private Transform attackTarget = null;
    private EnemySpawner enemySpawner;
    public void SetUp(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;

        ChangeState(WeaponState.SerchTarget);
    }
    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }
    private void Update()
    {
         if(attackTarget != null)
        {
            RotateToTarget();
        }
    }
    private void RotateToTarget()
    {

    }
}
