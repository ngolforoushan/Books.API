using ExpressionDebugger;
using Mapster;
using System.Linq.Expressions;

namespace Books.API.Profiles
{
    public static class ProfileManager
    {
        internal static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = new TypeAdapterConfig
            {
                Compiler = exp => exp.CompileWithDebugInfo(new ExpressionCompilationOptions { EmitFile = true, ThrowOnFailedCompilation = true })
            };

            BooksProfile.Configure(config);
            return config;
        }
    }
}
