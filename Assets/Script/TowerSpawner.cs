using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int towerBuilGold = 50;
    [SerializeField] private EnemySpawner enemySpawner; //���� �ɿ� �����ϴ� �� ����Ʈ ������ ��� ����
    [SerializeField] private PlayerGold playerGold;

    public void SpawnTower(Transform tileTransform)
    {
        if(towerBuilGold > playerGold.CurrentGold)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true )
        {
            return;
        }

        tile.IsBuildTower = true;

        playerGold.CurrentGold -= towerBuilGold;

        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(towerPrefab, position, Quaternion.identity);

        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
    }
}
