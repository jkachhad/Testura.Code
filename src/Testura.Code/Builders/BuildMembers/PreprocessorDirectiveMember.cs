using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Testura.Code.Builders.BuildMembers
{
    public class PreprocessorDirectiveMember : IBuildMember
    {
        private readonly IEnumerable<StatementSyntax> _statements;

        public PreprocessorDirectiveMember(IEnumerable<StatementSyntax> statements)
        {
            _statements = statements;
        }

        public SyntaxList<MemberDeclarationSyntax> AddMember(SyntaxList<MemberDeclarationSyntax> members)
        {
            var trailingTrivia = _statements.First().GetTrailingTrivia().First();

            return members.Add(IncompleteMember(
                IdentifierName(
                    Identifier(
                        TriviaList(trailingTrivia),
                        string.Empty,
                        TriviaList(
                            Trivia(
                                SkippedTokensTrivia()
                                    .WithTokens(
                                        TokenList(
                                            MissingToken(SyntaxKind.SemicolonToken)))),
                            Trivia(EndIfDirectiveTrivia(true)))))));
        }
    }
}
