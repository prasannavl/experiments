using System;
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
        public int BenchmarkCount = 1;

        [Fact]
        public void StatelessTest()
        {
            var config = new StateMachine<State, Trigger>(State.Ringing);
            config.Configure(State.Off)
                .OnEntry(() => DummyActions.Test("OnEntry of Off"))
                .OnExit(() => DummyActions.Test("OnExit of Off"))
                .PermitReentry(Trigger.TurnOn)
                .Permit(Trigger.Ring, State.Ringing)
                .Permit(Trigger.Connect, State.Connected)
                .OnEntryFrom(Trigger.Ring, () => { DummyActions.Test("Attempting to ring"); })
                .OnEntryFrom(Trigger.Connect, () => { DummyActions.Test("Connecting"); });

            var connectTriggerWithParameter = config.SetTriggerParameters<string>(Trigger.Connect);

            config.Configure(State.Ringing)
                .OnEntry(() => DummyActions.Test("OnEntry of Ringing"))
                .OnExit(() => DummyActions.Test("OnExit of Ringing"))
                .Permit(Trigger.Connect, State.Connected)
                .Permit(Trigger.Talk, State.Talking)
                .OnEntryFrom(connectTriggerWithParameter,
                    name => { DummyActions.Test("Attempting to connect to " + name); })
                .OnEntryFrom(Trigger.Talk, () => { DummyActions.Test("Attempting to talk"); });


            config.Configure(State.Connected)
                .OnEntry(() => DummyActions.Test("AOnEntry of Connected"))
                .OnExit(() => DummyActions.Test("AOnExit of Connected"))
                .PermitReentry(Trigger.Connect)
                .Permit(Trigger.Talk, State.Talking)
                .Permit(Trigger.TurnOn, State.Off)
                .OnEntryFrom(Trigger.Talk, () => { DummyActions.Test("Attempting to talk"); })
                .OnEntryFrom(Trigger.TurnOn, () => { DummyActions.Test("Turning off"); });


            config.Configure(State.Talking)
                .OnEntry(() => DummyActions.Test("OnEntry of Talking"))
                .OnExit(() => DummyActions.Test("OnExit of Talking"))
                .Permit(Trigger.TurnOn, State.Off)
                .Permit(Trigger.Ring, State.Ringing)
                .OnEntryFrom(Trigger.TurnOn, () => { DummyActions.Test("Turning off"); })
                .OnEntryFrom(Trigger.Ring, () => { DummyActions.Test("Attempting to ring"); });

            Benchmark.Count = BenchmarkCount;

            Benchmark.Run(() =>
            {
                config.Fire(Trigger.Talk);
                config.Fire(Trigger.Ring);
            }, "Synchronous StateMachine - Stateless");
        }

        [Fact]
        public void LiquidStateSyncTest()
        {
            var config = StateMachine.CreateConfiguration<State, Trigger>();

            config.Configure(State.Off)
                .OnEntry(() => DummyActions.Test("OnEntry of Off"))
                .OnExit(() => DummyActions.Test("OnExit of Off"))
                .PermitReentry(Trigger.TurnOn)
                .Permit(Trigger.Ring, State.Ringing, () => { DummyActions.Test("Attempting to ring"); })
                .Permit(Trigger.Connect, State.Connected, () => { DummyActions.Test("Connecting"); });

            var connectTriggerWithParameter = config.SetTriggerParameter<string>(Trigger.Connect);

            config.Configure(State.Ringing)
                .OnEntry(() => DummyActions.Test("OnEntry of Ringing"))
                .OnExit(() => DummyActions.Test("OnExit of Ringing"))
                .Permit(connectTriggerWithParameter, State.Connected,
                    name => { DummyActions.Test("Attempting to connect to " + name); })
                .Permit(Trigger.Talk, State.Talking, () => { DummyActions.Test("Attempting to talk"); });

            config.Configure(State.Connected)
                .OnEntry(() => DummyActions.Test("AOnEntry of Connected"))
                .OnExit(() => DummyActions.Test("AOnExit of Connected"))
                .PermitReentry(Trigger.Connect)
                .Permit(Trigger.Talk, State.Talking, () => { DummyActions.Test("Attempting to talk"); })
                .Permit(Trigger.TurnOn, State.Off, () => { DummyActions.Test("Turning off"); });


            config.Configure(State.Talking)
                .OnEntry(() => DummyActions.Test("OnEntry of Talking"))
                .OnExit(() => DummyActions.Test("OnExit of Talking"))
                .Permit(Trigger.TurnOn, State.Off, () => { DummyActions.Test("Turning off"); })
                .Permit(Trigger.Ring, State.Ringing, () => { DummyActions.Test("Attempting to ring"); });

            var machine = StateMachine.Create(State.Ringing, config);

            Benchmark.Count = BenchmarkCount;

            Benchmark.Run(() =>
            {
                machine.Fire(Trigger.Talk);
                machine.Fire(Trigger.Ring);
            }, "Synchronous StateMachines - LiquidState");
        }

        public class DummyActions
        {
            public static void Test(string s)
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