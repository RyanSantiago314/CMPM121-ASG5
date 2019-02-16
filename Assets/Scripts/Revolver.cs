using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(180, 210, 120) * Time.deltaTime);

        transform.RotateAround(target.transform.position, Vector3.up, 120 * Time.deltaTime);
        
    }
}
