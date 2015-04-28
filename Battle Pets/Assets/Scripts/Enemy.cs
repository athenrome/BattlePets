using UnityEngine;
using System.Collections.Generic;

public class Enemy {

	public string EnemyName;
    public Pet CurrentPet;


    public Enemy(string En, Pet CurrPet)
    {
        EnemyName = En;
        CurrentPet = CurrPet;
    }
}
