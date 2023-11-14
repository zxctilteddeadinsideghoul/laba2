using System;


class Program{
    static public List<string> Separate(string input)
    {
        List<string> result = new List<string>();
        
        foreach(string elem in input.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            result.Add(elem);
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
            if (separatedInput[i] == "1"){
                Console.WriteLine(1);
            }
        }
        return res;
    }
    
    static void Main()
    {
        
    }


}
