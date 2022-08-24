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
            GameObject dice = Instantiate(DicePrefab, DiceSpawn.transform.position, Quaternion.identity);
            dice.transform.SetParent(diceParent.transform);
            dice.GetComponent<DiceRoller>().Roll(DiceSpawn.position);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            int childCount = diceParent.transform.childCount;
            Debug.Log(childCount);
            for (int i = 0; i < childCount; i++)
            {
                diceParent.transform.GetChild(i).GetComponent<DiceRoller>().DestroySelf();
            }
        }
    }
}
