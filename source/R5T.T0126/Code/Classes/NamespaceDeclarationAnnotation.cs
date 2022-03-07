using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0126
{
    public class NamespaceDeclarationAnnotation : SyntaxNodeSyntaxAnnotation<NamespaceDeclarationSyntax>
    {
        #region Static

        public static NamespaceDeclarationAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new NamespaceDeclarationAnnotation(annotation);
            return output;
        }

        #endregion


        public NamespaceDeclarationAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
