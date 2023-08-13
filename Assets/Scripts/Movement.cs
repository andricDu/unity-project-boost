using UnityEngine;

public class Movement : MonoBehaviour
{
    // Dependencies
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 200f;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
               audioSource.PlayOneShot(mainEngine, 1);
            }
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {

            ApplyRotation(-rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
