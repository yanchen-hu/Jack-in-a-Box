using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepiece : MonoBehaviour
{
    public enum PIECE_STATUS
    {
        NOT_LOCKED,
        LOCKED,
        SUCCESS,
    }

    public PIECE_STATUS pieceStatus;

    void Start()
    {
        pieceStatus = PIECE_STATUS.NOT_LOCKED;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Rigidbody rb;
                rb = hit.transform.GetComponent<Rigidbody>();
                if (rb != null && hit.transform.tag == "PIECE")
                {
                    if (hit.transform.name == this.gameObject.name)
                    {
                        this.pieceStatus = PIECE_STATUS.LOCKED;
                        print(hit.transform.name);
                    }
                }

            }

        }

        if (pieceStatus == PIECE_STATUS.LOCKED)
        {

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePosOnScreen = Input.mousePosition;
            mousePosOnScreen.z = screenPos.z;
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);            
            mousePosInWorld.y = 0;
            this.transform.position = mousePosInWorld;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            pieceStatus = PIECE_STATUS.SUCCESS;
        }
    }
}
