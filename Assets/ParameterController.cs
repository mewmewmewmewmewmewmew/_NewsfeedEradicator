using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParameterController : MonoBehaviour
{
    // Reference to the FMOD event
    public string fmodEvent = "event:/GameAudio"; // Replace with your FMOD event path
    public float health = 0;
    public float _gameState = 0;
    public bool ChangeState = false;

    private FMOD.Studio.EventInstance eventInstance;

    void Start()
    {
        // Create an instance of the FMOD event
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        eventInstance.start();
    }

    // Function to modify the parameter
    public void SetParameter(string paramName, float value)
    {
        eventInstance.setParameterByName(paramName, value);
    }

    void Update()
    {
        // Example: Changing the parameter value based on some condition
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health+= + .1f;
            SetParameter("HPRatio", health); // Replace "MyParameter" with your actual parameter name
        }
        // Example: Changing the parameter value based on some condition
        if (Input.GetKeyDown(KeyCode.W))
        {
            health -= .1f;
            SetParameter("HPRatio", health); // Replace "MyParameter" with your actual parameter name
        }

        if(ChangeState)
        {
            SetParameter("HPRatio", health);
            SetParameter("GameMusic", _gameState);
            ChangeState= false;
        }


    }

    private void OnDestroy()
    {
        // Make sure to stop and release the event instance when the object is destroyed
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        eventInstance.release();
    }
}
