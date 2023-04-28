using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAndGainBodyPart : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyparts = new GameObject[5];

    // once it starts, check the list
    private void Start()
    {
        bodyparts[0] = GameObject.Find("Left Leg");
        bodyparts[1] = GameObject.Find("Right Leg");
        bodyparts[2] = GameObject.Find("Left Arm");
        bodyparts[3] = GameObject.Find("Right Arm");
        bodyparts[4] = GameObject.Find("Body");
    }

    // set them false once they hit an obstacle, so it can save memory,
    // and so they can be kept
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < bodyparts.Length; i++)
        {
            if (other.CompareTag("Obstacle"))
            {
                bodyparts[i].SetActive(false);
                Destroy(other.gameObject);
            }
        }
    }
}
