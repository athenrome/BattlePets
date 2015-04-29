using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIController : MonoBehaviour {

    GameController game;
    PlayerController PlayerCharacter;
    EnemyController EnemyCharacter;

    public Text Ability1Txt;
    public Text Ability2Txt;
    public Text Ability3Txt;
    public Text Ability4Txt;

    public Text PlayerPetName;
    public Text PlayerPetHealth;

    public Text EnemyPetName;
    public Text EnemyPetHealth;

    

	// Use this for initialization
	void Start () {
        game = GameObject.FindObjectOfType<GameController>();
        PlayerCharacter = GameObject.FindObjectOfType<PlayerController>();
        EnemyCharacter = GameObject.FindObjectOfType<EnemyController>();

        //UpdateUI();
	
	}

    public void UpdateUI()
    {
        PlayerPetName.text = PlayerCharacter.CurrentPet.PetName;
        PlayerPetHealth.text = PlayerCharacter.CurrentPet.PetHealth.ToString();

        EnemyPetName.text  = EnemyCharacter.CurrentPet.PetName;
        EnemyPetHealth.text = EnemyCharacter.CurrentPet.PetHealth.ToString();
               
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
