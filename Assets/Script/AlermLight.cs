using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlermLight : MonoBehaviour {

    public static AlermLight _instance;

    public bool isAlerm = false;
    private Light _light;
    // Use this for initialization

    private float startIntensity = 0;

    private float endIntensity = 0.5f;

    private float targetIntensity ;

    private float weight = 1;

    //private Object[] alerts;
	void Start () {
		
	}
    private void Awake()
    {
        targetIntensity = endIntensity;
        _light = GetComponent<Light>();
        _instance = this;
        //alerts = GameObject.FindGameObjectsWithTag("alert");
    }

    // Update is called once per frame
    void Update ()
    {
        if (isAlerm) {

            //if (_light.intensity < targetIntensity) {
            //    _light.intensity = Mathf.Lerp(_light.intensity, targetIntensity, weight);
            //}
            //else {
            //    print(Mathf.Lerp(startIntensity, _light.intensity, weight));
            //    _light.intensity =Mathf.Lerp(startIntensity, _light.intensity, weight);
            //}

            //if() {
            //    targetIntensity = endIntensity;
            //}
            //else {
            //    targetIntensity = endIntensity;
            //}
            //targetIntensity = _light.intensity == startIntensity ? endIntensity : startIntensity;

            //_light.intensity = Mathf.Lerp(_light.intensity, targetIntensity, weight);
            _light.intensity = Mathf.Lerp(_light.intensity, targetIntensity, Time.deltaTime * weight);

            if (Mathf.Abs(_light.intensity - targetIntensity) < 0.05f) {
               if(targetIntensity.Equals(startIntensity) ){
                    targetIntensity = endIntensity;
                }else {

                    targetIntensity = startIntensity;
                }
            }
        }
        else {
            _light.intensity = 0;
        }
    }
}
