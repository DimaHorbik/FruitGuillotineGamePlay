using UnityEngine;

public class Apple:MonoBehaviour
{
    [SerializeField] GameObject leftPart, rightPart, fullPart,leftPartBak, rightPartBak, fullPartBak, splash;

    public void Hit(HitPlace place)
    {
        if (place == HitPlace.Full && !(place == HitPlace.Right && place == HitPlace.Left))
        {
            splash.SetActive(true);
            fullPart.GetComponent<Animation>().Play();
            leftPart.SetActive(false);
            rightPart.SetActive(false);
            leftPartBak.SetActive(false);
            rightPartBak.SetActive(false);

        }
        else
        {
            if (place == HitPlace.Left && !(place == HitPlace.Right && place == HitPlace.Full))
            {
                fullPart.SetActive(false);
                rightPart.SetActive(false);
                leftPart.GetComponent<Animation>().Play();
                fullPartBak.SetActive(false);
                rightPartBak.SetActive(false);
            }

            if (place == HitPlace.Right && !(place == HitPlace.Left && place == HitPlace.Full))
            {
                fullPart.SetActive(false);
                leftPart.SetActive(false);
                rightPart.GetComponent<Animation>().Play();
                fullPartBak.SetActive(false);
                leftPartBak.SetActive(false);
            }
        }
    }

    public enum HitPlace
    {
        
        Left, Right, Full
    }
}