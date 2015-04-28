using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    GameController game;
    public Player PlayerChar;
    public GameObject PetGameobject;
    Pet CurrentPet;



	// Use this for initialization
	void Start () {
        game = GameObject.FindObjectOfType<GameController>();
        
        CurrentPet = PlayerChar.PlayerPets[0];

        

        ActivateAbility1();

	}
	


    void AttackOpponent(Ability ActiveAbility)
    {
        game.EnemyCharacter.RecieveAttack(ActiveAbility);
    }

    

    public void ActivateAbility1()
    {
        print("1");
        AttackOpponent(CurrentPet.PetAbilities[0]);
    }

    public void ActivateAbility2()
    {
        print("2");
        AttackOpponent(CurrentPet.PetAbilities[1]);
    }

    public void ActivateAbility3()
    {
        print("3");
        AttackOpponent(CurrentPet.PetAbilities[2]);
    }

    public void ActivateAbility4()
    {
        print("4");
        AttackOpponent(CurrentPet.PetAbilities[3]);
    }

    

	// Update is called once per frame
	void Update () {
	
	}
}
