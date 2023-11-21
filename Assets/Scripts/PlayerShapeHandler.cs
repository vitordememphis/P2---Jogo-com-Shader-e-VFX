using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject notPlayer1, notPlayer2;

    public void SelectPlayerShape()
    {
        if(!player.activeInHierarchy)
        {
            player.SetActive(true);
            notPlayer1.SetActive(false);
            notPlayer2.SetActive(false);
        }
    }

    public void SelectCube()
    {
        GameManager.instance.playerShape = 1;        
    }

    public void SelectSphere()
    {
        GameManager.instance.playerShape = 2;
    }


    public void SelectCapsule()
    {
        GameManager.instance.playerShape = 3;   
    }
}
