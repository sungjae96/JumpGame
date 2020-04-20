using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public float interval = 10.0f;
    public float rangeX = 5.0f;
    public float rangeY = 3.0f;

    public int spawncheck = 0;

    IEnumerator Start()
    { // yield을 사용하기 위해 IEnumerator type으로 return
        while (true)
        {
            transform.position = new Vector3(Random.Range(-4, 30), 14, transform.position.z);
            Instantiate(EnemyPrefab[Random.Range(0,3)], transform.position, transform.rotation);


            //spawncheck++;
            yield return new WaitForSeconds(interval);

            //if (spawncheck == 10)
            //    interval = 9;

            //if (spawncheck == 10)
            //    interval = 9;

            interval -= 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
