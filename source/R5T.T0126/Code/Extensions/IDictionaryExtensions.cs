using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;

using R5T.T0126;


namespace System.Linq
{
    public static class IDictionaryExtensions
    {
        public static Dictionary<TNode, TTypedSyntaxAnnotation> ToTypedAnnotationsByNode<TNode, TTypedSyntaxAnnotation>(this IDictionary<TNode, SyntaxAnnotation> untypedAnnotationsByNode,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor)
            where TNode : SyntaxNode
            where TTypedSyntaxAnnotation : SyntaxNodeAnnotation<TNode>
        {
            var output = untypedAnnotationsByNode
                .Select(xPair => new { xPair.Key, Value = typedSyntaxAnnotationConstructor(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }

        public static Dictionary<TNode, SyntaxNodeAnnotation<TNode>> ToTypedAnnotationsByNode<TNode>(this IDictionary<TNode, SyntaxAnnotation> untypedAnnotationsByNode)
            where TNode : SyntaxNode
        {
            var output = untypedAnnotationsByNode
                .Select(xPair => new { xPair.Key, Value = new SyntaxNodeAnnotation<TNode>(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }
    }
}
