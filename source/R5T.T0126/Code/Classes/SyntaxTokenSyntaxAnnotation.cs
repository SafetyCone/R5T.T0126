using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxTokenSyntaxAnnotation : TypedSyntaxAnnotation<SyntaxToken>
    {
        public SyntaxTokenSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
