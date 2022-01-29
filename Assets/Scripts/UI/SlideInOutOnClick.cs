using UnityEngine;


public class SlideInOutOnClick : MonoBehaviour
{
    private RectTransform rectTransform;
    private bool isOut = false;

    [SerializeField] private LeanTweenType slideInTweenType;
    [SerializeField] private LeanTweenType slideOutTweenType;


    public void SlideInSlideOut()
    {
        if (isOut)
        {
            isOut = false;

            //slide in
            LeanTween.moveX(gameObject, -100, 1).setEase(slideInTweenType);
        }
        else
        {
            isOut = true;

            //slide out
            LeanTween.moveX(gameObject, 100, 1).setEase(slideOutTweenType);
        }
    }



    //// Update is called once per frame
    //private void Update()
    //{
    //    //if (Input.GetKeyDown("M") && notYetIn)
    //    //{
    //    //    LeanTween.moveX(gameObject, 128, 1).setEase(LeanTweenType.easeInBounce);
    //    //    notYetIn = false;
    //    //}

    //    //if (Time.realtimeSinceStartup > 2 && notYetIn)
    //    //{
    //    //    //slide in
    //    //    LeanTween.moveX(gameObject, 128, 1).setEase(fadeInTweenType);
    //    //    notYetIn = false;
    //    //}
    //    //else if (Time.realtimeSinceStartup > 4)
    //    //{
    //    //    //slide out
    //    //    LeanTween.moveX(gameObject, -128, 1).setEase(LeanTweenType.easeInBounce);
    //    //}
    //}
}