using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//Source: https://docs.unity3d.com/Manual/WheelColliderTutorial.html


public class CarControllerScript : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
        
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    // check if collision game obj has person script
    // if yes, reload scene

        WalkingScript walkingScript = collision.gameObject.GetComponent<WalkingScript>();

        if(walkingScript != null)
        { 
            UIManager.instance.SetFeedbackText(TextStyle.RED, "You hit a person! Restarting...");
            StartCoroutine(RestartTimer());
        }

    }

    IEnumerator RestartTimer() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}