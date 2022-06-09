using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxNodeCreationResult<TParentNode, TNode>
        where TParentNode : SyntaxNode
        where TNode : SyntaxNode
    {
        public TParentNode Result { get; }
        public ISyntaxNodeAnnotation<TNode> CreatedNodeAnnotation { get; }


        public SyntaxNodeCreationResult(
            TParentNode result,
            ISyntaxNodeAnnotation<TNode> createdNodeAnnotation)
        {
            this.Result = result;
            this.CreatedNodeAnnotation = createdNodeAnnotation;
        }
    }
}
