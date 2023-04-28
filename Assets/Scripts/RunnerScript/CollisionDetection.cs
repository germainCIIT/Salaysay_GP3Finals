using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private List<GameObject> bodyparts;
    private void Start()
    {
        GameObject[] _playerbodyparts =
        {
            GameObject.Find("Left Leg"),
            GameObject.Find("Right Leg"),
            GameObject.Find("Left Arm"),
            GameObject.Find("Right Arm"),
            GameObject.Find("Body"),
        };

        foreach (GameObject specificbodyparts in _playerbodyparts)
        {
            if (specificbodyparts != null)
            {
                bodyparts.Add(specificbodyparts);
            }
        }
    }

    // once they hit an obstacle, check and destroy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            int randomIndex = Random.Range(0, bodyparts.Count);
            GameObject bodypart = bodyparts[randomIndex];
            bodyparts.RemoveAt(randomIndex);
            // destroy a bodypart
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Collectible"))
        {
            GameObject bodypart = other.gameObject;
            bodyparts.Add(bodypart);
            Destroy(other.gameObject);
        }
        UpdateBodyParts();
    }

    // check if the body parts are attached/reattached
    void UpdateBodyParts()
    {
        GameObject leftLeg = GameObject.Find("Left Leg");
        leftLeg.SetActive(bodyparts.Contains(leftLeg));

        GameObject rightLeg = GameObject.Find("Right Leg");
        rightLeg.SetActive(bodyparts.Contains(rightLeg));

        GameObject leftArm = GameObject.Find("Left Arm");
        leftArm.SetActive(bodyparts.Contains(leftArm));

        GameObject rightArm = GameObject.Find("Right Arm");
        rightArm.SetActive(bodyparts.Contains(rightArm));

        GameObject body = GameObject.Find("Body");
        body.SetActive(bodyparts.Contains(body));
        
    }
}
