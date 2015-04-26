using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public string PlayerName;
    public List<Pet> PlayerPets;


	public Player(string Pn, List<Pet> Pets)
    {
        PlayerName = Pn;
        PlayerPets = Pets;
    }
}
