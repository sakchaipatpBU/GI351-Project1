using Unity.Mathematics;
using UnityEngine;

public class RandomOrderLocation : MonoBehaviour
{
    public GameObject[] PossibleDeliveryLocation;
    public GameObject DeliveryLocationPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomDeliveryLocation = UnityEngine.Random.Range(0, PossibleDeliveryLocation.Length);
        Vector3 deliveryLocation = PossibleDeliveryLocation[randomDeliveryLocation].transform.position;
        deliveryLocation.y = 0;

        Instantiate(DeliveryLocationPrefab, deliveryLocation, quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
