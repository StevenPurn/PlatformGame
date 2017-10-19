using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameControl.Teams team;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.GetComponent<PlayerController>().team == team)
            {
                Debug.Log("button active");
            }
            else
            {
                Debug.Log("team doesn't match");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.GetComponent<PlayerController>().team == team)
            {
                Debug.Log("button inactive");
            }
            else
            {
                Debug.Log("team doesn't match");
            }
        }
    }
}
