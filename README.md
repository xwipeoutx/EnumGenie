# EnumGenie
[![Build status](https://ci.appveyor.com/api/projects/status/x5f1ywgtd6cgmh5b?svg=true)](https://ci.appveyor.com/project/xwipeoutx/enumgenie)

Generate enums matching your C# enums.  

Comes with generators for TypeScript.

## Usage
```cs
public static class Program
{
    public static void Main()
    {
        var config = new EnumGenie()
            .SourceFrom.Assembly(typeof(Program).Assembly)
            .FilterBy.Predicate(t => t != typeof(Ignored))
            .WriteTo.Console(cfg => cfg.TypeScript(ts => ts.Declaration().Description().Descriptor()))
            .WriteTo.File("c:\\temp\\enums.ts", cfg => cfg.TypeScript(ts => ts.Declaration().Description().Descriptor()));

        config.Write();
    }
}
```
