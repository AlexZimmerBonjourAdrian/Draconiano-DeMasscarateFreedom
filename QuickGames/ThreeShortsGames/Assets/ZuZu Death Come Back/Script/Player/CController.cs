using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Zuzu
{ 
    public class CController : MonoBehaviour
    {
        [SerializeField] protected float _Speed = 5;
        // Start is called before the first frame update
        [SerializeField] protected Rigidbody2D _Rigidbody2D;
        //  private float _Acceleration = 0;
        [SerializeField] protected Vector2 _Move = Vector2.zero;
        //private float _DashSpeed = 0
        //private bool _IsInmortal = False
        //private time6 _Delay = false

        void Start()
        {
               _Rigidbody2D = GetComponent<Rigidbody2D>();
               _Speed = 20;
        }
        private void Dash()
        {
            return;
        }

        private float TimeDelay()
        {
            return 0;
        }

        public void Update()
        {
            Move();
        }
        public virtual void Move()
        {

            _Move.x = Input.GetAxis("Horizontal");

            _Move.y = Input.GetAxis("Vertical");

            _Move = new Vector2(_Move.x,_Move.y);

            _Move.Normalize();
        }

        public void FixedUpdate()
        {
            _Rigidbody2D.MovePosition(_Rigidbody2D.position + _Move * _Speed * Time.deltaTime);

        }


    }
}
