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
