Benchmarks
==========

Arbitrary .NET Framework benchmarks.

**Note:** This is not meant to be a speed test. This is to *understand the efficieny of the algorithms*, and giving a timemark to it for visualization of the results.

#####Auto-generated results (Later tests towards the end): 

######12/5/2014 8:54:31 AM +05:30:

```
CLR Version: 4.0.30319.0
.NET Framework Version: 4.0.0.0
OS: Microsoft Windows NT 6.2.9200.0
Process architecture: 32-bit

Count: 10000000 * 3
ConcurrentBag - Add => Time taken: 00:00:07.2154686
ConcurrentBag - Take (through element) => Time taken: 00:00:02.9651258
ConcurrentBag - Take (through element) and GC => Time taken: 00:00:03.4934530

Count: 10000000 * 3
ImmutableList - Add => Time taken: 00:00:57.9583883
ImmutableList - Remove from end (through index) => Time taken: 00:00:31.7743593
ImmutableList - Remove from end (through index), and GC => Time taken: 00:00:33.0795918

Count: 10000000 * 3
List - Add => Time taken: 00:00:00.2776642
List - Remove from end (through index) => Time taken: 00:00:00.1602011

Count: 10000000 * 3
ConcurrentQueue - Enqueue => Time taken: 00:00:01.4034601
ConcurrentQueue - Dequeue => Time taken: 00:00:00.8869759
ConcurrentQueue - Dequeue and GC => Time taken: 00:00:00.9267536

Count: 10000000 * 3
Queue - Enqueue => Time taken: 00:00:00.4907369
Queue - Dequeue => Time taken: 00:00:00.3877181
Queue - Dequeue and GC => Time taken: 00:00:00.4517926

Count: 10000000 * 3
ImmutableQueue - Enqueue => Time taken: 00:00:07.9802526
ImmutableQueue - Dequeue => Time taken: 00:00:00.9137694
ImmutableQueue - Dequeue and GC => Time taken: 00:00:02.8389212

Count: 10000000 * 3
ConcurrentStack - Push => Time taken: 00:00:05.2665492
ConcurrentStack - Pop => Time taken: 00:00:00.5787926
ConcurrentStack - Pop and GC => Time taken: 00:00:02.6736588

Count: 10000000 * 3
ImmutableStack - Push => Time taken: 00:00:06.2855050
ImmutableStack - Pop => Time taken: 00:00:00.3340684
ImmutableStack - Pop and GC => Time taken: 00:00:01.2533328

Count: 10000000 * 3
Stack - Push => Time taken: 00:00:00.2768707
Stack - Pop => Time taken: 00:00:00.2691504
Stack - Pop and GC => Time taken: 00:00:00.3295845

Count: 10000000
Synchronous StateMachines - LiquidState => Time taken: 00:00:02.0582818

Count: 10000000
Synchronous StateMachines - Stateless => Time taken: 00:00:20.9230991

```

######12/5/2014 10:55:02 AM +05:30:

```
CLR Version: 4.0.30319.0
.NET Framework Version: 4.0.0.0
OS: Microsoft Windows NT 6.2.9200.0
Process architecture: 32-bit

Count: 10000000 * 3
ConcurrentBag - Add => Time taken: 00:00:07.2893039
ConcurrentBag - Take (through element) => Time taken: 00:00:03.2963653
ConcurrentBag - Take (through element) and GC => Time taken: 00:00:03.9137103

Count: 10000000 * 3
ImmutableList - Add => Time taken: 00:01:01.4570283
ImmutableList - Remove from end (through index) => Time taken: 00:00:33.3904483
ImmutableList - Remove from end (through index), and GC => Time taken: 00:00:36.8720717

Count: 10000000 * 3
SynchronizedList (No contention) - Add => Time taken: 00:00:01.2580175
SynchronizedList (No contention) - Remove from end (through index) => Time taken: 00:00:02.2377403

Count: 10000000 * 3
List - Add => Time taken: 00:00:00.4242621
List - Remove from end (through index) => Time taken: 00:00:00.1511479

Count: 10000000 * 3
Queue - Enqueue => Time taken: 00:00:00.7178697
Queue - Dequeue => Time taken: 00:00:00.4399668
Queue - Dequeue and GC => Time taken: 00:00:00.4918037

Count: 10000000 * 3
ConcurrentQueue - Enqueue => Time taken: 00:00:01.4820481
ConcurrentQueue - Dequeue => Time taken: 00:00:00.9186113
ConcurrentQueue - Dequeue and GC => Time taken: 00:00:01.2076175

Count: 10000000 * 3
ImmutableQueue - Enqueue => Time taken: 00:00:08.1920783
ImmutableQueue - Dequeue => Time taken: 00:00:01.0779163
ImmutableQueue - Dequeue and GC => Time taken: 00:00:03.3306346

Count: 10000000 * 3
Mono - ConcurrentQueue - Enqueue => Time taken: 00:00:07.0503826
Mono - ConcurrentQueue - Dequeue => Time taken: 00:00:02.2015004
Mono - ConcurrentQueue - Dequeue and GC => Time taken: 00:00:03.6856295

Count: 10000000 * 3
ConcurrentStack - Push => Time taken: 00:00:05.8412267
ConcurrentStack - Pop => Time taken: 00:00:01.2140677
ConcurrentStack - Pop and GC => Time taken: 00:00:02.2991917

Count: 10000000 * 3
ImmutableStack - Push => Time taken: 00:00:05.3302170
ImmutableStack - Pop => Time taken: 00:00:00.4034781
ImmutableStack - Pop and GC => Time taken: 00:00:01.4003746

Count: 10000000 * 3
Mono - ConcurrentStack - Push => Time taken: 00:00:04.7988511
Mono - ConcurrentStack - Pop => Time taken: 00:00:01.3436323
Mono - ConcurrentStack - Pop and GC => Time taken: 00:00:02.4610389

Count: 10000000 * 3
Stack - Push => Time taken: 00:00:00.6995330
Stack - Pop => Time taken: 00:00:00.4338843
Stack - Pop and GC => Time taken: 00:00:00.3307840

Count: 10000000
Synchronous StateMachines - Stateless => Time taken: 00:00:22.5499772

Count: 10000000
Synchronous StateMachines - LiquidState => Time taken: 00:00:02.3190077

```

######12/5/2014 11:49:28 AM +05:30:

**Nominal number of medium sized collections test:**

```
CLR Version: 4.0.30319.0
.NET Framework Version: 4.0.0.0
OS: Microsoft Windows NT 6.2.9200.0
Process architecture: 32-bit

Count: 1000 * 100
SynchronizedList (No contention) - Add => Time taken: 00:00:00.0190642
SynchronizedList (No contention) - Remove from end (through index) => Time taken: 00:00:00.0235834

Count: 1000 * 100
ConcurrentBag - Add => Time taken: 00:00:00.0123536
ConcurrentBag - Take (through element) => Time taken: 00:00:00.0128007
ConcurrentBag - Take (through element) and GC => Time taken: 00:00:00.0764274

Count: 1000 * 100
ImmutableList - Add => Time taken: 00:00:00.1331710
ImmutableList - Remove from end (through index) => Time taken: 00:00:00.0606489
ImmutableList - Remove from end (through index), and GC => Time taken: 00:00:00.0975258

Count: 1000 * 100
List - Add => Time taken: 00:00:00.0006222
List - Remove from end (through index) => Time taken: 00:00:00.0005099

Count: 1000 * 100
ConcurrentQueue - Enqueue => Time taken: 00:00:00.0033697
ConcurrentQueue - Dequeue => Time taken: 00:00:00.0027968
ConcurrentQueue - Dequeue and GC => Time taken: 00:00:00.0371777

Count: 1000 * 100
Queue - Enqueue => Time taken: 00:00:00.0014535
Queue - Dequeue => Time taken: 00:00:00.0017384
Queue - Dequeue and GC => Time taken: 00:00:00.0486872

Count: 1000 * 100
ImmutableQueue - Enqueue => Time taken: 00:00:00.0071634
ImmutableQueue - Dequeue => Time taken: 00:00:00.0043505
ImmutableQueue - Dequeue and GC => Time taken: 00:00:00.0503941

Count: 1000 * 100
Mono - ConcurrentQueue - Enqueue => Time taken: 00:00:00.0056944
Mono - ConcurrentQueue - Dequeue => Time taken: 00:00:00.0064013
Mono - ConcurrentQueue - Dequeue and GC => Time taken: 00:00:00.0424975

Count: 1000 * 100
ImmutableStack - Push => Time taken: 00:00:00.0018096
ImmutableStack - Pop => Time taken: 00:00:00.0010526
ImmutableStack - Pop and GC => Time taken: 00:00:00.0331466

Count: 1000 * 100
Mono - ConcurrentStack - Push => Time taken: 00:00:00.0030034
Mono - ConcurrentStack - Pop => Time taken: 00:00:00.0029559
Mono - ConcurrentStack - Pop and GC => Time taken: 00:00:00.0386063

Count: 1000 * 100
Stack - Push => Time taken: 00:00:00.0006530
Stack - Pop => Time taken: 00:00:00.0018198
Stack - Pop and GC => Time taken: 00:00:00.0341512

Count: 1000 * 100
ConcurrentStack - Push => Time taken: 00:00:00.0023805
ConcurrentStack - Pop => Time taken: 00:00:00.0018262
ConcurrentStack - Pop and GC => Time taken: 00:00:00.0370103

Count: 10000000
Synchronous StateMachines - Stateless => Time taken: 00:00:21.2445586

```


######12/5/2014 11:52:45 AM +05:30:

**Large number of small sized collections test:**

```
CLR Version: 4.0.30319.0
.NET Framework Version: 4.0.0.0
OS: Microsoft Windows NT 6.2.9200.0
Process architecture: 32-bit

Count: 100 * 100000
SynchronizedList (No contention) - Add => Time taken: 00:00:00.4464933
SynchronizedList (No contention) - Remove from end (through index) => Time taken: 00:00:00.7068863

Count: 100 * 100000
ImmutableList - Add => Time taken: 00:00:04.8992430
ImmutableList - Remove from end (through index) => Time taken: 00:00:02.7787919
ImmutableList - Remove from end (through index), and GC => Time taken: 00:00:30.8450352

Count: 100 * 100000
List - Add => Time taken: 00:00:00.1008608
List - Remove from end (through index) => Time taken: 00:00:00.0520152

Count: 100 * 100000
ConcurrentBag - Add => Time taken: 00:00:01.3923304
ConcurrentBag - Take (through element) => Time taken: 00:00:00.7555254
ConcurrentBag - Take (through element) and GC => Time taken: 00:00:31.7603519

Count: 100 * 100000
ImmutableQueue - Enqueue => Time taken: 00:00:00.3270089
ImmutableQueue - Dequeue => Time taken: 00:00:00.3235443
ImmutableQueue - Dequeue and GC => Time taken: 00:00:28.2526470

Count: 100 * 100000
Mono - ConcurrentQueue - Enqueue => Time taken: 00:00:00.5107044
Mono - ConcurrentQueue - Dequeue => Time taken: 00:00:00.6650058
Mono - ConcurrentQueue - Dequeue and GC => Time taken: 00:00:28.5636767

Count: 100 * 100000
ConcurrentQueue - Enqueue => Time taken: 00:00:00.2809146
ConcurrentQueue - Dequeue => Time taken: 00:00:00.2576557
ConcurrentQueue - Dequeue and GC => Time taken: 00:00:27.9316815

Count: 100 * 100000
Queue - Enqueue => Time taken: 00:00:00.1778598
Queue - Dequeue => Time taken: 00:00:00.1361956
Queue - Dequeue and GC => Time taken: 00:00:27.6216936

Count: 100 * 100000
ImmutableStack - Push => Time taken: 00:00:00.1138778
ImmutableStack - Pop => Time taken: 00:00:00.1118379
ImmutableStack - Pop and GC => Time taken: 00:00:27.8133409

Count: 100 * 100000
Stack - Push => Time taken: 00:00:00.0960548
Stack - Pop => Time taken: 00:00:00.0920231
Stack - Pop and GC => Time taken: 00:00:27.6680939

Count: 100 * 100000
ConcurrentStack - Push => Time taken: 00:00:00.2065360
ConcurrentStack - Pop => Time taken: 00:00:00.1779291
ConcurrentStack - Pop and GC => Time taken: 00:00:28.6645350

Count: 100 * 100000
Mono - ConcurrentStack - Push => Time taken: 00:00:00.2820545
Mono - ConcurrentStack - Pop => Time taken: 00:00:00.2922874
Mono - ConcurrentStack - Pop and GC => Time taken: 00:00:30.1094073

Count: 10000000
Synchronous StateMachines - Stateless => Time taken: 00:00:23.3304870

Count: 10000000
Synchronous StateMachines - LiquidState => Time taken: 00:00:02.1770625

```


######12/7/2014 6:50:30 PM +05:30:

```
CLR Version: 4.0.30319.0
.NET Framework Version: 4.0.0.0
OS: Microsoft Windows NT 6.2.9200.0
Process architecture: 32-bit

Count: 10000000 * 3
SynchronizedList (No contention) - Add => Time taken: 00:00:01.2363450
SynchronizedList (No contention) - Remove from end (through index) => Time taken: 00:00:02.2440377

Count: 10000000 * 3
ConcurrentBag - Add => Time taken: 00:00:06.6482112
ConcurrentBag - Take (through element) => Time taken: 00:00:02.9352847
ConcurrentBag - Take (through element) and GC => Time taken: 00:00:04.1729416

Count: 10000000 * 3
ImmutableList - Add => Time taken: 00:00:59.6097793
ImmutableList - Remove from end (through index) => Time taken: 00:00:34.2195985
ImmutableList - Remove from end (through index), and GC => Time taken: 00:00:34.3504281

Count: 10000000 * 3
List - Add => Time taken: 00:00:00.3054654
List - Remove from end (through index) => Time taken: 00:00:00.1569578

Count: 10000000 * 3
ImmutableQueue - Enqueue => Time taken: 00:00:08.0163244
ImmutableQueue - Dequeue => Time taken: 00:00:01.0824888
ImmutableQueue - Dequeue and GC => Time taken: 00:00:03.0555715

Count: 10000000 * 3
Queue - Enqueue => Time taken: 00:00:00.5078171
Queue - Dequeue => Time taken: 00:00:00.4052043
Queue - Dequeue and GC => Time taken: 00:00:00.4567384

Count: 10000000 * 3
ConcurrentQueue - Enqueue => Time taken: 00:00:01.4480745
ConcurrentQueue - Dequeue => Time taken: 00:00:00.8953819
ConcurrentQueue - Dequeue and GC => Time taken: 00:00:01.0622391

Count: 10000000 * 3
Mono - ConcurrentQueue - Enqueue => Time taken: 00:00:05.3231222
Mono - ConcurrentQueue - Dequeue => Time taken: 00:00:02.1715727
Mono - ConcurrentQueue - Dequeue and GC => Time taken: 00:00:03.4943594

Count: 10000000 * 3
ConcurrentStack - Push => Time taken: 00:00:05.1152602
ConcurrentStack - Pop => Time taken: 00:00:01.4471309
ConcurrentStack - Pop and GC => Time taken: 00:00:02.7833272

Count: 10000000 * 3
Mono - ConcurrentStack - Push => Time taken: 00:00:05.8277569
Mono - ConcurrentStack - Pop => Time taken: 00:00:01.5272296
Mono - ConcurrentStack - Pop and GC => Time taken: 00:00:02.3220695

Count: 10000000 * 3
Stack - Push => Time taken: 00:00:00.6786540
Stack - Pop => Time taken: 00:00:00.4225121
Stack - Pop and GC => Time taken: 00:00:00.3341043

Count: 10000000 * 3
ImmutableStack - Push => Time taken: 00:00:04.7778714
ImmutableStack - Pop => Time taken: 00:00:00.5517862
ImmutableStack - Pop and GC => Time taken: 00:00:01.5316154

Count: 10000000
Synchronous StateMachines - LiquidState (Task/Async Awaitable) => Time taken: 00:00:13.9579566

Count: 10000000
Asynchronous StateMachines - LiquidState => Time taken: 00:00:19.4116743

Count: 10000000
Synchronous StateMachines - LiquidState => Time taken: 00:00:02.2374253

Count: 10000000
Synchronous StateMachines - Stateless => Time taken: 00:00:21.5919263

```
