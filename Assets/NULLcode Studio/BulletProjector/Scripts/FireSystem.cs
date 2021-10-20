/**************************************************************************************************/
/** 	© 2017 NULLcode Studio. License: https://creativecommons.org/publicdomain/zero/1.0/deed.ru
/** 	Разработано в рамках проекта: http://null-code.ru/
/**                       ******   Внимание! Проекту нужна Ваша помощь!   ******
/** 	WebMoney: R209469863836, Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour {

	[SerializeField] private GameObject projectorWall;
	[SerializeField] private GameObject projectorEnemy;
	[SerializeField] private int maxProjectors = 50;
	private GameObject[] projectorsArray;
	private int tmpCount;
	private GameObject projector;

	void Start () 
	{
		projectorsArray = new GameObject[maxProjectors];
	}

	void Update () 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
		if (Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
			{
				Quaternion projectorRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);

				switch(hit.transform.gameObject.layer)
				{
				case 0: // номер слоя с плоскими объектами
					projector = projectorWall;
					break;
				case 1: // номер слоя с моделями персонажей или рельефных объектов
					projector = projectorEnemy;
					break;
				}
				print (projector.transform.gameObject.layer);
				if(projector == null) return;

				GameObject obj = Instantiate(projector, hit.point + hit.normal * 0.25f, projectorRotation) as GameObject;

				Destroy(projectorsArray[tmpCount]);
				projectorsArray[tmpCount] = obj;

				obj.transform.parent = hit.transform;

				Quaternion randomRotZ = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
				obj.transform.rotation = randomRotZ;

				if(tmpCount == maxProjectors-1) tmpCount = 0; else tmpCount++;
			}
		}
	}
}
