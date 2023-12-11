using System.Diagnostics;

int resultado = Fibonacci(6);
Console.WriteLine(resultado);

static int Fibonacci(int n){

    Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
    Debug.WriteLine($"We are looking for the {n}th number");
    
    int n1 = 0, n2 = 1, sum;

    for(int i = 2 ; i <= n; i++){
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
        Debug.WriteLineIf(sum == 1, $"sum is 1, n1 is {n1}, n2 is {n2}");
    }
    Debug.Assert(n2 == 5, "The return value is not 5 and it should be.");    
    return n == 0 ? n1 : n2;
}