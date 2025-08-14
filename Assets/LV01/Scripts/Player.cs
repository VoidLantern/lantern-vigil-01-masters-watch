using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
