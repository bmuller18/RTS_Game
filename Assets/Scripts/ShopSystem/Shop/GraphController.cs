using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GraphController : MonoBehaviour
{
    public RectTransform graphContainer;
    public Sprite pointSprite;
    public RectTransform pointPrefab;

    private List<RectTransform> dataPoints = new List<RectTransform>();

    int maxXValue = 10;
    int maxYValue = 10;

    public TMP_InputField xInputField;
    public TMP_InputField yInputField;


    public void AddDataPoint()
    {
        float xValue = float.Parse(xInputField.text);
        float yValue = float.Parse(yInputField.text);
        // Calcula la posición relativa en el contenedor del gráfico
        float graphHeight = graphContainer.rect.height;
        float graphWidth = graphContainer.rect.width;

        float xPosition = xValue / maxXValue * graphWidth;
        float yPosition = yValue / maxYValue * graphHeight;

        // Crea el nuevo punto y lo ajusta a la posición en el gráfico
        RectTransform newPoint = Instantiate(pointPrefab);
        newPoint.SetParent(graphContainer, false);
        newPoint.anchoredPosition = new Vector2(xPosition, yPosition);

        // Establece el sprite para el punto y lo agrega a la lista de puntos
        newPoint.GetComponent<Image>().sprite = pointSprite;
        dataPoints.Add(newPoint);
    }
}

