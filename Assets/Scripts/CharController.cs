using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Animator anim;
    public AudioSource jump;
    public AudioSource run;
    public AudioSource rest;
    public AudioSource idle2;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        run.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetFloat("Speed") == 1f && !jump.isPlaying)
            run.volume += 0.1f;
        else
            run.volume -= 0.1f;

        if (anim.GetBool("Jump"))
            jump.Play();
        if (anim.GetBool("IdleAnim2"))
            idle2.Play();
        if (anim.GetBool("Rest"))
            rest.Play();
    }
}
