using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float movespeed;    public float deletetime;    Timer Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("GameManager").GetComponent<Timer>();
       movespeed = Timer.timer;
        deletetime = 10;
        Destroy(gameObject, deletetime);
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(movespeed * Time.deltaTime, 0, 0);
    }
}
