using System;
using terrain_gen;

Console.WriteLine("Welcome to a prototype of terrain generation!\n");

const int matXSize = 200;
const int matYSize = 100;

Matrix templateMat = new Matrix(matXSize, matYSize, 0, 70);

Console.WriteLine("Template Matrix: \n\n" + templateMat.GenerateTerrain());

templateMat.Smooth(5);

Console.WriteLine("Smoothed Matrix: \n\n" + templateMat.GenerateTerrain());
