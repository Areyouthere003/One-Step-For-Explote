using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinesManagerCreator : MonoBehaviour
{

    [SerializeField, Tooltip("Number of rows or columns in the escene")] int row = 0, column = 0;
    [SerializeField, Tooltip("Number of mines put in escene")] int MinesInstalled = 0; [Tooltip("Number of rows or columns in the escene")] int numMines = 0;
    [SerializeField, Tooltip("Validations")] bool valid01 = false, valid02 = false, putMinesInField = false;
    [SerializeField, Tooltip("Size of the group of mines")] GameObject group10x10, group6x6, group3x3;
    [SerializeField, Tooltip("List of Transform component for the current mines group")] Transform[] startPosMines;
    [SerializeField, Tooltip("Take the inicial positions for the current mines group")] Vector3[,] arrayPosMines;
    [SerializeField, Tooltip("Difficult and Scale for level")] int difficultLevel = 0, scaleArray = 0;
    [SerializeField] InitialValues initialValues;
    //[SerializeField, Tooltip("Add the Particle System GO for activation and desactivation")] GameObject _particlesSystem;

    GameObject inicialValues;
    int[,] minesField;
    float small = 9, medium = 36, big = 100;

    // Start is called before the first frame update
    void Start()
    {
        scaleArray = initialValues.SizeValue;
        difficultLevel = initialValues.DifficultValue;
        CreationMines();
        minesField = new int[row, column];
        arrayPosMines = new Vector3[row, column];

        int currentNumber = 1; //int incrementNumber = 1;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                minesField[i, j] = 0; //create in every camp a 0 for indicate array clean

                arrayPosMines[i, j] = startPosMines[currentNumber].position;
                currentNumber++;

                Debug.Log(arrayPosMines[i, j]);
                //if(i < incrementNumber)
                //{

                //}
                //else
                //{
                //    currentNumber = 10 * incrementNumber;
                //    incrementNumber++;
                //    currentNumber++;
                //    arrayPosMines[i, j] = startPosMines[currentNumber].position;
                //    currentNumber++;
                //}
            }
        }

        NumbersOfMines();
    }

    // Update is called once per frame
    void Update()
    {
        if(valid01)
        {
            GameObject prefab = Resources.Load("EarthMound") as GameObject;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //if (minesField[i, j] == 1)
                    //{
                        Debug.Log(arrayPosMines[i, j]);
                        GameObject create = Instantiate(prefab) as GameObject;
                        create.transform.position = arrayPosMines[i, j];
                        create.gameObject.GetComponent<LoadedMines>().MineLoad(minesField[i, j]);
                    //}
                    //else
                    //{
                    //    Debug.Log(arrayPosMines[i, j]);
                    //    GameObject create = Instantiate(prefab) as GameObject;
                    //    create.transform.position = arrayPosMines[i, j];
                    //    create.gameObject.GetComponent<LoadedMines>().MineLoad(minesField[i, j]);
                    //}
                }
            }

            //create.transform.position = ;
            valid01 = false;
        }

        PutMinesinField();

        if (valid02)
        {
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < column; j++)
            //    {
            //        Debug.Log(minesField[i, j]);
            //    }
            //}
            //_particlesSystem.GetComponent<LoadedMines>().SetParticlesOn(valid02);
            Debug.Log(scaleArray+ " " + difficultLevel);
            valid02 = false;
        }

    }

    private void CreationMines()
    {
        switch(scaleArray)
        {
            case 1:
                startPosMines = group3x3.GetComponentsInChildren<Transform>();
                row = 3; column = 3;
                break;
            case 2:
                startPosMines = group6x6.GetComponentsInChildren<Transform>();
                row = 6; column = 6; 
                break;
            case 3:
                startPosMines = group10x10.GetComponentsInChildren<Transform>();
                row = 10; column = 10;
                break;
        }
    }

    private void NumbersOfMines()
    {
        switch (difficultLevel)
        {
            case 1:
                if (scaleArray == 1)
                {
                    numMines = Convert.ToInt32((small * 23) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 2)
                {
                    numMines = Convert.ToInt32((medium * 23) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 3)
                {
                    numMines = Convert.ToInt32((big * 23) / 100);
                    putMinesInField = true;
                }
                break;
            case 2:
                if (scaleArray == 1)
                {
                    numMines = Convert.ToInt32((small * 43) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 2)
                {
                    numMines = Convert.ToInt32((medium * 43) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 3)
                {
                    numMines = Convert.ToInt32((big * 43) / 100);
                    putMinesInField = true;
                }
                break;
            case 3:
                if (scaleArray == 1)
                {
                    numMines = Convert.ToInt32((small * 56) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 2)
                {
                    numMines = Convert.ToInt32((medium * 56) / 100);
                    putMinesInField = true;
                }
                else if (scaleArray == 3)
                {
                    numMines = Convert.ToInt32((big * 56) / 100);
                    putMinesInField = true;
                }
                break;
        }
    }

    private void PutMinesinField()
    {
        if (putMinesInField)
        {
            do
            {
                int mineRow = Random.Range(0, row);
                int mineColumn = Random.Range(0, column);

                if (minesField[mineRow, mineColumn] == 0)
                {
                    minesField[mineRow, mineColumn] = 1;
                    Debug.Log("Fila " + mineRow + " Columna" + mineColumn);
                    MinesInstalled++;
                }
            }
            while (MinesInstalled < numMines);

            putMinesInField = false;
        }
    }

    public void GetScaleMines(int number)
    {
        scaleArray = number;
    }

    public void GetDifficultLevel(int number)
    {
        difficultLevel = number;
    }
}
