using EnumGenie.Filters;
using EnumGenie.Sample.Enums;
using EnumGenie.Sources;
using EnumGenie.TypeScript;
using EnumGenie.Writers;

namespace EnumGenie.Sample
{
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
}