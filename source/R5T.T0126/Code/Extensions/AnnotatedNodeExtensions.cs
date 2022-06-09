using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0126;


namespace System
{
    public static class AnnotatedNodeExtensions
    {
        public static AnnotatedNode<TNode> Modify<TNode>(this AnnotatedNode<TNode> annotatedNode,
            Func<TNode, TNode> modifier)
            where TNode : SyntaxNode
        {
            var modifiedNode = modifier(annotatedNode.Node);

            var output = AnnotatedNode.From(modifiedNode);
            return output;
        }

        public static async Task<AnnotatedNode<TNode>> Modify<TNode>(this AnnotatedNode<TNode> annotatedNode,
            Func<TNode, Task<TNode>> modifier)
            where TNode : SyntaxNode
        {
            var modifiedNode = await modifier(annotatedNode.Node);

            var output = AnnotatedNode.From(modifiedNode);
            return output;
        }

        public static AnnotatedNode<TNode> NormalizeWhitespace<TNode>(this AnnotatedNode<TNode> annotatedNode)
            where TNode : SyntaxNode
        {
            var output = annotatedNode.Modify(x => x.NormalizeWhitespace());
            return output;
        }
    }
}
