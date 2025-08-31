using Unity.Mathematics;
using UnityEngine;

public class RandomOrderLocation : MonoBehaviour
{
    public GameObject[] PossibleDeliveryLocation;
    public GameObject DeliveryLocationPrefab;
    public GameObject PizzaStorePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        deliveryLocation.y = 0;

        //recieve pizza location
        Vector3 pizzaStoreLocation = PossibleDeliveryLocation[randomPizzaStoreLocation].transform.position;
        pizzaStoreLocation.y = 0;

        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);
        Instantiate(PizzaStorePrefab, pizzaStoreLocation, quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
