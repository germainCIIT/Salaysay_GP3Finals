using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToNextSlab : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject[] Tiles;

    public static MovePlayerToNextSlab instance;
    private int moveSpeed = 5;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tiles");
    }

    // Debug just in case for checks to where the player moves from the dicecount
    public void MovePlayerFromDiceNumber(int Number)
    {
        Debug.Log("Checking");
        for (int i = 0; i < Number; i++)
        {
            if (i < Number)
            {
                StartCoroutine(MovePlayerOneSlabToAnother(Number));
            }
        }
    }

    IEnumerator MovePlayerOneSlabToAnother(int number)
    {
        Vector3 destination = Tiles[number].transform.position;
        while (Vector3.Distance(Player.transform.position, destination) > 0.1f)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
