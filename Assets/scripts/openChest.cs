using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openChest : MonoBehaviour {

    public GameObject cratePrefab;
    public Text itemGained, holdKey;
    RandomItemGenerator itemGenerator;
    bool triggerStay = false;
    float crateTimer, maxTimer;


    private void Awake()
    {
        itemGenerator = GetComponent<RandomItemGenerator>();
    }

    // Use this for initialization
    void Start () {
        FloatingTextController.Initialize();
        itemGainedController.Initialize();
        crateTimer = 0f;
        maxTimer = 8f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Jump") && triggerStay)
        {
            if(crateTimer < maxTimer)
            {
                crateTimer += Time.deltaTime * 10f;
            }

            else
            {
                crateTimer = maxTimer;
                crateTimer += Time.deltaTime;
                //itemGainedController.CreateFloatingText("Gained the " + itemGenerator.GetRandomItem().ToString());
                CrateOpen();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            FloatingTextController.CreateFloatingText("Hold X!");
            //holdKey.text = "Hold X!";
            triggerStay = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            holdKey.text = "";
            triggerStay = false;
        }
    }

    public void CrateOpen()
    {
        itemGained.text = "Gained the " + itemGenerator.GetRandomItem();
        this.gameObject.SetActive(false);
    }
  
}
