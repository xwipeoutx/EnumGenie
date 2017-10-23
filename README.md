# EnumGenie
[![Build status](https://ci.appveyor.com/api/projects/status/x5f1ywgtd6cgmh5b/branch/master?svg=true)](https://ci.appveyor.com/project/xwipeoutx/enumgenie/branch/master) Master

[![Build status](https://ci.appveyor.com/api/projects/status/x5f1ywgtd6cgmh5b?svg=true)](https://ci.appveyor.com/project/xwipeoutx/enumgenie) CI

Generate enums matching your C# enums.  

Comes with generators for TypeScript.

## Installation

[EnumGenie is a nuget](https://www.nuget.org/packages/EnumGenie.TypeScript)! Crazy, I know.

```ps
    dotnet add package EnumGenie.TypeScript
```

## Documentation

See the [wiki](https://github.com/xwipeoutx/EnumGenie/wiki)

## Usage

See `EnumGenie.Sample` project for a ...umm... sample. Crazy.

```cs
using EnumGenie.Filters;
using EnumGenie.Sample.Enums;
using EnumGenie.Sources;
using EnumGenie.Transforms;
using EnumGenie.TypeScript;
using EnumGenie.Writers;

namespace EnumGenie.Sample
{
    public static class Program
    {
        public static void Main()
        {
            var genie = new EnumGenie()
                .SourceFrom.Assembly(typeof(Program).Assembly)
                .FilterBy.Predicate(t => t != typeof(Ignored))
                .TransformBy.RenamingEnum(def => def.Name.Replace("StripThisOut", ""))
                .WriteTo.Console(cfg => cfg.TypeScript(ts => ts.Declaration().Description().Descriptor()))
                .WriteTo.File("./TypeScript/enums.ts", cfg => cfg.TypeScript(ts => ts.Declaration().Description().Descriptor()));

            genie.Write();
        }
    }
}
```

## Common Mistakes

### Nothing is being output!

Ensure you are calling `.Write()` at the end.  This is where the work is done, the rest is just configuration.
