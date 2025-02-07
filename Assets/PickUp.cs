using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject targetObject;
    public GameObject itemHolder;
    public bool Pick;

    public TextMeshProUGUI text;

    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            targetObject = other.gameObject;
            
            if (Pick == false)
            {
                text.text = "Pick up";
            }
            else
            {
                text.text = "Drop";
            }
        }
        else
        {
            targetObject = null;
            text.text = "";
        }
    }

    private void getItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pick = !Pick;

            if (Pick == true && targetObject != null)
            {
                targetObject.transform.parent = itemHolder.transform;
                Rigidbody rb = targetObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                
            }
            else
            {
                targetObject.transform.parent = null;
                Rigidbody rb = targetObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                
            }
        }
        

        /*else
        {
            targetObject.transform.parent = null;
            Rigidbody rb = targetObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }*/

        
    }
    void Update()
    {
        getItem();
    }
}
