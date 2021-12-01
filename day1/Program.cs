List<int> testInput = new() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
IEnumerable<int> part1Inputes = (await File.ReadAllLinesAsync("input.txt")).Select(_ => int.Parse(_));

Func<IEnumerable<int>, int> increaseCount = (IEnumerable<int> inputs) =>
{
    return inputs.Zip(inputs.Skip(1).ToList(), (first, second) => first < second).Count(_ => _);
};

Func<IEnumerable<int>, int> slidingWindowsCount = (IEnumerable<int> inputs) =>
{
    IEnumerable<int> subInputs = inputs.Zip(inputs.Skip(1).Zip(inputs.Skip(2), (element1, element2) => element1 + element2), (first, second) => first + second);

    return subInputs.Zip(subInputs.Skip(1).ToList(), (first, second) => first < second).Count(_ => _);
};

Console.WriteLine("Part 1");
Console.WriteLine($"Number of Increase: {increaseCount(testInput)}");
Console.WriteLine($"Number of Increase: {increaseCount(part1Inputes)}");
Console.WriteLine("Part 2");
Console.WriteLine($"Number of Increase: {slidingWindowsCount(testInput)}");
Console.WriteLine($"Number of Increase: {slidingWindowsCount(part1Inputes)}");
