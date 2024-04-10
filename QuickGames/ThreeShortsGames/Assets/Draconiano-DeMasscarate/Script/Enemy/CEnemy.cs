using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Zuzu
{

    public class CEnemy : MonoBehaviour, IDamage
    {
        //private GameObject _Player;
        //private  float _Speed = 1;
        //private Vector2 _Move = Vector2.zero;
        public float _life = 100;
        public bool IsDead = false;

        public void OnDamage(float damage)
        {
            SetLife(GetLife() - damage);
            CheckLife();
        }

        public void SetLife(float Life)
        {
            _life = Life;

        }
        public float GetLife()
        {
            return _life;

        }

        // Start is called before the first frame update
        void Start()
    {
       
      
                //if (_Player == null)
                //{ 
                //    _Player = GameObject.FindGameObjectWithTag("Player");
              
                //     //throw new ArgumentNullException("El valor no puede ser null");
                //}
        
            
        //catch (ArgumentNullException e)
        //  { 
        //        Debug.LogError("Error: el player no existe: " + e.Message);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void CheckLife()
    {
        if(_life<= 0)
        {
                Debug.Log("El Enemigo Esta muerto");    
                Destroy(gameObject);
        }
        else
        {
                Debug.Log("El Enemigo Esta vivo");
        }
    
    }

     
    }
}