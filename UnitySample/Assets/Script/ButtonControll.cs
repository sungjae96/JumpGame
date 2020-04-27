using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void PressRestartButton()
    {
        SceneManager.LoadScene("Title");
    }
}
