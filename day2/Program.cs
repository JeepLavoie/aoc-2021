IEnumerable<Navigation> testInputs = ParseInput(new List<string> { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });
IEnumerable<Navigation> realInputs = ParseInput((await File.ReadAllLinesAsync("input.txt")));

Func<IEnumerable<Navigation>, int> resolvePart1 = (IEnumerable<Navigation> inputs) =>
{
    int h = 0, depth = 0;

    foreach (Navigation input in inputs)
    {
        switch (input.Direction)
        {
            case Direction.Forward:
                h += input.Units;
                break;
            case Direction.Down:
                depth += input.Units;
                break;
            case Direction.Up:
                depth -= input.Units;
                break;
        }
    }
    return h * depth;
};


Func<IEnumerable<Navigation>, int> resolvePart2 = (IEnumerable<Navigation> inputs) =>
{
    int h = 0, depth = 0, aim = 0;

    foreach (Navigation input in inputs)
    {
        switch (input.Direction)
        {
            case Direction.Forward:
                h += input.Units;
                depth += input.Units * aim;
                break;
            case Direction.Down:
                aim += input.Units;
                break;
            case Direction.Up:
                aim -= input.Units;
                break;
        }
    }
    return h * depth;
};

Console.WriteLine("Part 1");
Console.WriteLine($"Test Results {resolvePart1(testInputs)}");
Console.WriteLine($"Test Results {resolvePart1(realInputs)}");
Console.WriteLine("Part 2");
Console.WriteLine($"Test Results {resolvePart2(testInputs)}");
Console.WriteLine($"Test Results {resolvePart2(realInputs)}");

IEnumerable<Navigation> ParseInput(IEnumerable<string> input) =>
 input.Select(_ =>
 {
     string[] subInput = _.Split(' ');
     return new Navigation((Direction)Enum.Parse(typeof(Direction), subInput[0], ignoreCase: true), int.Parse(subInput[1]));
 });

enum Direction
{
    Forward,
    Down,
    Up,
}

record struct Navigation(Direction Direction, int Units);
