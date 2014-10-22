using UnityEngine;
using System.Collections;

namespace Platform{

public class SanicPlatformSpawner: PlatformSpawner {

	public bool sanic = false;


	protected override bool shouldSpawnNewSection() {

		if (sanic && base.shouldSpawnNewSection()){
			return true;
		}
		return false;
			
	}

}
}