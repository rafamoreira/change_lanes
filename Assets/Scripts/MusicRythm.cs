using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRythm : MonoBehaviour
{

    public Transform[] musicCubes;

    void Start ()
	{
		//Select the instance of AudioProcessor and pass a reference
		//to this object
		AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		processor.onBeat.AddListener (onOnbeatDetected);
		processor.onSpectrum.AddListener (onSpectrum);
	}

	//this event will be called every time a beat is detected.
	//Change the threshold parameter in the inspector
	//to adjust the sensitivity
	void onOnbeatDetected ()
	{
		Debug.Log ("Beat!!!");
	}

	//This event will be called every frame while music is playing
	void onSpectrum (float[] spectrum)
	{
	    //The spectrum is logarithmically averaged
	    //to 12 bands
        foreach(GameObject mo in MusicSpawner.Instance.musicList){
            for (int mli = 0; mli < 2; ++mli){
                Transform curCubeList = mo.transform.GetChild(mli);

                for (int i = 0; i < spectrum.Length; ++i) {
                    Transform curCube = curCubeList.GetChild(i);
		    if (spectrum[i] < 0.01f){
			curCube.localScale = new Vector3(curCube.localScale.x, spectrum[i] * 200, curCube.localScale.z);
		    }
		    else{
			curCube.localScale = new Vector3(curCube.localScale.x, spectrum[i] * 20, curCube.localScale.z);        			
		    }

                }
            }
	    }
	}
}
