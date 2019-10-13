using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Testura.Code.Statements
{
    public class PreprocessorDirectiveStatement
    {
        public StatementSyntax If(string text)
        {
            return CreatePreprocessorDirectiveStatement(IfDirectiveTrivia(IdentifierName($"{text}"), true, false, false));
        }

        public StatementSyntax Else()
        {
            return CreatePreprocessorDirectiveStatement(ElseDirectiveTrivia(true, false));
        }

        public StatementSyntax Elif(string text)
        {
            return CreatePreprocessorDirectiveStatement(ElifDirectiveTrivia(IdentifierName($"{text}"), true, false, false));
        }

        public StatementSyntax Endif()
        {
            return CreatePreprocessorDirectiveStatement(EndIfDirectiveTrivia(true));
        }

        public StatementSyntax Define(string text)
        {
            return CreatePreprocessorDirectiveStatement(DefineDirectiveTrivia($"{text}", true));
        }

        public StatementSyntax Undef(string text)
        {
            return CreatePreprocessorDirectiveStatement(UndefDirectiveTrivia($"{text}", true));
        }

        public StatementSyntax Warning(string text)
        {
            return CreatePreprocessorDirectiveStatement(WarningDirectiveTrivia(true).WithEndOfDirectiveToken(
                Token(
                    TriviaList(
                        PreprocessingMessage($" {text}\n")),
                    SyntaxKind.EndOfDirectiveToken,
                    TriviaList())));
        }

        public StatementSyntax Error(string text)
        {
            return CreatePreprocessorDirectiveStatement(ErrorDirectiveTrivia(true).WithEndOfDirectiveToken(
                Token(
                    TriviaList(
                        PreprocessingMessage($"{text}")),
                    SyntaxKind.EndOfDirectiveToken,
                    TriviaList())));
        }

        public StatementSyntax Line(int line, string text)
        {
            return CreatePreprocessorDirectiveStatement(LineDirectiveTrivia(Literal(line), true).WithFile(Literal($"{text}")));
        }

        public StatementSyntax Region(string text)
        {
            return CreatePreprocessorDirectiveStatement(RegionDirectiveTrivia(true).WithEndOfDirectiveToken(
                Token(
                    TriviaList(
                        PreprocessingMessage($"{text}")),
                    SyntaxKind.EndOfDirectiveToken,
                    TriviaList())));
        }

        public StatementSyntax Endregion()
        {
            return CreatePreprocessorDirectiveStatement(EndRegionDirectiveTrivia(true));
        }

        public StatementSyntax Pragma(string text)
        {
            return CreatePreprocessorDirectiveStatement(PragmaWarningDirectiveTrivia(
                    MissingToken(SyntaxKind.DisableKeyword),
                    true)
                .WithWarningKeyword(
                    MissingToken(SyntaxKind.WarningKeyword))
                .WithEndOfDirectiveToken(
                    Token(
                        TriviaList(
                            Trivia(
                                SkippedTokensTrivia()
                                    .WithTokens(
                                        TokenList(
                                            Identifier($"{text}"))))),
                        SyntaxKind.EndOfDirectiveToken,
                        TriviaList())));
        }

        private StatementSyntax CreatePreprocessorDirectiveStatement(DirectiveTriviaSyntax directiveTriviaSyntax)
        {
            return EmptyStatement()
                .WithSemicolonToken(MissingToken(SyntaxKind.SemicolonToken))
                .WithLeadingTrivia(TriviaList(EndOfLine("\n")))
                .WithTrailingTrivia(TriviaList(Trivia(directiveTriviaSyntax), EndOfLine("\n")));
        }
    }
}
