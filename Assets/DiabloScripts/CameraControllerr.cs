using UnityEngine;
using System.Collections;
public class CameraControllerr : MonoBehaviour
{
    public GameObject player;   
    public float offsetX = -5;  
    public float offsetZ = 0;  
    public float maximumDistance = 2; 
    public float playerVelocity = 10;

    private float movementX;
    private float movementZ;
    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x + offsetX,transform.position.y,player.transform.position.z + offsetZ);
        transform.LookAt(player.transform);
    }
    // Update is called once per frame
    void Update()
    {
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x)) / maximumDistance;
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z)) / maximumDistance;
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
    }
}