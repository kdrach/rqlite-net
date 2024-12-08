﻿using Orleans.Runtime;
using RqliteNet.Orleans.Example.Interfaces;

namespace RqliteNet.Orleans.Example.Grains;

public class HelloGrain([PersistentState("state", "rqlite")] IPersistentState<HelloState> state) : Grain, IHello
{
    private readonly IPersistentState<HelloState> _state = state;

    async Task<string> IHello.SayHello(string greeting)
    {
        var result = $"RecordExists: {_state.RecordExists}, Old: {_state.State.Example}, New: {greeting}";

        _state.State.Example = greeting;
        await _state.WriteStateAsync();

        return result;
    }
}