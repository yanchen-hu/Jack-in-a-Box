using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
	public GameObject game1;
	public GameObject game2;
	public GameObject game3;
	public GameObject game4;
	public CutSceneManager cutsceneManager;
	public float force = 5;

    private void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);		
			if (Physics.Raycast(ray,out hit, 100.0f))
			{
				if (hit.transform.tag == "DOOR")
				{
					PrintName(hit.transform.gameObject);
					cutsceneManager.PlayCutScene(CutSceneManager.CUTSCENE_TYPE.CUTSCENE_4);
					game1.SetActive(true);
				}
				else if(hit.transform.tag == "TYPEWRITER")
                {
					PrintName(hit.transform.gameObject);
					game2.SetActive(true);
				}
				else if (hit.transform.tag == "NEWSPAPER")
				{
					PrintName(hit.transform.gameObject);
					game3.SetActive(true);
				}
				else if (hit.transform.tag == "CLOSET")
				{
					PrintName(hit.transform.gameObject);
					game4.SetActive(true);
				}
			}
		}
	}
    
    private void PrintName(GameObject go)
    {
		print(go.name);
	}
	
	private void LaunchIntoAir(Rigidbody rig)
	{
		rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
	}
}
