using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowards : MonoBehaviour {

    public Transform target;
    public bool faceTowards;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (faceTowards)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(transform.position - target.position);
        }
	}
}
