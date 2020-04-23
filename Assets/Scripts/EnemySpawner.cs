using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    //public Transform target;
    public float spawnTimer;

    public float xMin = -25;
    public float xMax = 25;
    public float yMin = 8;
    public float yMax = 25;
    public float zMin = -25;
    public float zMax = 25;
    // Start is called before the first frame update
    void Start()
    {
        //target = LevelManager.player.transform;
        InvokeRepeating("SpawnEnemies", spawnTimer, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies() {
        //if (!LevelManager.levelOver) {
        Vector3 enemyPosition;

        enemyPosition.x = Random.Range(xMin, xMax) + transform.position.x;
        enemyPosition.y = Random.Range(yMin, yMax) + transform.position.y;
        enemyPosition.z = Random.Range(zMin, zMax) + transform.position.z;

        GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, transform.rotation) as GameObject;
        spawnedEnemy.GetComponent<FishMovement>().anchor = transform;    
        spawnedEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyLocker").transform);
            //spawnedEnemy.transform.parent = gameObject.transform;
            //spawnedEnemy.GetComponent<EnemyLogic>().target = target;
       // }
    }
}
