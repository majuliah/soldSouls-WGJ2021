using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;

    public bool invertXRotation;

    private float curXRot;

    void Start() 
    {
      Cursor.lockState = CursorLockMode.Locked;  
    }

    void LateUpdate ()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * lookSensitivity;
        //rotacionando o player em esquerda e direita


        //adicionando cima e baixo de acordo com o valor atual da variável:
        if(invertXRotation)
        {
            curXRot += y * lookSensitivity;
        } else
        {
            curXRot -= y * lookSensitivity;
        }
        
        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);
        //certificando que está no mínimo e máximo a rotação do x

        Vector3 clampedAngle = camAnchor.eulerAngles;
        //setando a rotação atual
        
        clampedAngle.x = curXRot;
        //setando pra ser o x a rotação atual
        
        camAnchor.eulerAngles = clampedAngle;
        //aplicando a rotação da câmera

    }
}
