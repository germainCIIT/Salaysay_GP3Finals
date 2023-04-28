using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    [SerializeField] private Transform ResetPos;
    Rigidbody rb;
    
    // bools are quite useful for checking stuff
    [SerializeField] private bool diceHasLanded;
    [SerializeField] private bool diceWasThrown;
    
    [SerializeField] private DiceSide[] _ds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = ResetPos.position;
        _ds = GetComponentsInChildren<DiceSide>();

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
            StartCoroutine(SpinDice());
        }
        if (rb.IsSleeping() && !diceHasLanded && diceWasThrown)
        {
            diceHasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDice();
        }
    }

    void RollDice()
    {
        if (!diceWasThrown && !diceHasLanded)
        {
            diceWasThrown = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(0, Random.Range(5, 15), 0, ForceMode.Impulse);
        }
        else if (diceWasThrown && diceHasLanded)
        {
            ResetDice();
        }
    }
    void ResetDice()
    {
        transform.position = ResetPos.position;
        rb.useGravity = false;
        diceWasThrown = false;
        diceHasLanded = false;
        rb.isKinematic = true;
    }
    
    IEnumerator SpinDice()
    {
        float elapsedTime = 0f;
        float spinDuration = 2f;
        float totalRotation = Random.Range(720, 1080);
        Vector3 spinAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        while (elapsedTime < spinDuration)
        {
            float rotationAmount = Mathf.Lerp(0f, totalRotation, (elapsedTime / spinDuration));
            transform.Rotate(spinAxis, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // so that they'll always hit 90 degs
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = Mathf.Round(eulerAngles.x / 90) * 90;
        eulerAngles.y = Mathf.Round(eulerAngles.y / 90) * 90;
        eulerAngles.z = Mathf.Round(eulerAngles.z / 90) * 90;
        transform.eulerAngles = eulerAngles;
    }
}
