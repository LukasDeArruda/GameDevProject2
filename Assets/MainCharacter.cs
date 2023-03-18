using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private bool countdown;
    private float timer;
    
    void Start()
    {
        countdown = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var  speed = 5f * Time.deltaTime;
        
        var horizMove = Input.GetAxisRaw("Horizontal") * speed;
        var vertMove = Input.GetAxisRaw("Vertical") * speed;
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            countdown = true; 
        }

        if (countdown)
        {
            // timer stuff
            if (timer < 3)
            {
                timer += Time.deltaTime;
                //1Debug.Log(timer);
            }
            else
            {
                //Application.Quit();
                //This is how we do it in the editor, above would be for complied game
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        

    }
}
