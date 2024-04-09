using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zuzu;

public class CNormalBullet : CGenericBullet
{
    private Rigidbody2D _Rig;
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

}
