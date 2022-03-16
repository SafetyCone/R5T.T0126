using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class MethodDeclarationAnnotation : SyntaxNodeSyntaxAnnotation<MethodDeclarationSyntax>
    {
        #region Static

        public static MethodDeclarationAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new MethodDeclarationAnnotation(annotation);
            return output;
        }

        #endregion


        public MethodDeclarationAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
