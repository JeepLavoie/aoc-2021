IEnumerable<string> testInputs = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
IEnumerable<string> realInputs = await File.ReadAllLinesAsync("input.txt");

Func<IEnumerable<string>, long> part1Solver = (IEnumerable<string> input) =>
{
    string gama = string.Empty, epsilon = string.Empty;

    int lenght = input.ElementAt(0).Length;

    for (int i = 0; i < lenght; i++)
    {
        int nb0 = input.Select(_ => _.ElementAt(i)).Count(_ => _ == '0');
        int nb1 = input.Count() - nb0;
        gama += Math.Max(nb0, nb1) == nb0 ? '0' : '1';
        epsilon += Math.Min(nb0, nb1) == nb0 ? '0' : '1';
    }

    return Convert.ToInt64(gama, 2) * Convert.ToInt64(epsilon, 2);
};

Func<IEnumerable<string>, long> part2Solver = (IEnumerable<string> input) =>
{
    string o2Number = string.Empty, co2Number = string.Empty;

    int lenght = input.ElementAt(0).Length;

    Func<string, int, bool, string> getQuantity = (string number, int index, bool rule) =>
    {
        List<string> subList = input.Where(_ => _.StartsWith(number)).ToList();
        if (subList.Count() == 1)
            return subList.First();

        int nb0 = subList.Select(_ => _.ElementAt(index)).Count(_ => _ == '0');
        int nb1 = subList.Count() - nb0;
        if (rule)
        {
            return number += Math.Max(nb0, nb1) == nb1 ? '1' : '0';
        }
        else
        {
            return number += Math.Min(nb0, nb1) == nb0 ? '0' : '1';
        }
    };

    for (int i = 0; i < lenght; i++)
    {
        if (o2Number.Length != lenght)
        {
            o2Number = getQuantity(o2Number, i, true);
        }

        if (co2Number.Length != lenght)
        {
            co2Number = getQuantity(co2Number, i, false);
        }
    }

    return Convert.ToInt64(o2Number, 2) * Convert.ToInt64(co2Number, 2);
};

Console.WriteLine("Part 1");
Console.WriteLine($"Test inputs : {part1Solver(testInputs)}");
Console.WriteLine($"Real inputs : {part1Solver(realInputs)}");

Console.WriteLine("Part 2");
Console.WriteLine($"Test inputs : {part2Solver(testInputs)}");
Console.WriteLine($"Real inputs : {part2Solver(realInputs)}");
