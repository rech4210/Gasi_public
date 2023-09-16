using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignCar : MonoBehaviour
{
    public GameObject cardPrefab;
    public int numberOfCards = 5;
    public float spacing = 10f;

    private void Start()
    {
        GenerateCards();
        AlignChildrenHorizontally();
    }

    private void GenerateCards()
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform);
            // Set the position of the card relative to the canvas
            card.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    private void AlignChildrenHorizontally()
    {
        // Get the total width of all child cards plus the spacing between them
        float totalWidth = numberOfCards * cardPrefab.GetComponent<RectTransform>().rect.width + (numberOfCards - 1) * spacing;
        // Calculate the starting X position to align them in the middle
        float startX = -totalWidth / 2f + cardPrefab.GetComponent<RectTransform>().rect.width / 2f;

        // Loop through each child and set their positions
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform card = transform.GetChild(i);
            // Set the X position of the card
            card.GetComponent<RectTransform>().anchoredPosition = new Vector2(startX + i * (card.GetComponent<RectTransform>().rect.width + spacing), 0f);
        }
    }
}
