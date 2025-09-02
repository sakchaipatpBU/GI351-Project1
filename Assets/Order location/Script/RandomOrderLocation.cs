using Unity.Mathematics;
using UnityEngine;

public class RandomOrderLocation : MonoBehaviour
{
    public static RandomOrderLocation Instance { get; private set; }

    public GameObject[] PossibleDeliveryLocation;
    public GameObject DeliveryLocationPrefab;
    public GameObject PizzaStorePrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomizeAndInstantiateOrderLocation()
    {
        int randomDeliveryLocation;
        int randomPizzaStoreLocation;
        do
        {
            randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);
            randomPizzaStoreLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);
        } while (randomDeliveryLocation == randomPizzaStoreLocation);

        //delivery location
        Vector3 deliveryLocation = PossibleDeliveryLocation[randomDeliveryLocation].transform.position;
        deliveryLocation.z = 0;

        //recieve pizza location
        Vector3 pizzaStoreLocation = PossibleDeliveryLocation[randomPizzaStoreLocation].transform.position;
        pizzaStoreLocation.z = 0;

        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);
        Instantiate(PizzaStorePrefab, pizzaStoreLocation, quaternion.identity);
    }
    
}
