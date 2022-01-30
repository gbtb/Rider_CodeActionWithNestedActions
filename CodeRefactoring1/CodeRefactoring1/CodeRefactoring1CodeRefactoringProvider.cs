using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;

namespace CodeRefactoring1
{
    [ExportCodeRefactoringProvider(LanguageNames.CSharp, Name = nameof(CodeRefactoring1CodeRefactoringProvider)), Shared]
    internal class CodeRefactoring1CodeRefactoringProvider : CodeRefactoringProvider
    {
        public sealed override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
        {
            var action1 = CodeAction.Create("First", _ => Task.FromResult(context.Document));
            var action2 = CodeAction.Create("Second", _ => Task.FromResult(context.Document));
            
            var actions = ImmutableArray.Create(action1, action2);
            var action = CodeAction.Create("Top-Level", actions, false);
            // Register this code action.
            context.RegisterRefactoring(action);
        }
    }
}
