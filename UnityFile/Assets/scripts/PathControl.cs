using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControl : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;



    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float i = (float)0.1;
        while (i < 1)
        {
            m_Red = i;

            m_Green = 1-i;

            m_Blue = 1;

            //Set the Color to the values gained by index
            m_NewColor = new Color(m_Red, m_Green, m_Blue);

            //Set the SpriteRenderer to the Color defined by the index
            m_SpriteRenderer.color = m_NewColor;

            i += (float)(0.01);
            if (i == 1)
            {
                i = (float)0.1;
            }
        }


    }
}
