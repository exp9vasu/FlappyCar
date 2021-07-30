using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin instance;

    public bool isRotating;
    public Vector3 initRot;
    public int coinCount;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isRotating = true;

        initRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, 1);
        }

        else
        {
            transform.eulerAngles = initRot;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flankCol"))
        {
            GameManager.instance.incrementScore();

            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(80,120,-60), ForceMode.Force);
 
            isRotating = false;

            Destroy(gameObject, 1);

           
        }
    }

   
}
