using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour {

    public Pet CurrentPet;

	// Use this for initialization
	void Start () {
	
	}

    void SetColour()
    {
        switch(CurrentPet.ElementType)
        {
            case ElementType.Air:
                
                break;
            case ElementType.Earth:

                break;
            case ElementType.Fire:

                break;
            case ElementType.Water:

                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
