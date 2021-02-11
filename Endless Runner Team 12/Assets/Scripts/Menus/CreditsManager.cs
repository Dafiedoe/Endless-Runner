using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    private enum CreditsState
    {
        intro = 0,
        scrolling
    }

    [SerializeField] private CreditsState state = CreditsState.intro;
    [SerializeField] private float timer;
    [SerializeField] private List<TMP_Text> titleText = new List<TMP_Text>();
    [SerializeField] private List<float> introTime = new List<float>();
    [SerializeField] private int introIndex = 0;
    [SerializeField] private RectTransform scrollingObject;
    [SerializeField] private float scrollSpeed;

    private void Update()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case CreditsState.intro:
                if (timer >= introTime[introIndex])
                {
                    introIndex++;
                    if (introIndex >= introTime.Count)
                    {
                        state = CreditsState.scrolling;
                        titleText[introIndex - 1].gameObject.SetActive(false);
                        break;
                    }
                    titleText[introIndex].gameObject.SetActive(true);
                    titleText[introIndex - 1].gameObject.SetActive(false);
                    timer = 0f;
                }
                break;

            case CreditsState.scrolling:
                scrollingObject.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
                break;
        }
    }
}
