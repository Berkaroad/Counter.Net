# DCounter.Net
Abstract Distribute Counter, you can implement it, store in redis or relative-db.

## DCounter.ini
	[dcounter]
	counterType=in_memory

	[in_memory]
	__class=DCounter, DCounter.InMemoryCounterProvider

## Usage in csharp code
	string key1 = "C10010/1";
    string key2 = "C10011/10001";

    var provider = DCounter.DCounterServiceFactory.Create((p)=> {
        // Initialize several counter.
        for (var i= 1; i <= 10000; i++)
        {
            p.Set("C10010/" + i.ToString(), i % 100 + 2);
        }
        for (var i = 10001; i <= 20000; i++)
        {
            p.Set("C10011/" + i.ToString(), i % 100 + 3);
        }
    }).Provider;

    // Print value
    Console.WriteLine(String.Format("{0}'s value is {1}", key1, provider.Get(key1)));
    Console.WriteLine(String.Format("{0}'s value is {1}", key2, provider.Get(key2)));

    // Increase by |-90|
    provider.IncreaseBy(key1, -90);
    Console.WriteLine(String.Format("{0}'s value is {1}", key1, provider.Get(key1)));

    // Decrease by |-90|
    provider.DecreaseBy(key2, -90);
    Console.WriteLine(String.Format("{0}'s value is {1}", key2, provider.Get(key2)));