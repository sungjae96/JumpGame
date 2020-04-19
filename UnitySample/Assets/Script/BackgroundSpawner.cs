using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject BackgroundPrefab;
    public float interval;


    IEnumerator Start()
    { // yield을 사용하기 위해 IEnumerator type으로 return
        while (true)
        {
            transform.position = new Vector3(-21, 7, transform.position.z);
            Instantiate(BackgroundPrefab, transform.position, transform.rotation);

            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
