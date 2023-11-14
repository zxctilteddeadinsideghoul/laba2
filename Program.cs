using System;


class Program{
    public class ExtendedOperation
    {
        public string Operation;
        public int Priority;
    }
    public static readonly string[] numberSeparators = new string[] {" ", "+", "-", "/", "*", "(", ")"};
    public static readonly string[] operationSeparators = new string[] {" ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
    
    static List<string> Separate(string expression, string[] Separator)
    {
        List<string> result = new List<string>();
        
        foreach(string elem in expression.Split(Separator, StringSplitOptions.RemoveEmptyEntries))
        {
            result.Add(elem);
        }
        
        return result;
    }
    
    static void Main()
    {
        
    }


}
