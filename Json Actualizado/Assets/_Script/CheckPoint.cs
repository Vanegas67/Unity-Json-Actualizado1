using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool Activated = false;
    public static CheckPoint activateCheckPoint;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Activated = true;
        activateCheckPoint = this;

        PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);

        PlayerPrefs.Save();

        Debug.Log("Respawn Activo");

    }
}
