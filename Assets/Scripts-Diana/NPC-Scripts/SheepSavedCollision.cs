using UnityEngine;

public class SheepSavedCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "SheepSavedArea")
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
            SheepCounterManager.instance.AddSavedSheep();
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {

    //     if (collision.gameObject.tag == "SheepSavedArea")
    //     {
    //         GameObject parent = transform.parent.gameObject;
    //         Destroy(parent);
    //         SheepCounterManager.instance.AddSavedSheep();
    //     }
    // }
}
