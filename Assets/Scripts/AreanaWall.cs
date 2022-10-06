using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreanaWall : MonoBehaviour
{
    private Animator arenaAnimator;
    void Start()
    {
        GameObject arena = transform.parent.gameObject;
        arenaAnimator = arena.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", true);    
    }

    void OnTriggerExit(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", false);   
    }

}
