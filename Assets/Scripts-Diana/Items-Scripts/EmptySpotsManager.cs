using UnityEngine;

public class EmptySpotsManager : MonoBehaviour
{
    //public EmptySpotsManager instance;
    public int NumFilledSpots { get => _numFilledSpots; set => _numFilledSpots = value; }
    public int NumEmptySpots { get => _numEmptySpots; }
    [SerializeField]
    private int _numFilledSpots = 0;  
    private int _numEmptySpots;

    /*
    private void Awake()
    {
        instance = this;
    }
    */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _numEmptySpots = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
