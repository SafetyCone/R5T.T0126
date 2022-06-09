using System;

using Microsoft.CodeAnalysis;

using R5T.T0126;


namespace System
{
    public static class SyntaxTokenExtensions
    {
        /// <summary>
        /// Annotates the node, and returns it.
        /// </summary>
        public static SyntaxToken Annotate_Typed(this SyntaxToken token,
            out ISyntaxTokenAnnotation annotation)
        {
            var output = token.Annotate(out SyntaxAnnotation untypedAnnotation);

            annotation = SyntaxTokenAnnotation.From(untypedAnnotation);

            return output;
        }
    }
}
