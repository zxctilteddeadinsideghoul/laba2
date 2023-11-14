using System;


class Program{
    static public List<string> Separate(string input)
    {
        List<string> result = new List<string>();
        string number = "";

        foreach(char elem in input)
        {
            if (char.IsNumber(elem))
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
        List<string> res = new List<string>();
        Stack<string> st = new Stack<string>();
        List<string> separatedInput = Separate(input);

        for(int i = 0; i < separatedInput.Count; i++)
        {
            
            Console.WriteLine(separatedInput[i]);
            
        }
        return res;
    }
    
    static void Main()
    {
        toRPN(Console.ReadLine());
    }


}
