using UnityEngine;

public class BananaLocation : MonoBehaviour
{
    public GameObject[] bananaLocation;
    public GameObject bananaPrefab;


    int rand;
    Vector3 newBananaLocation;
    public static BananaLocation Instance { get; private set; }
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
        Instantiate(bananaPrefab, SetNewBananaLocation(), Quaternion.identity);
        Instantiate(bananaPrefab, SetNewBananaLocation(), Quaternion.identity);
        Instantiate(bananaPrefab, SetNewBananaLocation(), Quaternion.identity);
    }

    public Vector3 SetNewBananaLocation()
    {
        rand = Random.Range(0, bananaLocation.Length);
        newBananaLocation = bananaLocation[rand].transform.position;
        return newBananaLocation;
    }
}
