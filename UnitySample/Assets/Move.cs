using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movespeed;    public float deletetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deletetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movespeed * Time.deltaTime, 0, 0);
    }
}
