using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zuzu
{

    public class CEnemy : MonoBehaviour
    {
        private GameObject _Player;
        private  float _Speed = 1;
        private Vector2 _Move = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
       
      
                if (_Player == null)
                { 
                    _Player = GameObject.FindGameObjectWithTag("Player");
              
                     //throw new ArgumentNullException("El valor no puede ser null");
                }
        
            
        //catch (ArgumentNullException e)
        //  { 
        //        Debug.LogError("Error: el player no existe: " + e.Message);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
     {
            transform.position = Vector2.Lerp(transform.position, _Player.transform.position, _Speed*Time.deltaTime);

     }
}
}