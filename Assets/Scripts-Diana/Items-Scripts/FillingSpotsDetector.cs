using UnityEngine;

public class FillingSpotsDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            EmptySpotsManager emptySpotsManager = parent.GetComponent<EmptySpotsManager>(); //ZonaEmpty
            emptySpotsManager.NumFilledSpots += 1;

            if(emptySpotsManager.NumFilledSpots >= emptySpotsManager.NumEmptySpots)
            {
                //Si todos los espacios fueron superpuestos con una jarra deshabilitar el game object con el collider donde están las ovejas

                GameObject zoneSheep1 = GameObject.Find("ZoneSheep1"); // OJO: conservar el nombre del GO
                
                zoneSheep1.transform.GetChild(0).transform.gameObject.SetActive(false);

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            EmptySpotsManager emptySpotsManager = parent.GetComponent<EmptySpotsManager>();
            emptySpotsManager.NumFilledSpots -= 1;
        }
    }
}
