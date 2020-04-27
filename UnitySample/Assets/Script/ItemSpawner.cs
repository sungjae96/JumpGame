using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] ItemPrefab;
    public float interval = 15.0f;
    public float rangeX = 5.0f;
    public float rangeY = 3.0f;

    public int spawncheck = 0;

    IEnumerator Start()
    { // yield을 사용하기 위해 IEnumerator type으로 return
        while (true)
        {
            transform.position = new Vector3(Random.Range(-rangeX, -1), Random.Range(0, rangeY), transform.position.z);
            Instantiate(ItemPrefab[Random.Range(0, 2)], transform.position, transform.rotation);


            //spawncheck++;
            yield return new WaitForSeconds(interval);

            //if (spawncheck == 10)
            //    interval = 9;

            //if (spawncheck == 10)
            //    interval = 9;

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
