using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public int jumpNum;
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
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Block")
        {
            jumpNum = 2;
        }

        else if (other.gameObject.tag == "Bottom")
            SceneManager.LoadScene("Main");
    }
    
}
