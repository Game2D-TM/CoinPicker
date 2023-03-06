using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Platformer.Gameplay;

public class ShowText : MonoBehaviour
{
    public TMP_Text tmpText;
    public string Name { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Name = gameObject.transform.name;
        if (gameObject.transform.name.Equals("deathText"))
        {
            tmpText.color = Color.red;
        }
        else if (Name.Equals("StagePoint"))
        {
            tmpText.color = Color.yellow;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Name.Equals("deathText"))
        {
            tmpText.text = "Death: " + RoundManager.DEATH_COUNT;
        }
        else if (Name.Equals("StagePoint"))
        {
            tmpText.text = "Round Point: " + RoundManager.Instance.RoundPoint;
        }
        else tmpText.text = "Point: " + RoundManager.Instance.TokenEarn;
    }
}
