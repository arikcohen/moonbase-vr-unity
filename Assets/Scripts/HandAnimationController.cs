using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationController : MonoBehaviour
{

    public InputDeviceCharacteristics controllerType;
    public InputDevice thisController;

    private bool isControllerInitialized = false;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        InitializeController();        
        animatorController = GetComponent<Animator>();
    }

    void InitializeController() {
        List<InputDevice> controllerDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerType, controllerDevices);

        if (controllerDevices.Count > 0) {        
            thisController = controllerDevices[0];
            isControllerInitialized = true;
            Debug.Log(thisController.name + " detected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControllerInitialized) {
            InitializeController();
        }
        else {
            if (thisController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f )
            {
                Debug.Log(thisController.name + " trigger value " + triggerValue);
                animatorController.SetFloat("Trigger", triggerValue);
            }

            if (thisController.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            {
                Debug.Log(thisController.name + " grip value " + triggerValue);
                animatorController.SetFloat("Grip", gripValue);
            }
        }
        
    }
}
