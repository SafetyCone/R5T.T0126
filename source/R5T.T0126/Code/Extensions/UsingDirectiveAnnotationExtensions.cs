using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.T0126;


namespace System
{
    public static class UsingDirectiveAnnotationExtensions
    {
        public static IEnumerable<UsingNameAliasDirectiveAnnotation> GetUsingNameAliasDirectives<TNode>(this IEnumerable<UsingDirectiveAnnotation> usingDirectiveAnnotations,
            TNode node)
            where TNode : SyntaxNode
        {
            var output = usingDirectiveAnnotations
                .Where(x => node.GetAnnotatedNode_Typed(x).IsUsingNameAliasDirective())
                .Select(UsingNameAliasDirectiveAnnotation.From)
                ;

            return output;
        }

        public static IEnumerable<UsingNamespaceDirectiveAnnotation> GetUsingNamespaceDirectives<TNode>(this IEnumerable<UsingDirectiveAnnotation> usingDirectiveAnnotations,
            TNode node)
            where TNode : SyntaxNode
        {
            var output = usingDirectiveAnnotations
                .Where(x => node.GetAnnotatedNode_Typed(x).IsUsingNamespaceDirective())
                .Select(UsingNamespaceDirectiveAnnotation.From)
                ;

            return output;
        }
    }
}
