using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxTokenCreationResult<TParentNode>
        where TParentNode : SyntaxNode
    {
        public TParentNode Result { get; }
        public ISyntaxTokenAnnotation CreatedTokenAnnotation { get; }


        public SyntaxTokenCreationResult(
            TParentNode result,
            ISyntaxTokenAnnotation createdTokenAnnotation)
        {
            this.Result = result;
            this.CreatedTokenAnnotation = createdTokenAnnotation;
        }
    }
}
