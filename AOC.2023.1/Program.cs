using System.Collections.Generic;
using System.Numerics;

namespace AOC._2023._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "DataBig.txt";

            string[] lines = ReadFile(filePath);

            int count = 0;
            for (int lineC = 0; lineC < lines.Length; lineC++)
            {
                string first = "0";
                for (int ch = 0; ch < lines[lineC].Length; ch++)
                {
                    if (CheckForNumberChar(lines[lineC][ch]))
                    {
                        first = lines[lineC][ch].ToString();
                        break;
                    }
                    if (CheckForNumberSpell(ch, lines[lineC]) != 0)
                    {
                        first = CheckForNumberSpell(ch, lines[lineC]).ToString();
                        break;
                    }
                    
                }

                string last = "0";
                for (int ch = lines[lineC].Length-1; ch >= 0; ch--)
                {
                    if (CheckForNumberChar(lines[lineC][ch]))
                    {
                        last = lines[lineC][ch].ToString();
                        break;
                    }
                    if (CheckForNumberSpell(ch, lines[lineC]) != 0)
                    {
                        last = CheckForNumberSpell(ch, lines[lineC]).ToString();
                        break;
                    }
                }
                count += Convert.ToInt32(string.Concat(first, last));
                Console.WriteLine("Calibration for line "+lineC+" is "+string.Concat(first, last));
            }
            Console.WriteLine("\n"+count);
        }
        static string[] ReadFile(string filePath)
        {
            try
            {
                int lineCount = 0;
                // Finds the amount of lines in a the data file
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

                Console.WriteLine("Line count is: " + lineCount);

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Sets up the array to storge the data
                    string[] lines = new string[lineCount];

                    // Makes a forloop to scan in all the data
                    for (int i = 0; i < lineCount; i++)
                    {
                        lines[i] = sr.ReadLine();
                    }
                    /*foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }*/
                    return lines;
                }

            }
            catch
            {
                Console.WriteLine("Did not find the file");
                Environment.Exit(-1);
                return null;
            }
        }

        static bool CheckForNumberChar(char ch)
        {
            switch (ch)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }
        static int CheckForNumberSpell(int index, string line)
        {
            switch (line[index])
            {
                case 'o':
                    try {
                        if (line[index + 1] == 'n' && line[index + 2] == 'e')
                        {
                            return 1;
                        }
                        return 0;
                    }
                    catch 
                    { 
                        return 0;
                    }
                    
                case 't':
                    try
                    {
                        if (line[index + 1] == 'w' && line[index + 2] == 'o')
                        {
                            return 2;
                        }
                        if (line[index + 1] == 'h' && line[index + 2] == 'r' && line[index + 3] == 'e' && line[index + 4] == 'e')
                        {
                            return 3;
                        }
                        return 0;
                    }
                    catch
                    {
                        return 0;
                    }
                    
                case 'f':
                    try
                    {
                        if (line[index + 1] == 'o' && line[index + 2] == 'u' && line[index + 3] == 'r')
                        {
                            return 4;
                        }
                        if (line[index + 1] == 'i' && line[index + 2] == 'v' && line[index + 3] == 'e')
                        {
                            return 5;
                        }
                        return 0;
                    }
                    catch
                    {
                        return 0;
                    }
                    
                case 's':
                    try
                    {
                        if (line[index + 1] == 'i' && line[index + 2] == 'x')
                        {
                            return 6;
                        }
                        if (line[index + 1] == 'e' && line[index + 2] == 'v' && line[index + 3] == 'e' && line[index + 4] == 'n')
                        {
                            return 7;
                        }
                        return 0;
                    }
                    catch
                    {
                        return 0;
                    }
                    
                case 'e':
                    try
                    {
                        if (line[index + 1] == 'i' && line[index + 2] == 'g' && line[index + 3] == 'h' && line[index + 4] == 't')
                        {
                            return 8;
                        }
                        return 0;
                    }
                    catch
                    {
                        return 0;
                    }
                    
                case 'n':
                    try
                    {
                        if (line[index + 1] == 'i' && line[index + 2] == 'n' && line[index + 3] == 'e')
                        {
                            return 9;
                        }
                        return 0;
                    }
                    catch
                    {
                        return 0;
                    }

                default:
                    return 0;
            }
        }
    }
}
