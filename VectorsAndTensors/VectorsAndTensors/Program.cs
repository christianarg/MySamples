// See https://aka.ms/new-console-template for more information
using System.Numerics.Tensors;


var result = TensorPrimitives.CosineSimilarity(x: new float[] { 1, 2, 3 }, y: new float[] { 1, 2, 3 });

Console.WriteLine("Result: " + result);