using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameLogController : MonoBehaviour {

    public List<Text> AvalableLines;

	// Use this for initialization
	void Start () {
        AvalableLines[0].text = "Game Start";
        AvalableLines[1].text = "";
        AvalableLines[2].text = "";
        AvalableLines[3].text = "";
        AvalableLines[4].text = "";
        AvalableLines[5].text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewLog(string ToAdd)
    {
        AvalableLines[5].text = AvalableLines[4].text;
        AvalableLines[4].text = AvalableLines[3].text;
        AvalableLines[3].text = AvalableLines[2].text;
        AvalableLines[2].text = AvalableLines[1].text;
        AvalableLines[1].text = AvalableLines[0].text;
               

        AvalableLines[0].text = ToAdd;
    }

    
}
