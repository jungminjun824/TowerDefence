using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private EnemySpawner enemySpawner; //현재 맴에 존재하는 적 리스트 정보를 얻기 위해

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true )
        {
            return;
        }
        tile.IsBuildTower = true;

        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
    }
}
