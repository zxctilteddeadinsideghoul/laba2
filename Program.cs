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
    
    static public List<string> toRPN(List<string> separatedInput)
    {
        List<string> result = new List<string>();
        Stack<string> stack = new Stack<string>();
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
                if (elem == "(")
                {
                    stack.Push(elem);
                }
                if (elem == ")")
                {
                    string cursor = stack.Pop();
                    while (cursor != "(")
                    {
                        result.Add(cursor);
                        cursor = stack.Pop();
                    }
                }
            }
        }
        while(stack.Count != 0) result.Add(stack.Pop());
        return result;
    }

    static double Calculate(string operation, double num1, double num2)
    {
        switch(operation)
        {
            case "+": return num1 + num2;
            case "-": return num1 - num2;
            case "*": return num1 * num2;
            case "/": return num1 / num2;
        }
        throw new Exception("Error");
    }

    static public double CalculateRPN(List<string> expression)
    {   
        Stack<double> stack = new Stack<double>();
        double number;
        foreach (string elem in expression)
        {
            if (Double.TryParse(elem, out number))
            {
                stack.Push(number);
            }
            else
            {
                double num2 = stack.Pop();
                double num1 = stack.Pop();
                stack.Push(Calculate(elem, num1, num2));
            }
        }
        return stack.Pop();
    }

    static void Main()
    {
        Console.WriteLine(CalculateRPN(toRPN(Separate("3 - 4+ 32 * 3 - 4 * (3 /4)"))));
    }


}
