using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAngry : MonoBehaviour
{


    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Do nothing");
            anim.Play("New State", 0, 0.25f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("look angry");
            anim.Play("angry", 0, 0.25f);
        }
    }
}
