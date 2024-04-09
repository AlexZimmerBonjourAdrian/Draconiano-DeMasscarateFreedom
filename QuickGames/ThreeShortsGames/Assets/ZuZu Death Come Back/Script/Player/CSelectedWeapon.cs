using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSelectedWeapon : MonoBehaviour
{
    public GameObject Weapon;
    private SpriteRenderer Sprite;
    public List<DTDataWeapon> _List_WeaponComplete;
    public List<DTDataWeapon> _ListWeapon_Have;
    // Start is called before the first frame update
    void Start()
    {
      Sprite = Weapon.GetComponent<SpriteRenderer>();
      Sprite.sprite = _ListWeapon_Have[0].DT_Image_Weapon;
    }

    public void Update()
    {
        changeWeapon();
    }

    public List<DTDataWeapon> GetListWeaponComplete()
    {
        return _List_WeaponComplete;
    }
    public List<DTDataWeapon> GetListWeaponHave()
    {
        return _ListWeapon_Have;
    }
    // Update is called once per frame
    private void changeWeapon()
    {

       if(Input.GetKeyDown(KeyCode.Alpha1))
        {
             Sprite.sprite = _ListWeapon_Have[0].DT_Image_Weapon;  
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sprite.sprite = _ListWeapon_Have[1].DT_Image_Weapon;
        }
    }
}
