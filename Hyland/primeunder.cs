static void prime()
{
    // 1 and 0 are not prime we know this. 
    // We also know that 2 and 3 are prime
    //because they are only divisible by one
    //and themselves. 
    var primes = new List<int> { 2, 3 };
    //any even number above 2 is also out 
    //because we know that evens are divisible
    //by 2
    for (int i = 5; i <= 100; i += 2)
    {
        bool isPrime = true;
        //we need to check each prime number already in the list
        foreach (int prime in primes)
        {
            //if i is a factor of of any number in primes we set isPrime to false
            if (i % prime == 0)
            {
                isPrime = false;
            }
        }
        //if isPrime remains true i is added to primes
        if (isPrime)
        {
            primes.Add(i);
        }
    }
    foreach (int prime in primes)
    {
        print(prime);
    }
}