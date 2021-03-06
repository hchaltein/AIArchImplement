﻿using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    Transform Parent;

    // Use this for initialization
    void Start()
    {
        Parent = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            if (Parent.gameObject.tag == "Player")
            {
                Parent.GetComponent<PlayerController>().isGrounded = true;
                Parent.GetComponent<Rigidbody>().velocity = new Vector3(Parent.GetComponent<Rigidbody>().velocity.x, 0.0f);
                return;
            }

            if (Parent.gameObject.tag == "Boss")
            {
                Parent.GetComponent<AICtrl>().isGrounded = true;
                Parent.GetComponent<Rigidbody>().velocity = new Vector3(Parent.GetComponent<Rigidbody>().velocity.x, 0.0f);
                return;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            if (Parent.gameObject.tag == "Player")
            {
                Parent.GetComponent<PlayerController>().isGrounded = false;
                return;
            }
            if (Parent.gameObject.tag == "Boss")
            {
                Parent.GetComponent<AICtrl>().isGrounded = false;
                return;
            }
        }
    }
}
