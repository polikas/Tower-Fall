using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaClick : MonoBehaviour
{
    private bool isSelected;
    private UiManager instance;
    RaycastHit tempHit;
    public JengaPieces jengaData;
    private int clickIndex;
    private Material tempMat;
    private RaycastHit prevHit;
    // private int currentTurn;
    //private bool endTurn;
    private int turnIndex;
    private bool turnOver;
    // Start is called before the first frame update
    void Start()
    {
        turnOver = false;
        turnIndex = 0;
        clickIndex = 0;
        isSelected = false;
       // currentTurn = 0;
        //endTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selectionManagment();
        }

        decisionPhase();
    }
    public int  getTurnIndex() { return turnIndex; }
    public bool getTurnStatus() { return turnOver; }
    public void selectionManagment()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit,Mathf.Infinity, LayerMask.GetMask("Piece")))
        {
            turnOver = false;
            isSelected = true;
             Debug.Log(hit.collider.gameObject);
             if(isSelected)
             {
                tempHit = hit;
                if (clickIndex == 0)
                {
                    prevHit = tempHit;
                    tempMat = prevHit.collider.gameObject.GetComponent<Renderer>().material;
                }
                /*
                if(endTurn)
                {
                    currentTurn++;
                    instance.winText.text = currentTurn.ToString() + " : " + "Player 1 turn";
                }
                */
                print(prevHit.collider.name);
                print(jengaData.defaultMaterialsArray[0].name);
            }
            if (tempHit.collider.gameObject.tag == "wood")
            {
                tempHit.collider.gameObject.GetComponent<Renderer>().material = jengaData.selectedMaterialsArray[0];
                
                print("aaaaa");
            }
            else if (tempHit.collider.gameObject.tag == "marble")
            {
                tempHit.collider.gameObject.GetComponent<Renderer>().material = jengaData.selectedMaterialsArray[1];
            }
            if(tempHit.collider.name != prevHit.collider.name)
            {
               if(prevHit.collider.tag == "wood")
                {
                    prevHit.collider.gameObject.GetComponent<Renderer>().material = jengaData.defaultMaterialsArray[0];
                }
                if (prevHit.collider.tag == "marble")
                {
                    prevHit.collider.gameObject.GetComponent<Renderer>().material = jengaData.defaultMaterialsArray[1];
                }

                //tempMat = prevHit.collider.gameObject.GetComponent<Renderer>().material;
                prevHit = tempHit;
                print(tempMat.name);
                print("egine");
            }
        
        
            if(clickIndex>=0 && clickIndex <=1)
             clickIndex++;

        }
  
    }

    private void decisionPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSelected)
        {
            Debug.Log("Space");
            tempHit.collider.gameObject.SetActive(false);
            isSelected = false;
            turnOver = true;
            turnIndex++;
        }
    }
   
 
}
