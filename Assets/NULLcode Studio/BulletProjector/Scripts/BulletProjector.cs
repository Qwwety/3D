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

public class BulletProjector : MonoBehaviour {

	[SerializeField] private float distanceTolerance = 0.05f;
	private float origNearClipPlane;
	private float origFarClipPlane;
	private Projector projector;

	void Start() 
	{
		projector = GetComponent<Projector>();
		origNearClipPlane = projector.nearClipPlane;
		origFarClipPlane = projector.farClipPlane;
		Late();
	}

	void Late()
	{
		Ray ray = new Ray(projector.transform.position + projector.transform.forward.normalized * origNearClipPlane, projector.transform.forward);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit, origFarClipPlane - origNearClipPlane, ~projector.ignoreLayers)) 
		{
			float dist = hit.distance + origNearClipPlane;
			projector.nearClipPlane = Mathf.Max(dist - distanceTolerance, 0);
			projector.farClipPlane = dist + distanceTolerance;
		}
	}
}
