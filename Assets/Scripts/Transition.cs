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
        Unity.Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Unity.Cinemachine.CinemachineBrain>();
        


        switch (transitionType)

        {

            case TransitionType.Warp:
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
                ((Unity.Cinemachine.CinemachineCamera)currentCamera.ActiveVirtualCamera).OnTargetObjectWarped(
                    toTransition,
                    targetPosition - toTransition.position
                    );


                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetPosition);

                break;  

        }

   

    }

} 

