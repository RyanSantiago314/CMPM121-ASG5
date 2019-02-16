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
    public AudioSource hooray;

    public float openSpeed = 4f;
    public GameObject HallDoor;
    public ParticleSystem sparkly;
    public ParticleSystem important;

    private bool HallDoorOpen = false;
    public bool GotCard = false;


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

        if (HallDoorOpen && HallDoor.transform.position.y < 10)
        {
            HallDoor.transform.position += new Vector3(0, openSpeed * Time.deltaTime, 0);
        }
        else if (HallDoorOpen){}
        else if (!HallDoorOpen && HallDoor.transform.position.y > 3.5)
        {
            HallDoor.transform.position -= new Vector3(0, openSpeed/2 * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Card"))
        {
            hooray.Play();
            GotCard = true;
            sparkly.Play();
            important.Play();
            Destroy(other.gameObject);
            transform.GetChild(6).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.gameObject.CompareTag("Hall"))
        {
            HallDoorOpen = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Hall"))
        {
            HallDoorOpen = false;
        }
    }

}
