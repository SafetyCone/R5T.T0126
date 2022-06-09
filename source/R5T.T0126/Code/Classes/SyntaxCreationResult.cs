using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public static class SyntaxCreationResult
    {
        public static SyntaxNodeCreationResult<TParentNode, TNode> Node<TParentNode, TNode>(
            TParentNode result,
            ISyntaxNodeAnnotation<TNode> createdNodeAnnotation)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeCreationResult<TParentNode, TNode>(
                result,
                createdNodeAnnotation);

            return output;
        }

        public static SyntaxTokenCreationResult<TParentNode> Token<TParentNode>(
            TParentNode result,
            ISyntaxTokenAnnotation createdTokenAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = new SyntaxTokenCreationResult<TParentNode>(
                result,
                createdTokenAnnotation);

            return output;
        }

        public static SyntaxTriviaCreationResult<TParentNode> Trivia<TParentNode>(
            TParentNode result,
            ISyntaxTriviaAnnotation createdTriviaAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = new SyntaxTriviaCreationResult<TParentNode>(
                result,
                createdTriviaAnnotation);

            return output;
        }

        public static SyntaxTriviaCreationResult Trivia(
            SyntaxToken result,
            ISyntaxTriviaAnnotation createdTriviaAnnotation)
        {
            var output = new SyntaxTriviaCreationResult(
                result,
                createdTriviaAnnotation);

            return output;
        }
    }
}
