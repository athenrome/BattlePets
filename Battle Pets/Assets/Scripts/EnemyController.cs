using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    GameController game;
    public Player EnemyCharacter;
    public GameObject PetCharacter;

	// Use this for initialization
	void Start () {

        EnemyCharacter = game.EnemyCharacter;

        game = GameObject.FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
