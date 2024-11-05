using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    void Start()
    {
        RespawnAtCheckpoint();
        // Si hay datos guardados en PlayerPrefs, reposiciona al jugador
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            transform.position = new Vector2(x, y);
        }
    }

    public void RespawnAtCheckpoint()
    {
        if (CheckPoint.activateCheckPoint != null)
        {
            Vector2 checkpointPosition = new Vector2(
                PlayerPrefs.GetFloat("PlayerPosX"), 
                PlayerPrefs.GetFloat("PlayerPosY")
            );

            transform.position = checkpointPosition;
        }
        else
        {
            Debug.LogWarning("No hay un checkpoint activado para hacer respawn.");
        }
    }
}
