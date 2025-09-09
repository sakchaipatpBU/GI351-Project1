using UnityEngine;

public class LeanTweenScale : MonoBehaviour
{
    float duration = 1;
    [SerializeField] LeanTweenType looptype;
    [SerializeField] LeanTweenType looptype1;

    Vector3 ogScale;
    // Update is called once per frame
    void Start()
    {
        ogScale = gameObject.transform.localScale;
        LeanTScaleUp();
    
    }

    void LeanTScaleUp()
    {
        LeanTween.scale(gameObject, ogScale + new Vector3(1,1,1), duration).setEase(looptype).setOnComplete(LeanTScaleDown);
    }
    void LeanTScaleDown()
    {
            LeanTween.scale(gameObject, ogScale, duration).setEase(looptype).setOnComplete(LeanTScaleUp);
    }
    
}
