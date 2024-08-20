#pragma warning disable CS8321 // Local function is declared but never used
// Pruebas de https://github.com/dotnet/runtime/blob/main/src/libraries/System.Numerics.Tensors/src/System/Numerics/Tensors/netcore/TensorPrimitives.CosineSimilarity.cs
using System.Numerics.Tensors;

//Same2DimensionalArray();
//Same3DimensionalArray();

//SameArrayAnyDimension([1, 2]);
//SameArrayAnyDimension([1,2,3]);
//SameArrayAnyDimension([1, 2, 3, 4]);


// Easy way to represent vectors in 2D space https://www.desmos.com/calculator ex: (100t, 100t)

CosineSimilarity([100, 100], [1, 1]);    // Result: 1; Almost identical => "they point in the same direction"
CosineSimilarity([1, 100], [100, 1]);    // Result: 0,019998003; Diferent => "they point in different directions"
CosineSimilarity([1, 100], [50, 100]);   // Result: 0,89885443 ; Similar => "they point in similar directions"
CosineSimilarity([1, 100], [10, 5]);     // Result: 0,4561351; kinda similar/diferent => "they point in kinda similar/diferent directions"

CosineSimilarity([1, 100], [1, -100]);   // Result: -0,99980015; VERY Diferent => "they point in VERY different directions"


void Same2DimensionalArray()
{
    float[] Simple2DimensionVector = [1, 1];
    var result = TensorPrimitives.CosineSimilarity(x: Simple2DimensionVector, y: Simple2DimensionVector);

    Console.WriteLine("Same2DimensionalArray Result: " + result);
}


void Same3DimensionalArray()
{
    float[] Simple3DimensionVector = [1, 1, 1];
    var result = TensorPrimitives.CosineSimilarity(x: Simple3DimensionVector, y: Simple3DimensionVector);

    Console.WriteLine("Same3DimensionalArray Result: " + result);
}

void SameArrayAnyDimension(float[] vector)
{
    var result = TensorPrimitives.CosineSimilarity(x: vector, y: vector);

    Console.WriteLine($"SameArrayAnyDimension: {VectorToString(vector)} Result: {result}");
}

// What matters in cosine similarity is the "direction" of the vector, the angle between vectors, not their magnitude.
void CosineSimilarity(float[] x, float[] y)
{
    var result = TensorPrimitives.CosineSimilarity(x: x, y: y);
    
    Console.WriteLine("*************CosineSimilarity*********");
    Console.WriteLine($"x: {VectorToString(x)}");
    Console.WriteLine($"y: {VectorToString(y)}");
    Console.WriteLine($"Result: {result}");
    Console.WriteLine();
}

string VectorToString(float[] array)
{
    return $"[{string.Join(",", array)}]";
}