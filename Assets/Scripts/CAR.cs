using UnityEngine;

public class CAR : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
