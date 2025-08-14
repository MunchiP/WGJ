using UnityEngine;

public class JarPuzzleResetter : MonoBehaviour
{
    public Sprite unpressedButton;
    public Sprite pressedButton;
    [SerializeField]
    private Vector3[] jarsInitialPosition;
    private Transform[] jars;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Transform zone1 = transform.parent;

        //Encontrar GO Obstaculos
        Transform obstaculos = zone1.Find("Obstaculos");
        jarsInitialPosition = new Vector3[obstaculos.childCount];
        jars = new Transform[obstaculos.childCount];
        //Recorrer hijos de Obstaculos y guardar posicion
        for (int i = 0; i < obstaculos.childCount; i++)
        {
            jarsInitialPosition[i] = obstaculos.GetChild(i).position;
            jars[i] = obstaculos.GetChild(i);
        }
        //
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            SetPressButtonState(true);

            for (int i = 0; i < jarsInitialPosition.Length; i++)
            {                
                jars[i].position = jarsInitialPosition[i];
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetPressButtonState(false);                       
        }
    }

    private void SetPressButtonState(bool pressed)
    {
        if (pressed)
            GetComponent<SpriteRenderer>().sprite = pressedButton;
        else
            GetComponent<SpriteRenderer>().sprite = unpressedButton;

    }
}
