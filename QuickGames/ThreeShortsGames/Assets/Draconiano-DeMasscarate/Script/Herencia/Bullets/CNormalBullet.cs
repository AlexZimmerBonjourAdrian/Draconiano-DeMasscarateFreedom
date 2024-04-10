using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using Zuzu;

public class CNormalBullet : CGenericBullet
{
    private Rigidbody2D _Rig;
    private float _Damage = 30;
    private void SpeedAddImpulse()
    {
        _Rig = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        SpeedAddImpulse();
    }

    public override void AddVel(Vector3 vel)
    {
        _Rig.AddForce(vel, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            //if (other.gameObject != null)
            //{
               other.gameObject.GetComponent<IDamage>().OnDamage(_Damage);
                Debug.LogWarning("Collision Enemy");
            //}
        }
       Destroy(gameObject);
    }

   
}
