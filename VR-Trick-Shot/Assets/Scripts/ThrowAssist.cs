using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR;

public class ThrowAssist : MonoBehaviour
{
    //public XRRaycastSubsystem xrRaycast;
    //private List<XRRaycastHit> m_RaycastHits = new List<XRRaycastHit>();

    private List<InputDevice> m_LeftHandedDevices = new List<InputDevice>();
    private List<InputDevice> m_RightHandedDevices = new List<InputDevice>();

    private void Update()
    {

        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, m_LeftHandedDevices);
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, m_RightHandedDevices);

        if (m_LeftHandedDevices.Count >= 1)
        {
            bool isPressed = false;
            m_LeftHandedDevices[0].TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);
        }

        if (m_RightHandedDevices.Count >= 1)
        {
            bool isPressed = false;
            m_RightHandedDevices[0].TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);
        }







        //if (Input.GetMouseButton(0))
        //{
        //    // Only raycast against feature points and the exact plane boundries
        //    var hitMask = TrackableType.FeaturePoint | TrackableType.PlaneWithinPolygon;
        //    if (xrRaycast.Raycast(Input.mousePosition, m_RaycastHits, hitMask))
        //    {
        //        Debug.Log("Hit something!");
        //    }
    }
}
