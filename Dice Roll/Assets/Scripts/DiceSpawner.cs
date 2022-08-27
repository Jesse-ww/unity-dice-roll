using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    private int spawnedDice;
    private int diceTotal;
    private int frameDiceTotal;

    [SerializeField]
    private Dice[] activeDice = new Dice[0];

    public GameObject DicePrefab;
    public Transform DiceSpawn;
    public Text TotalText;

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
        KeyboardInput();

        if(diceParent.transform.childCount != spawnedDice)
        {
            spawnedDice = diceParent.transform.childCount;
            activeDice = diceParent.GetComponentsInChildren<Dice>();
        }

        TotalText.text = string.Concat("Total: ", DiceTotal());
    }

    private int DiceTotal()
    {
        frameDiceTotal = 0;
        foreach(Dice die in activeDice)
        {
            frameDiceTotal += die.GetValue();
        }
        return frameDiceTotal;
    }

    private void KeyboardInput ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject dice = Instantiate(DicePrefab, DiceSpawn.transform.position, Quaternion.identity);
            dice.transform.SetParent(diceParent.transform);
            dice.GetComponent<DiceRoller>().Roll(DiceSpawn.position);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            int childCount = diceParent.transform.childCount;
            Debug.Log(childCount);
            for(int i = 0; i < childCount; i++)
            {
                diceParent.transform.GetChild(i).GetComponent<Dice>().DestroySelf();
            }
        }
    }
}
