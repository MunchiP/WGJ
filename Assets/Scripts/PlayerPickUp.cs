using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
 public GameObject carriedObject { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wool") && carriedObject == null)
        {
            carriedObject = collision.gameObject;
            carriedObject.transform.SetParent(transform); 
            carriedObject.transform.localPosition = new Vector3(0.5f, 0, 0); 
        }
    }

    public void DropObject(Vector3 dropPosition)
    {
        if (carriedObject != null)
        {
            carriedObject.transform.SetParent(null);
            carriedObject.transform.position = dropPosition;
            carriedObject = null;
        }
    }

}
