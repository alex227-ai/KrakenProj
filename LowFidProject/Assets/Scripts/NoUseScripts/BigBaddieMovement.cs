using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBaddieMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float xPos = 0;
    [SerializeField] float yPos = 0;
    [SerializeField] float speedMovement = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xPos * speedMovement, player.transform.position.y + yPos, player.transform.position.z);
    }
}
