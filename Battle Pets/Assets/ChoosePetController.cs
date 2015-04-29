using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoosePetController : MonoBehaviour {

    PlayerController PlayerChar;
    GameController game;

    public Text PetText1;
    public Text PetText2;
    public Text PetText3;

    List<Pet> UnusedPets;

    

	// Use this for initialization
	void Start () {
        game = GameObject.FindObjectOfType<GameController>();
        PlayerChar = GameObject.FindObjectOfType<PlayerController>();
        Hide();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show()
    {
        gameObject.SetActive(true);
        

        
        UnusedPets = PlayerChar.PlayerChar.PlayerPets;
        
        PetText1.text = "Choose: " + UnusedPets[0].PetName;
        
        PetText2.text = "Choose: " + UnusedPets[1].PetName;
        
        PetText3.text = "Choose: " + UnusedPets[2].PetName;
        

        
        
    }

    public void ChoosePet1()
    {
        PlayerChar.CurrentPet = UnusedPets[0];
        print("Player Chose: " + UnusedPets[0].PetName);
        game.GameUI.UpdateUI();
        Hide();
    }
    public void ChoosePet2()
    {
        PlayerChar.CurrentPet = UnusedPets[1];
        print("Player Chose: " + UnusedPets[1].PetName);
        game.GameUI.UpdateUI();
        Hide();
    }
    public void ChoosePet3()
    {
        PlayerChar.CurrentPet = UnusedPets[2];
        print("Player Chose: " + UnusedPets[2].PetName);
        game.GameUI.UpdateUI();
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
