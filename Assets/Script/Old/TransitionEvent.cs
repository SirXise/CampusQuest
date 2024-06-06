using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionEvent : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;
    Transform destination;

    private void MoveToGameScene(Transform toTransition)
    {
        Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();

        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(
                    toTransition,
                    destination.position - toTransition.position
                    );
        GameSceneManager.instance.SwitchScene(sceneNameToTransition, targetPosition);
    }
}
