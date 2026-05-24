using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public enum TransitionType
{
    Warp,
    Scene
}
public class Transition : MonoBehaviour
{  
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;
    Transform destination;

    void Start()
    {
        destination = transform.GetChild(1);

    }

    internal void InitiateTransition(Transform toTransition)
    {
    
        switch (transitionType)

        {

            case TransitionType.Warp:
                Unity.Cinemachine.CinemachineBrain currentCamera = 
                    Camera.main.GetComponent<Unity.Cinemachine.CinemachineBrain>();

                ((Unity.Cinemachine.CinemachineCamera)currentCamera.ActiveVirtualCamera).OnTargetObjectWarped(
                    toTransition,
                    targetPosition - toTransition.position
                    );



                toTransition.position = new Vector3(

                    destination.position.x,

                    destination.position.y,

                    toTransition.position.z

                );

                break;

            case TransitionType.Scene:

                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetPosition);

                break;  

        }

   

    }

} 

