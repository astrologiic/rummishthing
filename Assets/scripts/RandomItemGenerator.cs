using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItemGenerator : MonoBehaviour {

    string[] adjective = new string[] { "absurd", "crazy", "exotic", "fanciful", "grotesque", "imaginative", "implausible" };
    string[] itemName = new string[] { "knickers", "slacks", "bloomers", "breeches", "britches", "chaps", "blue jeans" };
    string[] ending = new string[] { "wearing", "fashionably late", "teritary clothing", "middling use", "forced walking", "unspeakable normality", "royal business" };

    public string GetRandomItem()
    {
        int adjIndex = Random.Range(0, adjective.Length);
        int itemIndex = Random.Range(0, itemName.Length);
        int endingIndex = Random.Range(0, ending.Length);

        string itemWording =
            adjective[adjIndex] + " " +
            itemName[itemIndex] + " of " +
            ending[endingIndex]+ "!";

        return itemWording;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
