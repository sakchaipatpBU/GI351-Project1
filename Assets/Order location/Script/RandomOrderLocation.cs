using Unity.Mathematics;
using UnityEngine;

public class RandomOrderLocation : MonoBehaviour
{
    public static RandomOrderLocation Instance { get; private set; }

    public GameObject[] PossibleLocation;
    public GameObject DeliveryLocationPrefab;
    public GameObject PizzaStorePrefab;

    Vector3 pizzaStoreLocation;
    Vector3 deliveryLocation;

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


        do //prevent same location and less than min distance
        {
            randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleLocation.Length);
            randomPizzaStoreLocation = UnityEngine.Random.Range(0, PossibleLocation.Length);

            //delivery location
            deliveryLocation = PossibleLocation[randomDeliveryLocation].transform.position;
            deliveryLocation.z = 0;

            //recieve pizza location
            pizzaStoreLocation = PossibleLocation[randomPizzaStoreLocation].transform.position;
            pizzaStoreLocation.z = 0;


        } while (randomDeliveryLocation == randomPizzaStoreLocation || Vector3.Distance(deliveryLocation, pizzaStoreLocation) <= minimumDistanceBetweenDeliveryLocationAndPizzaStore);

        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);
        Instantiate(PizzaStorePrefab, pizzaStoreLocation, quaternion.identity);
    }

    public void ChangeDeliveryLocation() // random only delivery place
    {
        int randomDeliveryLocation;


        do //prevent same location and lessthan min distance
        {
            randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleLocation.Length);

            //delivery location
            deliveryLocation = PossibleLocation[randomDeliveryLocation].transform.position;
            deliveryLocation.z = 0;


        } while (deliveryLocation == pizzaStoreLocation || Vector3.Distance(deliveryLocation, pizzaStoreLocation) <= minimumDistanceBetweenDeliveryLocationAndPizzaStore);

        DeliveryLocationPrefab.transform.position = deliveryLocation;

    }

    public void ChangeStoreLocation() // random only delivery place
    {
        int randomStoreLocation;


        do //prevent same location and lessthan min distance
        {
            randomStoreLocation = UnityEngine.Random.Range(0, PossibleLocation.Length);

            //delivery location
            pizzaStoreLocation = PossibleLocation[randomStoreLocation].transform.position;
            pizzaStoreLocation.z = 0;


        } while (deliveryLocation == pizzaStoreLocation || Vector3.Distance(deliveryLocation, pizzaStoreLocation) <= minimumDistanceBetweenDeliveryLocationAndPizzaStore);

        PizzaStorePrefab.transform.position = pizzaStoreLocation;

    }

}