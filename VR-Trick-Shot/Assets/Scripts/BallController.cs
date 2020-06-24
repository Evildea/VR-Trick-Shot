using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallController : XRGrabInteractable
{
    public BallMovement BallMovementController;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        BallMovementController.SetRelease();
    }
}
