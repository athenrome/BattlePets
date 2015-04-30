using UnityEngine;
using System.Collections.Generic;

public class PetController : MonoBehaviour {

    public Pet CurrentPet;
    public GameObject HeadObject;
    PlayerController PlayerChar;
    public List<Material> Colours;

	// Use this for initialization
	void Start () {
        
        PlayerChar = GameObject.FindObjectOfType<PlayerController>();
	}

    

    public void SetColour()
    {

        CurrentPet = PlayerChar.CurrentPet;

        Material NewColor = Colours[0];

        switch(CurrentPet.ElementType)
        {
            case ElementType.Air:
                NewColor = Colours[0];
                break;
            case ElementType.Earth:
                NewColor =  Colours[1];
                break;
            case ElementType.Fire:
                NewColor =  Colours[2];
                break;
            case ElementType.Water:
                NewColor =  Colours[3];
                break;
        }

        HeadObject.GetComponent<Renderer>().material = NewColor;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
