using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    // public GameObject mainBaddie;
    [SerializeField] float xPos = 0;
    [SerializeField] float yPos = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x + xPos, player.transform.position.y + yPos, transform.position.z);
    }
}
