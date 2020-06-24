using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;


public class Handedness : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputDeviceCharacteristics leftTrackedControllerFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;
        InputDeviceCharacteristics rightTrackedControllerFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

        List<InputDevice> foundLeftControllers = new List<InputDevice>();
        List<InputDevice> foundRightControllers = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(leftTrackedControllerFilter, foundLeftControllers);
        InputDevices.GetDevicesWithCharacteristics(rightTrackedControllerFilter, foundRightControllers);

        var LeftController = GameObject.Find("Left Hand");
        var RightController = GameObject.Find("Right Hand");

        if (foundLeftControllers.Count == 0)
            Destroy(LeftController);

        if (foundRightControllers.Count == 0)
            Destroy(RightController);

    }
}
