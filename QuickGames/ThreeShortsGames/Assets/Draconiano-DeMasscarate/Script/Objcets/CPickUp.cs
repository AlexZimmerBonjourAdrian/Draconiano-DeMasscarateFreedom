using UnityEngine;


namespace Draconiano.Items
{
    public class CPickUp : MonoBehaviour//, ICollect
    {
        // Start is called before the first frame update
        //public void OnCollection()
        //{

        //}
        [SerializeField]
        public GameObject WeponShootPrefab;


        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

}