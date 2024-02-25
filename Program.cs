// using System;

class Program
{
    static int Main(string[] args)
    {

        string program = args[0];
        int length = program.Length;

        byte[] data = new byte[1024];
        int ptr = 0;
        int skobki = 0;

        for (int i = 0; i < length;)
        {
            switch (program[i])
            {
                case '>':
                    ptr++;
                    i++;
                    break;
                case '<':
                    ptr--;
                    if (ptr < 0)
                    {
                        return -1;
                    }
                    i++;
                    break;

                case '+':
                    if (data[ptr] == 255)
                    {
                        return -1;
                    }
                    i++;
                    data[ptr]++;
                    break;
                case '-':
                    if (data[ptr] == 0)
                    {
                        return -1;
                    }
                    data[ptr]--;
                    i++;
                    break;

                case '.':
                    // Console.WriteLine(data[ptr]);
                    // i++;
                    // break;
                    return -1;
                case ',':
                    // if(!int.TryParse(Console.ReadLine(), out int res) || res < 0 || res > 255){
                    //     return -1;
                    // };
                    // data[ptr] = (byte)res;
                    // i++;
                    // break;
                    return -1;

                case '[':
                    if (data[ptr] == 0)
                    {
                        skobki++;
                        do
                        {
                            i++;
                            if (i == program.Length)
                            {
                                return -1;
                            }
                            if (program[i] == '[')
                            {
                                skobki++;
                            }
                            if (program[i] == ']')
                            {
                                skobki--;
                            }
                        } while (skobki != 0);
                    }
                    i++;
                    break;

                case ']':
                    if (data[ptr] != 0)
                    {
                        skobki++;
                        do
                        {
                            if (i == 0)
                            {
                                return -1;
                            }
                            i--;
                            if (program[i] == '[')
                            {
                                skobki--;
                            }
                            if (program[i] == ']')
                            {
                                skobki++;
                            }
                        } while (skobki != 0);
                    }
                    i++;
                    break;
            }
        }

        return data[ptr];
    }
}
