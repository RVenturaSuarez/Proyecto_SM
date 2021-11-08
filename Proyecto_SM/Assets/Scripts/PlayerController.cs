using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range (1, 100)]
    public float speed;
    [Range(1, 200)]
    public float rotationSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Animator _animator;
    private GameObject interactuableObject;
    public GameObject objectPoint;
    [SerializeField] private Button interactButton;
    [SerializeField] private FixedJoystick _fixedJoystick;



    


    // Start is called before the first frame update
    void Start()
    {
       // _animator = GetComponent<Animator>();
       interactButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Capturamos el valor de axis en cada variable.
        horizontalInput = _fixedJoystick.Horizontal;
        verticalInput = _fixedJoystick.Vertical;
        
        // Modificamos los parametros Vel_X y Vel_Y del animator.
        /*_animator.SetFloat("Vel_X", horizontalInput);
        _animator.SetFloat("Vel_Y", verticalInput);*/
        
        // Lógica para mover el personaje.
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        
        // Lógica rotar personaje.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        
    }

    // Lógica de activación/desactivación del botón de interactuar.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactuable"))
        {
            interactButton.gameObject.SetActive(true);
            interactuableObject = other.gameObject;
        }
        else if (other.CompareTag("Extintor"))
        {
            other.transform.parent = objectPoint.transform;
            other.transform.position = objectPoint.transform.position;
            
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactuable"))
        {
            interactButton.gameObject.SetActive(false);
            interactuableObject = null;
        }
    }

    public void InteractWith()
    {
        GameManager.instance.Interact();
    }


    public GameObject GetInteractableObject()
    {
        return interactuableObject;
    }

}
