using UnityEngine;
using System.Collections;

public class DeleteGameObject : MonoBehaviour
{

    public float TimeLimit = 1.0f;     
    private float Timer = 0f;    

    private void Awake()
    {
        Timer = TimeLimit;
    }

    private void Update()
    {

        Timer -= Time.deltaTime;

        if (Timer < 0f)
        { 
            Destroy(gameObject);
        }
    }

}
