using UnityEngine;

public class ColaLocation : MonoBehaviour
{
    public GameObject[] colaLocation;
    public GameObject speedItemPrefab;


    int rand;
    Vector3 newColaLocation;
    public static ColaLocation Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Instantiate(speedItemPrefab, SetNewColaLocation(), Quaternion.identity);
    }

    public Vector3 SetNewColaLocation()
    {
        rand = Random.Range(0, colaLocation.Length);
        newColaLocation = colaLocation[rand].transform.position;
        return newColaLocation;
    }
}
