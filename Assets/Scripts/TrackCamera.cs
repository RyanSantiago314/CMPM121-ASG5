﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamera : MonoBehaviour
{
	public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(character.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character.transform);
    }
}
