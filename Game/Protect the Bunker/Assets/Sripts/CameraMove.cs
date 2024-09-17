using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(GameManager.instance.isFightOn)
        {
            anim.SetBool("IsFightOn", true);
        }
        else
        {
            anim.SetBool("IsFightOn", false);
        }
        
    }
}
