using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed;
    public CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.timer > 0)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                playerController.Move(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * speed * Time.deltaTime));
            }
        }       
    }

    void SpawnPlayer()
    {
        switch (GameManager.instance.playerShape)
        {
            case 1:
                if(this.gameObject.tag != "Cube")
                {
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if (this.gameObject.tag != "Sphere")
                {
                    Destroy(this.gameObject);
                }
                break;
            case 3:
                if (this.gameObject.tag != "Capsule")
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }

}
