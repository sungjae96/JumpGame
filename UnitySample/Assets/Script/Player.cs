using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public int jumpNum;
    public GameObject bulletprefab;
    public float bulletpower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpNum > 0 )
        {            
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            jumpNum--;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = LoadBullet();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;


            pos = pos - transform.position;
            pos = pos.normalized;

            bullet.GetComponent<Rigidbody>().velocity = pos * bulletpower;
        }
    }

    GameObject LoadBullet()
    {
        var bullet = GameObject.Instantiate(bulletprefab) as GameObject;
        bullet.transform.parent = transform;
        bullet.transform.localPosition = Vector3.zero;
        return bullet;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Block")
        {
            jumpNum = 2;
        }

        else if (other.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Main");

        else if (other.gameObject.tag == "Bottom")
            SceneManager.LoadScene("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Main");
    }

}
