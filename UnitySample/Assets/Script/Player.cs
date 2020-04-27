using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public int jumpNum;
    public GameObject bulletprefab;
    public GameObject bulletprefab1;
    public GameObject bulletprefab2;
    public float bulletpower;

    public AudioSource _jumpSound;
    public AudioSource _ShootSound;

    public int gunstate;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        gunstate = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpNum > 0 )
        {            
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            _jumpSound.Play();
            jumpNum--;
        }

        if (Input.GetMouseButtonDown(0) && gunstate!= 1)
        {
            if (gunstate == 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _ShootSound.Play();
                pos.z = transform.position.z;
                pos = pos - transform.position;
                pos = pos.normalized;
                GameObject bullet = LoadBullet();
                bullet.GetComponent<Rigidbody>().velocity = pos * bulletpower;
            }

            else if (gunstate == 2)
            {
                GameObject bullet = LoadBullet();
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _ShootSound.Play();
                pos.z = transform.position.z;
                pos = pos - transform.position;
                pos = pos.normalized;
                bullet.GetComponent<Rigidbody>().velocity = pos * bulletpower;
            }
        }

        if (Input.GetMouseButton(0) && gunstate == 1)
        {           
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _ShootSound.Play();
                pos.z = transform.position.z;
                pos = pos - transform.position;
                pos = pos.normalized;
                GameObject bullet = LoadBullet();
                bullet.GetComponent<Rigidbody>().velocity = pos * bulletpower;
                StartCoroutine(WaitForIt());
        }

        if (gunstate != 0)
        {
            timer += Time.deltaTime;
            if(timer >= 5)
            {
                gunstate = 0;
            }
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1f);
    }

    GameObject LoadBullet()
    {
        if( gunstate == 0)
        {
            var bullet = GameObject.Instantiate(bulletprefab) as GameObject;
            bullet.transform.parent = transform;
            bullet.transform.localPosition = Vector3.zero;
            return bullet;

        }

        else if (gunstate == 1)
        {
            var bullet = GameObject.Instantiate(bulletprefab1) as GameObject;
            bullet.transform.parent = transform;
            bullet.transform.localPosition = Vector3.zero;
            return bullet;
        }
        else if (gunstate == 2)
        {
            var bullet = GameObject.Instantiate(bulletprefab2) as GameObject;
            bullet.transform.parent = transform;
            bullet.transform.localPosition = Vector3.zero;
            return bullet;
        }

        return bulletprefab;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Block")
        {
            jumpNum = 2;
        }

        else if (other.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Lose");

        else if (other.gameObject.tag == "Bottom")
            SceneManager.LoadScene("Lose");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Lose");

        else if (other.gameObject.tag == "Sniper")
        {
            timer = 0;
            gunstate = 2;
        }

        else if (other.gameObject.tag == "Machinegun")
        {
            timer = 0;
            gunstate = 1;
        }

    }

}
