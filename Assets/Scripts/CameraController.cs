using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector2 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector2(playerPosition.x + offset, playerPosition.y);
        }
        else
        {
            playerPosition = new Vector2(playerPosition.x - offset, playerPosition.y);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime); 

        
    }
}
