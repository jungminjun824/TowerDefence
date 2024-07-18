using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private TowerTemplate towerTemplate;

    [SerializeField] private EnemySpawner enemySpawner; //���� �ɿ� �����ϴ� �� ����Ʈ ������ ��� ����
    [SerializeField] private PlayerGold playerGold;
    [SerializeField] private SystemTextViewer systemTextViewer;
    private bool isOnTowerButton = false;
    private GameObject followTowerClone = null;

    public void ReadyToSpawnTower()
    {
        if(isOnTowerButton == true)
        {
            return;
        }

        if (towerTemplate.weapon[0].cost > playerGold.CurrentGold)
        {
            systemTextViewer.PrintText(SystemType.Money);
            return;
        }

        isOnTowerButton = true;
        followTowerClone = Instantiate(towerTemplate.followTowerPrefab);
    }

    public void SpawnTower(Transform tileTransform)
    {

      if(isOnTowerButton == false)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true )
        {
            systemTextViewer.PrintText(SystemType.Build);
            return;
        }

        isOnTowerButton = false;

        tile.IsBuildTower = true;

        playerGold.CurrentGold -= towerTemplate.weapon[0].cost;

        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(towerTemplate.towerPrefab, position, Quaternion.identity); 

        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner, playerGold, tile);

        Destroy(followTowerClone);
    }
}
