using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallController : XRGrabInteractable
{
    //private Vector3 InteractorPosition = Vector3.zero;
    //private Quaternion InteractorRotation = Quaternion.identity;
    public BallMovement BallMovementController;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        //StoreInteractor(interactor);

        //interactor.attachTransform.position = transform.position;
        //interactor.attachTransform.rotation = transform.rotation;

    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        //ClearInteractor(interactor);

        //interactor.attachTransform.localPosition = InteractorPosition;
        //interactor.attachTransform.localRotation = InteractorRotation;

        BallMovementController.SetState("Release");
    }

    //private void StoreInteractor(XRBaseInteractor interactor)
    //{
    //    InteractorPosition = interactor.attachTransform.localPosition;
    //    InteractorRotation = interactor.attachTransform.localRotation;
    //}

    //private void ClearInteractor(XRBaseInteractor interactor)
    //{
    //    InteractorPosition = Vector3.zero;
    //    InteractorRotation = Quaternion.identity;
    //}
}
