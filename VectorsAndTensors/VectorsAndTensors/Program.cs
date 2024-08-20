#pragma warning disable CS8321 // Local function is declared but never used
using System.Numerics.Tensors;
using System.Text;

Same2DimensionalArray();
Same3DimensionalArray();

SameArrayAnyDimension([1, 2]);
SameArrayAnyDimension([1,2,3]);
SameArrayAnyDimension([1, 2, 3, 4]);

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

string VectorToString(float[] array)
{
    return $"[{string.Join(",", array)}]";
}