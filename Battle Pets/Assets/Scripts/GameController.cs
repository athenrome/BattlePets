using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {


     public PlayerController PlayerCharacter;
     public EnemyController EnemyCharacter;
     public GameObject ChoosePet;
     public UIController GameUI;
     public GameObject GameOverScreen;

    DataController data;

    public List<Pet> AvailablePets;
    public List<Ability> AbilitiesList;

	// Use this for initialization
	void Start () {
        GameUI = GameObject.FindObjectOfType<UIController>();
        data = GameObject.FindObjectOfType<DataController>();
        PlayerCharacter = GameObject.FindObjectOfType<PlayerController>();
        EnemyCharacter = GameObject.FindObjectOfType<EnemyController>();

        AvailablePets = data.PetList;

        GameOverScreen.SetActive(false);
            
        PlayerCharacter.PlayerChar = CreateCharacter();
        
        EnemyCharacter.Character = new Enemy("Enemy", AvailablePets[Random.Range(0, AvailablePets.Count)]);
        

        

	}
	
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

	// Update is called once per frame
	void Update () {       	
	}

    public Player CreateCharacter()
    {
        Player NewPlayer;

        NewPlayer = new Player("Player", GetPets());

        return NewPlayer;
    }

    

    List<Pet>GetPets()
    {
        int maxPets = 3;
        
        List<Pet> PlayerPets = new List<Pet>();

        for (int i = 0; PlayerPets.Count < maxPets; i++)
        {
            int Chooser = Random.Range(0, AvailablePets.Count);

            PlayerPets.Add(AvailablePets[Chooser]);
            //AvailablePets.Remove(AvailablePets[Chooser]);
        }

        return PlayerPets;

    }
}
