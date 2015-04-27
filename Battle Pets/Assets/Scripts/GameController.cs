using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Player PlayerCharacter;
    public Player EnemyCharacter;

    DataController data;

    public List<Pet> AvailablePets;
    public List<Ability> AbilitiesList;

	// Use this for initialization
	void Start () {
        data = GameObject.FindObjectOfType<DataController>();
        AvailablePets = data.PetList;
              
        PlayerCharacter = CreateCharacter();
        EnemyCharacter = CreateCharacter();

	}
	
	// Update is called once per frame
	void Update () {       	
	}

    Player CreateCharacter()
    {
        

        Player NewPlayer;

        NewPlayer = new Player("Player", GetPets());

        return NewPlayer;
    }

    List<Pet>GetPets()
    {
        int maxPets = 4;
        
        List<Pet> PlayerPets = new List<Pet>();

        for (int i = 0; PlayerPets.Count < maxPets; i++)
        {
            int Chooser = Random.Range(0, AvailablePets.Count);

            PlayerPets.Add(AvailablePets[Chooser]);
            AvailablePets.Remove(AvailablePets[Chooser]);
        }

        return PlayerPets;
    }
}
