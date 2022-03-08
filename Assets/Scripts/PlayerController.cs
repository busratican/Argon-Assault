using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -50f;

    float xThrow;
    float yThrow;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        ProcessTransation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessTransation()
    {
        float localX = transform.localPosition.x; 
        float localY = transform.localPosition.y; 
        float localZ = transform.localPosition.z; 

         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float newPosX = localX + xOffset;
        float clampedXPos = Mathf.Clamp(newPosX, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * moveSpeed;
        float newPosY = localY + yOffset;
        float clampedYPos = Mathf.Clamp(newPosY, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, localZ);
    }
}
