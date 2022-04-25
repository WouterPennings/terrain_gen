using System;
using terrain_gen;

Console.WriteLine("Welcome to a prototype of terrain generation!\n");

int matXSize = 20;
int matYSize = 20;

Matrix templateMat = new Matrix(matXSize, matYSize, 0, 9);

Console.WriteLine("Template Matrix: \n\n" + templateMat);

templateMat.Smooth(1);

Console.WriteLine("Template Matrix: \n\n" + templateMat);
