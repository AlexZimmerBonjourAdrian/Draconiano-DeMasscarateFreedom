using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace Core.AI
{
            public abstract class CEnemyAction : Action
            {
            protected Rigidbody2D body;
            protected float smoothDamp;
            protected Vector3 currentVelocity;
           // protected Transform playerTransform;

            [SerializeField]
            protected Transform targetEnemy;

            [SerializeField]
            protected float ShootDelay = 0.5f;
            [SerializeField]
            protected LayerMask Mask;

            [SerializeField]
            private float _currentHealth;

            protected GameObject _Player;
            protected float _Speed = 1;
            private Vector2 _Move = Vector2.zero;
            // protected CDataEnemy DataEnemy;

            // Start is called before the first frame update
            void Start()
            {
                if (_Player == null)
                {
                    _Player = GameObject.FindGameObjectWithTag("Player");

                    //throw new ArgumentNullException("El valor no puede ser null");
                }
            }

            // Update is called once per frame
            void Update()
            {
          

     
        }
    }
}

