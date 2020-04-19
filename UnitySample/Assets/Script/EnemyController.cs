using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public GameObject targetPrefab;
    public int health;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        target = targetPrefab.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target, Speed);

        //gameObject.GetComponent<Rigidbody>().velocity = target * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("Score").GetComponent<Score>().ScoreUP();
            }
        }
    }
}
