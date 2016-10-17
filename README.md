# Waterworks

An extension of the Pipe and Filter pattern in .NET that allows for skipping filters.

[![Build status](https://ci.appveyor.com/api/projects/status/j9dc9ikhw6w5r2h7/branch/master?svg=true)](https://ci.appveyor.com/project/AnthonyNeace/waterworks)

## Usage

### Filters

Filters provide a simple interface processing input data and passing it on:

    bool CanModify(T data);

    void Modify(ref T data);

    bool Stop(T data);

Filters also support cases where the input and ouput objects need to be maintained separately, such as API request and response containers:

    bool CanModify(T input, U output);

    void Modify(T input, ref U output);

    bool Stop(T input, U output);

### Pipelines

Pipelines can be created with a collection of filters:

    IEnumerable<IFilter<ChatInput, ChatOutput>> filters = new List<IFilter<ChatInput, ChatOutput>>()
    {
        new AppendDateTimeFilter(),
        new AppendUserNameFilter(),
        new AppendUserInputFilter()
    };

    return new Pipeline<ChatInput, ChatOutput>(filters);
    
#### Flow

Use `Flow()` to iterate the collection of filters. Flow will check each filter's implementation of `CanProcess()` to determine if this step should be processed.  If so, it will then check that filter's implementation of `Stop()` to determine if processing should be interrupted.  Otherwise, it will continue to that filter's implementation of `Process()`.

If processing is interrupted, `Flow()` will return false. This boolean return value can be used to determine if the full collection was processed to completion.
