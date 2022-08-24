using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    public GameObject DicePrefab;
    public Transform DiceSpawn;

    private GameObject diceParent;

    void Start()
    {
        diceParent = new GameObject()
        {
            name = "Dice-Parent"
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject dice = Instantiate(DicePrefab, diceParent.transform.position, Quaternion.identity);
            dice.GetComponent<DiceRoller>().Roll(DiceSpawn.position);
        }
    }
}
