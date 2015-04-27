using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    GameController game;
    public Player PlayerCharacter;
    public GameObject PetCharacter;

	// Use this for initialization
	void Start () {

        PlayerCharacter = game.PlayerCharacter;

        game = GameObject.FindObjectOfType<GameController>();

	}
	
    public void SpawnPet(int PetLocation)
    {
        RemovePet();
    }

    public void RemovePet()
    {
        
    }

    public void ActivateAbility1()
    {

    }

    public void ActivateAbility2()
    {

    }

    public void ActivateAbility3()
    {

    }

    public void ActivateAbility4()
    {

    }

    void FaceOpponent()
    {

    }

	// Update is called once per frame
	void Update () {
	
	}
}
