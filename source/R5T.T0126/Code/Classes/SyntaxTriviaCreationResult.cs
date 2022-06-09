using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    /// <summary>
    /// For <see cref="SyntaxNode"/>s.
    /// </summary>
    /// <typeparam name="TParentNode"></typeparam>
    public class SyntaxTriviaCreationResult<TParentNode>
        where TParentNode : SyntaxNode
    {
        public TParentNode Result { get; }
        public ISyntaxTriviaAnnotation CreatedTriviaAnnotation { get; }


        public SyntaxTriviaCreationResult(
            TParentNode result,
            ISyntaxTriviaAnnotation createdTriviaAnnotation)
        {
            this.Result = result;
            this.CreatedTriviaAnnotation = createdTriviaAnnotation;
        }
    }


    /// <summary>
    /// For <see cref="SyntaxToken"/>s.
    /// </summary>
    public class SyntaxTriviaCreationResult
    {
        public SyntaxToken Result { get; }
        public ISyntaxTriviaAnnotation CreatedTriviaAnnotation { get; }


        public SyntaxTriviaCreationResult(
            SyntaxToken result,
            ISyntaxTriviaAnnotation createdTriviaAnnotation)
        {
            this.Result = result;
            this.CreatedTriviaAnnotation = createdTriviaAnnotation;
        }
    }
}
