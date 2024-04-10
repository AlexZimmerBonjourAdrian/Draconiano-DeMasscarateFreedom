using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Jobs;

namespace Zuzu
{
    public class CArmShooter : MonoBehaviour
    {

        private Camera mainCam;
        public Vector3 mousePos;


        [SerializeField]
        private InputActionReference pointerPosition;
        void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            //  Weapon= GameObject.FindGameObjectWithTag("Weapon").GetComponent<Game>();
        }
        void Update()
        {
            //mousePos = pointerPosition.action.ReadValue<Vector2>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector2 rotation = mousePos - transform.position;

            float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotz);
        }


    }

}
