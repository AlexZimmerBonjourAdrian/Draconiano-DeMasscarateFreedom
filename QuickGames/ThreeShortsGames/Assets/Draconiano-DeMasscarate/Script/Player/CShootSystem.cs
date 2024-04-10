using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zuzu
{

    public class CShootSystem : MonoBehaviour
{

    private CSelectedWeapon _selectedWeapon;
    protected int Ammo;
    protected int AmmoInMag;
    protected bool IsShoot;
    protected bool CanReload;
    protected int MultiplyWeapon;
    [SerializeField]
    private Transform ShootPoint;
    

    //Dispara el arma
    protected virtual void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsShoot = true;
            //Debug.LogWarning("Esta Disparando");
            CBulletManager.Inst.Spawn(ShootPoint.position, ShootPoint.right * (1200 * Time.deltaTime));

        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
             IsShoot = false;
            // Debug.LogWarning("No esta Disparando");
        }

    }
        private void Update()
        {
            Fire();
        }
        //Recarga el arma
    protected virtual void Reload()
    {
       Debug.Log("Reload");
    }
    
    //No poseo municion
    protected virtual void IsEmpty()
    {
            Debug.Log("IsEmpty");
    }

    //Tengo toda la municion?
    protected virtual void IsFull()
    {
      Debug.Log("Full");
    }

    //Tengo municion de reserva
    protected virtual void IsHaveAmmo()
    {

    }

    //Descueta la municion al momento de recargar y chequea si se puede recargar y si la municion que queda es correcta
    protected virtual void RecalculatedAmmo()
    {

    }
}

}



