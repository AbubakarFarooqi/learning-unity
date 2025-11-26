using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform playerTransform;
    private Vector3 tempCamPosition;
    private float minX;
    private float maxX;
    void Start()
    {
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.minX = -22f;
        this.maxX = 22f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is called each frame but after all calculations of Update function -22
    void LateUpdate()
    {
        this.tempCamPosition = this.transform.position;
        if (this.playerTransform.position.x > this.minX && this.playerTransform.position.x < this.maxX)
        {
            this.tempCamPosition.x = this.playerTransform.position.x;
            this.transform.position = this.tempCamPosition;
        }
       
    }
}
