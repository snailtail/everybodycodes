using System.Runtime.InteropServices;

List<string> names;

int[] parts = {1,2,3};
int pos;
foreach (var part in parts)
{
    var data = File.ReadAllLines($"input{part}.dat").Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
    names = data[0].Split(",").ToList();
    var instructions = data[1].Split(",");

    pos = 0;
    foreach (var instruction in instructions)
    {
        if (instruction[0] == 'L')
        {
            decreasePos(int.Parse(instruction[1..]), part);
        }
        else if (instruction[0] == 'R')
        {
            increasePos(int.Parse(instruction[1..]), part);
        }
        if(part == 3)
        {
            swapNameAtPos(instruction);
            pos = 0;
        }
    }

    Console.WriteLine($"Part {part} = {names[pos]}");
}
void decreasePos(int amount = 1, int part=1)
{
    switch (part)
    {
        case 1:
            pos -= amount; ;
            if (pos < 0)
            {
                pos = 0;
            }
            break;
        case 2:
            pos -= amount;
            if (pos < 0)
            {
                pos = names.Count + pos;
            }

            break;
        default:
            break;
    }

}

string swapNameAtPos(string instruction)
{
    int targetPos = int.Parse(instruction[1..]);
    if (instruction[0] == 'L')
    {
        targetPos *= -1;
    }
    
    if (targetPos >= names.Count)
    {
        targetPos = targetPos % names.Count;
    }
    while (targetPos < 0)
    {
        targetPos = names.Count + targetPos;
    }
    string temp = names[0];
    names[0] = names[targetPos];
    names[targetPos] = temp;

    return $"{names[targetPos]} swapped with {names[0]}";
}

void increasePos(int amount = 1, int part=1)
{

    switch (part)
    {
        case 1:
            pos += amount;
            if (pos >= names.Count)
            {
                pos = names.Count - 1;
            }
            break;
        case 2:
            pos += amount;
            pos %= names.Count;
            break;
    }
}