using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public float interval;
    public float rangeX = 5.0f;
    public float rangeY = 3.0f;

    IEnumerator Start()
    { // yield을 사용하기 위해 IEnumerator type으로 return
        while (true)
        {
            transform.position = new Vector3(Random.Range(-4, 30), 14, transform.position.z);
            Instantiate(EnemyPrefab[Random.Range(0,3)], transform.position, transform.rotation);

            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
