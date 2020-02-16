using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockDestroy : MonoBehaviour
{
    private float distance = 10;
    private float offset = -1;
    private int coins = 0;

    public Text coinText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.gameObject.name == "question(Clone)")
                {
                    coins += 1;
                    coinText.text = "" + coins;
                }

                Debug.Log("Destroyed" + hit.transform.gameObject.name);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
