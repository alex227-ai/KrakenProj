using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Camera myCamera;
    public GameObject player;
    Camera myCamera;
    // public GameObject mainBaddie;
    [SerializeField] float xPos = 0;
    [SerializeField] float yPos = 0;
    [SerializeField] float cameraSpeed = 5f;
    //public float lerpPosition = 0f;

    //public bool z = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        CameraRotation();

        //lerpPosition += Time.deltaTime * cameraSpeed;
        //myCamera.transform.rotation = Vector2.Lerp(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), lerpPosition);

    }

    private void FollowPlayer()
    {
        transform.position = new Vector3(player.transform.position.x + xPos, player.transform.position.y + yPos, transform.position.z);
        //Ray ray = myCamera.ViewportPointToRay(new Vector3(.5f,.5f));
        //RaycastHit hit;
    }

    private void CameraRotation()
    {
        
        if (Input.GetMouseButton(1))
        {
            float xPos = Input.GetAxis("Mouse X");
            print("Position x is: " + transform.rotation.x);
            transform.Rotate(0, xPos * cameraSpeed, 0);
           // z = true;
        }
        else if (Input.GetMouseButton(2))
        {
            float yPos = Input.GetAxis("Mouse Y");
            print("Position y is: " + transform.rotation.y);
            transform.Rotate(-yPos * cameraSpeed, 0, 0);

           // z = true;
        }

        
    }
}
