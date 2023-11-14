using System;


class Program{
    public static readonly Dictionary<string, int> priority = new Dictionary<string, int>(){
        {"*", 3},
        {"/", 3},
        {"+", 2},
        {"-", 2},
        {"(", 1}
    };
    static public List<string> Separate(string input)
    {
        List<string> result = new List<string>();
        string number = "";

        foreach(char elem in input)
        {
            if (char.IsNumber(elem) || elem == ',')
            {
                number += elem;
            }
            else
            {
                if (number != "")
                {
                    result.Add(number);
                    number = "";
                }
                if (elem != ' ')
                {
                    result.Add(elem.ToString());
                }
            }
        }
        if (number != "")
        {
            result.Add(number);
            number = "";
        }
        
        return result;
    }
    static public List<string> toRPN(string input)
    {
        List<string> result = new List<string>();
        Stack<string> stack = new Stack<string>();
        List<string> separatedInput = Separate(input);
        double number;
        foreach(string elem in separatedInput)
        {
            
            if (Double.TryParse(elem, out number))
            {
                result.Add(elem);
            }
            else
            {   
                if (elem == "+" || elem == "-" || elem == "*" || elem == "/")
                {
                    if (stack.Count == 0 || priority[elem] > priority[stack.Peek()])
                    {
                        stack.Push(elem);
                    }
                    else
                    {
                        while (stack.Count != 0 && priority[stack.Peek()] >= priority[elem])
                        {
                            result.Add(stack.Pop());
                        }
                        if (stack.Count == 0 || priority[elem] > priority[stack.Peek()])
                        {
                        stack.Push(elem);
                        }
                    }
                }
            }
        }
        while(stack.Count != 0) result.Add(stack.Pop());
        return result;
    }
    
    static void Main()
    {
        Console.WriteLine(string.Join(" ", toRPN("Console.ReadLine()")));
    }


}
