using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmarks.Utils;
using LiquidState;
using Stateless;
using Xunit;

namespace Benchmarks
{
    public class StateMachines
    {
        private static object s;

        [Fact]
        public void StatelessTest()
        {
            var config = new StateMachine<State, Trigger>(State.Ringing);
            config.Configure(State.Off)
                .OnEntry(() => Console.WriteLine("OnEntry of Off"))
                .OnExit(() => Console.WriteLine("OnExit of Off"))
                .PermitReentry(Trigger.TurnOn)
                .Permit(Trigger.Ring, State.Ringing)
                .Permit(Trigger.Connect, State.Connected)
                .OnEntryFrom(Trigger.Ring, () => { Console.WriteLine("Attempting to ring"); })
                .OnEntryFrom(Trigger.Connect, () => { Console.WriteLine("Connecting"); });

            var connectTriggerWithParameter = config.SetTriggerParameters<string>(Trigger.Connect);

            config.Configure(State.Ringing)
                .OnEntry(() => Console.WriteLine("OnEntry of Ringing"))
                .OnExit(() => Console.WriteLine("OnExit of Ringing"))
                .Permit(Trigger.Connect, State.Connected)
                .Permit(Trigger.Talk, State.Talking)
                .OnEntryFrom(connectTriggerWithParameter,
                    name => { Console.WriteLine("Attempting to connect to " + name); })
                .OnEntryFrom(Trigger.Talk, () => { Console.WriteLine("Attempting to talk"); });


            config.Configure(State.Connected)
                .OnEntry(() => Console.WriteLine("AOnEntry of Connected"))
                .OnExit(() => Console.WriteLine("AOnExit of Connected"))
                .PermitReentry(Trigger.Connect)
                .Permit(Trigger.Talk, State.Talking)
                .Permit(Trigger.TurnOn, State.Off)
                .OnEntryFrom(Trigger.Talk, () => { Console.WriteLine("Attempting to talk"); })
                .OnEntryFrom(Trigger.TurnOn, () => { Console.WriteLine("Turning off"); });


            config.Configure(State.Talking)
                .OnEntry(() => Console.WriteLine("OnEntry of Talking"))
                .OnExit(() => Console.WriteLine("OnExit of Talking"))
                .Permit(Trigger.TurnOn, State.Off)
                .Permit(Trigger.Ring, State.Ringing)
                .OnEntryFrom(Trigger.TurnOn, () => { Console.WriteLine("Turning off"); })
                .OnEntryFrom(Trigger.Ring, () => { Console.WriteLine("Attempting to ring"); });

            Benchmark.Count = 10000000;

            Benchmark.Run(() =>
            {
                config.Fire(Trigger.Talk);
                config.Fire(Trigger.Ring);
            });
        }

        [Fact]
        public void LiquidStateSyncTest()
        {
            var config = StateMachine.CreateConfiguration<State, Trigger>();

            config.Configure(State.Off)
                .OnEntry(() => Console.WriteLine("OnEntry of Off"))
                .OnExit(() => Console.WriteLine("OnExit of Off"))
                .PermitReentry(Trigger.TurnOn)
                .Permit(Trigger.Ring, State.Ringing, () => { Console.WriteLine("Attempting to ring"); })
                .Permit(Trigger.Connect, State.Connected, () => { Console.WriteLine("Connecting"); });

            var connectTriggerWithParameter = config.SetTriggerParameter<string>(Trigger.Connect);

            config.Configure(State.Ringing)
                .OnEntry(() => Console.WriteLine("OnEntry of Ringing"))
                .OnExit(() => Console.WriteLine("OnExit of Ringing"))
                .Permit(connectTriggerWithParameter, State.Connected,
                    name => { Console.WriteLine("Attempting to connect to " + name); })
                .Permit(Trigger.Talk, State.Talking, () => { Console.WriteLine("Attempting to talk"); });

            config.Configure(State.Connected)
                .OnEntry(() => Console.WriteLine("AOnEntry of Connected"))
                .OnExit(() => Console.WriteLine("AOnExit of Connected"))
                .PermitReentry(Trigger.Connect)
                .Permit(Trigger.Talk, State.Talking, () => { Console.WriteLine("Attempting to talk"); })
                .Permit(Trigger.TurnOn, State.Off, () => { Console.WriteLine("Turning off"); });


            config.Configure(State.Talking)
                .OnEntry(() => Console.WriteLine("OnEntry of Talking"))
                .OnExit(() => Console.WriteLine("OnExit of Talking"))
                .Permit(Trigger.TurnOn, State.Off, () => { Console.WriteLine("Turning off"); })
                .Permit(Trigger.Ring, State.Ringing, () => { Console.WriteLine("Attempting to ring"); });

            var machine = StateMachine.Create(State.Ringing, config);

            Benchmark.Count = 10000000;

            Benchmark.Run(() =>
            {
                machine.Fire(Trigger.Talk);
                machine.Fire(Trigger.Ring);
            });
        }

        public class Console
        {
            public static void WriteLine(string s)
            {
                StateMachines.s = s;
            }
        }

        private enum Trigger
        {
            TurnOn,
            Ring,
            Connect,
            Talk,
        }

        private enum State
        {
            Off,
            Ringing,
            Connected,
            Talking,
        }
    }
}