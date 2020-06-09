using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Text topLeft;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        topLeft = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        topLeft.text = "Heath: " + player.GetComponent<PlayerMovement>().health 
            + "\nSpells:" + player.GetComponent<PlayerMovement>().SpellsLeft;
    }
}
