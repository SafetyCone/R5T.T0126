using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class MethodAnnotation : SyntaxNodeAnnotation<MethodDeclarationSyntax>
    {
        #region Static

        public static MethodAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new MethodAnnotation(annotation);
            return output;
        }

        #endregion


        public MethodAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
