using UnityEngine;

public class SheepSavedCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "SheepSavedArea")
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
            SheepCounterManager.instance.AddSavedSheep();
        }
    }
}
