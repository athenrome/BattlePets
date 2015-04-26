using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Player PlayerCharacter;

    DataController data = new DataController();

    public List<Pet> AvailablePets = new List<Pet>();
    public List<Ability> AbilitiesList = new List<Ability>();

	// Use this for initialization
	void Start () {
        print(AvailablePets.Count);

        PlayerCharacter = CreatePlayer();
	}
	
	// Update is called once per frame
	void Update () {       	
	}

    Player CreatePlayer()
    {
        print("asdf" + AvailablePets.Count);

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

            PlayerPets.Add(AvailablePets[i]);
            AvailablePets.Remove(AvailablePets[i]);
        }

        return PlayerPets;
    }
}
