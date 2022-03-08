using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -50f;

    [SerializeField] GameObject[] lasers;

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
        ProcessFiring();
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

    void SetLaserActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
         var emissionModule = laser.GetComponent<ParticleSystem>().emission;
         emissionModule.enabled = isActive;
        }
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
             SetLaserActive(true);
        }
        else
        {
             SetLaserActive(false);
        }
    
    }


}
