using System;
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
            var customWriter = new EnumsSummaryStringWriter();

            var genie = new EnumGenie()
                .SourceFrom.Assembly(typeof(Program).Assembly)
                .FilterBy.Predicate(t => t != typeof(Ignored))
                .TransformBy.RenamingEnum(def => def.Name.Replace("StripThisOut", ""))
                .WriteTo.Console(cfg =>
                    cfg.TypeScript(ts =>
                        ts.Declaration()
                          .Description()
                          .Descriptor()
                        )
                    )
                .WriteTo.File("./TypeScript/enums.ts", cfg =>
                    cfg.TypeScript(ts =>
                        ts.Declaration(c => c.AsConst())
                            .Description()
                            .Descriptor(c => c.AsConst())
                    ))
                .WriteTo.Custom(customWriter);

            genie.Write();

            Console.WriteLine("Output from custom writer: " + Environment.NewLine + customWriter.Output);
        }
    }
}