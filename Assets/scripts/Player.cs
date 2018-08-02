using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Vector2 Direction = new Vector2(1, 0);
    public float Speed = 10;
    private Vector3 moveTranslation;
    Rigidbody2D rb2D;
    playercontroller playerController;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<playercontroller>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (this.playerController.hasInputForMovement)
        {
            this.Direction = this.playerController.direction;
        }
        else { this.Direction = Vector3.zero; }

        this.moveTranslation = new Vector3(this.Direction.x, this.Direction.y) * Time.deltaTime * this.Speed;
        this.transform.position += new Vector3(this.moveTranslation.x, this.moveTranslation.y);

    }

}
