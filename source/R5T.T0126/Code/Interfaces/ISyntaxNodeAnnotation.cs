using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public interface ISyntaxNodeAnnotation
    {
        SyntaxAnnotation SyntaxAnnotation { get; }
    }


    public interface ISyntaxNodeAnnotation<out TNode> : ISyntaxNodeAnnotation
        where TNode : SyntaxNode
    {
    }
}
