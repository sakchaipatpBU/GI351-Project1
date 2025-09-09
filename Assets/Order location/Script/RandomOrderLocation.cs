using Unity.Mathematics;
using UnityEngine;

public class RandomOrderLocation : MonoBehaviour
{
    public static RandomOrderLocation Instance { get; private set; }

    public GameObject[] PossibleDeliveryLocation;
    public GameObject DeliveryLocationPrefab;
    public GameObject PizzaStorePrefab;

    Vector3 pizzaStoreLocation; 

    float minimumDistanceBetweenDeliveryLocationAndPizzaStore = 5f;

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
    
    public void RandomizeAndInstantiateOrderLocation() // random both store and delivery place
    {
        int randomDeliveryLocation;
        int randomPizzaStoreLocation;
        Vector3 deliveryLocation;

        do //prevent same location and less than min distance
        {
            randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);
            randomPizzaStoreLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);

            //delivery location
            deliveryLocation = PossibleDeliveryLocation[randomDeliveryLocation].transform.position;
            deliveryLocation.z = 0;

            //recieve pizza location
            pizzaStoreLocation = PossibleDeliveryLocation[randomPizzaStoreLocation].transform.position;
            pizzaStoreLocation.z = 0;


        } while (randomDeliveryLocation == randomPizzaStoreLocation || Vector3.Distance(deliveryLocation, pizzaStoreLocation) <= minimumDistanceBetweenDeliveryLocationAndPizzaStore);

        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);
        Instantiate(PizzaStorePrefab, pizzaStoreLocation, quaternion.identity);
    }
    
    public void RandomizeAndInstantiateDeliveryOnly() // random only delivery place
    {
        int randomDeliveryLocation;
        Vector3 deliveryLocation;
        
        do //prevent same location and lessthan min distance
        {
            randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);
            //randomPizzaStoreLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);

            //delivery location
            deliveryLocation = PossibleDeliveryLocation[randomDeliveryLocation].transform.position;
            deliveryLocation.z = 0;


        } while (deliveryLocation == pizzaStoreLocation || Vector3.Distance(deliveryLocation, pizzaStoreLocation) <= minimumDistanceBetweenDeliveryLocationAndPizzaStore);
        
        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);
        
    }
    
}
