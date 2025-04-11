using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorIndicator : MonoBehaviour
{
    [SerializeField] private Renderer myIndicator;
    [SerializeField] private Color defaultColor = Color.red;
    [SerializeField] private Color activatedColor = Color.green;
    [SerializeField] private PressurePlate myPlate;
  
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    

    // Start is called before the first frame update
    void Start()
    {
        if(myIndicator == null)
            myIndicator = GetComponent<Renderer>();
        myIndicator.material.color = defaultColor; 
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlate.IsCorrect())
        {
            ActivateIndicator();
        }
        else
        {
            DeactivateIndicator();
        }
    }

    private void ActivateIndicator()
    {
        myIndicator.material.color = activatedColor;
        OnActivate?.Invoke();
    } 
    private void DeactivateIndicator()
    {
        myIndicator.material.color = defaultColor;
        OnDeactivate?.Invoke();
    }
}
